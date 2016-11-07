using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Collections.Specialized;
using System.Net;
using System.Xml.Serialization;
using Newtonsoft.Json;


namespace Screen_Grab
{
    public partial class Preview : Form
    {
        private Form2 parent;
        private bool drawObfuscate = false;
        private bool drawing = false;
        private Point lastPoint;
        private Color penColor = Color.Black;

        public Preview(Form2 p)
        {
            this.parent = p;
            InitializeComponent();
        }

        private void Preview_Resize(object sender, EventArgs e)
        {
            if (pbImg.Size.Height < this.Size.Height ||
                pbImg.Size.Width < this.Size.Width)
            {
                this.AdjustFormScrollbars(true);
            }
            else
            {
                this.AdjustFormScrollbars(false);
            }
        }

        private void Preview_Load(object sender, EventArgs e)
        {
            string[] colorsilike = {"Black","Red","Blue","Yellow","Green","Orange","Purple","Gray"};
            int[] pensizes = { 1, 2, 4, 6, 8, 10, 14, 20 };
            pbImg.Image = Clipboard.GetImage();
            pbImg.Size = Clipboard.GetImage().Size;
            this.Size = new Size(pbImg.Size.Width + 20 , pbImg.Size.Height + 70);

            foreach (var color in colorsilike)
            {
                ToolStripItem x = new ToolStripMenuItem(color);
                x.Click += new System.EventHandler(x_Click);
                penMenu.DropDownItems.Add(x);
            }

            ToolStripItem y = new ToolStripMenuItem("Custom...");
            y.Click += new System.EventHandler(y_Click);
            penMenu.DropDownItems.Add(y);
            penColor = Properties.Settings.Default.penColor;

            if (penColor.IsNamedColor) 
            {
                penMenu.Text = "Pen: " + penColor.ToKnownColor().ToString();
            }
            else
            {
                penMenu.Text = "Pen: Custom";
            }
        }

        void x_Click(object sender, EventArgs e)
        {
            penMenu.Text = "Pen: " + sender.ToString();
            penColor = Color.FromName(sender.ToString());
            drawObfuscate = true;
            pbImg.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        void y_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            c.Color = penColor;
            if (c.ShowDialog() == DialogResult.OK)
            {
                penColor = c.Color;
                penMenu.Text = "Pen: Custom";
                drawObfuscate = true;
                pbImg.Cursor = System.Windows.Forms.Cursors.Hand;
            }            
        }

        private void Preview_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.penColor = penColor;
            Properties.Settings.Default.Save();
            parent.Visible = true;
        }

        private void cancelESCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Preview_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                if (drawObfuscate)
                    drawObfuscate = false;
                else
                    this.Close();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {            
            MemoryStream ms = new MemoryStream();
            pbImg.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

            switch (Options.getImgProvider())
            {
                case (int)Options.ImgProviders.imgur:
                    using (var w = new WebClient())
                    {
                        w.Headers.Add("Authorization", "Client-ID f86b75e23f8ae3b");
                        w.BaseAddress = "https://api.imgur.com/3/";
            
                        var vals = new NameValueCollection
                        {
                            {"type", "base64"},
                            {"image", Convert.ToBase64String(ms.ToArray())}                            
                        };

                        try
                        {
                            string response = System.Text.Encoding.UTF8.GetString(w.UploadValues("image", "POST", vals));
                            imgurRootObject rd = JsonConvert.DeserializeObject<imgurRootObject>(response);
                            var d = rd.data;
                            Clipboard.SetText(d.link);
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Upload failed: " + ex.Message);
                        }                        
                    }
                    break;

                case (int)Options.ImgProviders.slimg:
                    using (var w = new WebClient())
                    {
                        w.Headers.Add("Authorization", "Client-ID GNoTWNo5C4sZiixLREjWx6ijiu2alxK2");
                        w.BaseAddress = "https://api.sli.mg/";
            
                        var vals = new NameValueCollection
                        {
                            {"type", "base64"},
                            {"data", Convert.ToBase64String(ms.ToArray())}                            
                        };
                        try
                        {
                            string response = System.Text.Encoding.UTF8.GetString(w.UploadValues("media", "POST", vals));
                            imgurRootObject rd = JsonConvert.DeserializeObject<imgurRootObject>(response);
                            var d = rd.data;
                            Clipboard.SetText(d.link);
                            this.Close();
                        } 
                        catch (Exception ex)
                        {
                            MessageBox.Show("Upload failed: " + ex.Message);
                        }
                    }
                    break;

                case (int)Options.ImgProviders.webdav:
                    using (var w = new WebClient())
                    {                       
                        var vals = new NameValueCollection
                        {
                            {"type", "base64"},
                            {"data", Convert.ToBase64String(ms.ToArray())}                            
                        };

                        try
                        {
                            string response = System.Text.Encoding.UTF8.GetString(w.UploadValues(Options.getAPIkey(), "POST", vals));
                            imgurRootObject rd = JsonConvert.DeserializeObject<imgurRootObject>(response);
                            var d = rd.data;
                            Clipboard.SetText(d.link);
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Exception trying to upload: " + ex.Message);
                        }
                    }
                    break;
            }
            //this.Close();
        }

        private void saveToDiskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();            
            dlg.DefaultExt = ".png"; // Default file extension
            dlg.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff|Wmf Image (.wmf)|*.wmf";
            dlg.Filter = "Portable Network Graphics (.png)|*.png"; // Filter files by extension

            // Show save file dialog box
            Nullable<DialogResult> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == DialogResult.OK)
            {                
                pbImg.Image.Save(dlg.FileName);
                this.Close();
            }
        }

        private void drawObfuscationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawObfuscationToolStripMenuItem.Checked = true;
            drawObfuscate = true;            
            pbImg.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void pbImg_MouseDown(object sender, MouseEventArgs e)
        {
            if(drawObfuscate && e.Button == MouseButtons.Left)
            {
                lastPoint = e.Location;                
                drawing = true;                
            }
        }

        private void pbImg_MouseMove(object sender, MouseEventArgs e)
        {
            if(drawing && lastPoint != null)
            {
                using (Graphics g = Graphics.FromImage(pbImg.Image))                          
                    g.DrawLine(new Pen(penColor, 6), lastPoint, e.Location);
                
                pbImg.Invalidate();
                lastPoint = e.Location;           
            }
        }

        private void pbImg_MouseUp(object sender, MouseEventArgs e)
        {
            if(drawing)
            {
                drawing = false;
                drawObfuscate = false;
                lastPoint = Point.Empty;
                pbImg.Cursor = Cursors.Default;
                drawObfuscationToolStripMenuItem.Checked = false;
            }
        }

    }

    public class imgurData
    {
        public string id { get; set; }
        public object title { get; set; }
        public object description { get; set; }
        public int datetime { get; set; }
        public string type { get; set; }
        public bool animated { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int size { get; set; }
        public int views { get; set; }
        public int bandwidth { get; set; }
        public object vote { get; set; }
        public bool favorite { get; set; }
        public object nsfw { get; set; }
        public object section { get; set; }
        public object account_url { get; set; }
        public int account_id { get; set; }
        public bool is_ad { get; set; }
        public bool in_gallery { get; set; }
        public string deletehash { get; set; }
        public string name { get; set; }
        public string link { get; set; }
    }

    public class imgurRootObject
    {
        public imgurData data { get; set; }
        public bool success { get; set; }
        public int status { get; set; }
    }
}
