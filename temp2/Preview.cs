using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Specialized;
using System.Net;

using Newtonsoft.Json;


namespace Screen_Grab
{
    public partial class Preview : Form
    {
        private Form2 parent;
        private bool drawObfuscate = false;
        private bool drawing = false;
        private bool hasDrawn = false;
        private Point lastPoint;
        private Color penColor = Color.Black;
        private int penSize = 6;

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

            this.Size = new Size(400, pbImg.Size.Height + 70);
            if(pbImg.Size.Width > 400)
                this.Size = new Size(pbImg.Size.Width + 20 , (pbImg.Size.Height < 900) ? pbImg.Size.Height + 70 : 970);

            foreach (var color in colorsilike)
            {
                ToolStripMenuItem x = new ToolStripMenuItem(color);
                x.Click += new System.EventHandler(x_Click);
                x.Image = new Bitmap(32, 32);
                using (Graphics g = Graphics.FromImage(x.Image))
                {
                    Rectangle r = new Rectangle(0, 0, 32, 32);
                    g.FillRectangle(new SolidBrush(Color.FromName(color)), r);
                    g.DrawRectangle(Pens.Transparent, r);
                }
                tsddColors.DropDownItems.Add(x);
            }
            foreach (var size in pensizes)
            {
                ToolStripMenuItem x = new ToolStripMenuItem(size.ToString());
                x.Click += new System.EventHandler(size_Click);
                tsddSize.DropDownItems.Add(x);
            }

            ToolStripItem y = new ToolStripMenuItem("Custom...");
            y.Click += new System.EventHandler(y_Click);
            penMenu.DropDownItems.Add(y);
            penColor = Properties.Settings.Default.penColor;
            penSize = Properties.Settings.Default.penSize;

            tsddSize.Text = "Size: " + penSize.ToString();

            tsddColors.Image = new Bitmap(32, 32);
            using(Graphics g = Graphics.FromImage(tsddColors.Image))
            {
                Rectangle r = new Rectangle(0, 0, 32, 32);
                g.FillRectangle(new SolidBrush(penColor), r);
                g.DrawRectangle(Pens.Transparent, r);                    
            }
            tsddColors.Invalidate();
        }

        void x_Click(object sender, EventArgs e)
        {
            penMenu.Text = "Pen: " + sender.ToString();
            penColor = Color.FromName(sender.ToString());
            drawObfuscate = true;
            pbImg.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        void size_Click(object sender, EventArgs e)
        {
            tsddSize.Text = "Size: " + sender.ToString();
            penSize = int.Parse(sender.ToString());
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
            Properties.Settings.Default.penSize = penSize;
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

        private void onUploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            /*
            if (e.ProgressPercentage >= pbUpload.Minimum && e.ProgressPercentage <= pbUpload.Maximum)
                pbUpload.Value = (int)e.BytesSent;
            else
               pbUpload.Value = 100;
             */
            try
            {
                pbUpload.Maximum = (int)e.TotalBytesToSend/1000;
                pbUpload.Value = (int)e.BytesSent/1000;
            } catch {

            }
        }

        private void onUploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            try
            {
                imgurRootObject rd = JsonConvert.DeserializeObject<imgurRootObject>(System.Text.Encoding.UTF8.GetString(e.Result));
                var d = rd.data;
                Clipboard.SetText(d.link);

                var hashfile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "delete_hashes.txt");
                var output = "Link: " + d.link + " deletehash: https://imgur.com/delete/" + d.deletehash + "\r\n";
                byte[] xz = System.Text.UTF8Encoding.UTF8.GetBytes(output);
                using(var fd = new FileStream(hashfile, FileMode.Append))
                    fd.Write(xz,0,xz.Length);               

                parent.Text = "Snap (" + d.link + ")";
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error decoding link: " + ex.Message);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {            
            MemoryStream ms = new MemoryStream();
            pbImg.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            using (var w = new WebClient())
            {
                NameValueCollection vals;
                w.UploadProgressChanged += new UploadProgressChangedEventHandler(this.onUploadProgressChanged);
                w.UploadValuesCompleted += new UploadValuesCompletedEventHandler(this.onUploadValuesCompleted);

                switch (Options.getImgProvider())
                {
                    case (int)Options.ImgProviders.imgur:

                        w.Headers.Add("Authorization", "Client-ID f86b75e23f8ae3b");
                        w.BaseAddress = "https://api.imgur.com/3/";

                        vals = new NameValueCollection
                            {
                                {"type", "base64"},
                                {"image", Convert.ToBase64String(ms.ToArray())}                            
                            };

                        try
                        {                      
                            w.UploadValuesAsync(new Uri("https://api.imgur.com/3/image"), "POST", vals);
                            pbUpload.Visible = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Upload failed: " + ex.Message);
                        }
                        break;

                    case (int)Options.ImgProviders.slimg:

                        w.Headers.Add("Authorization", "Client-ID GNoTWNo5C4sZiixLREjWx6ijiu2alxK2");
                        w.BaseAddress = "https://api.sli.mg/";

                        vals = new NameValueCollection
                        {
                            {"type", "base64"},
                            {"data", Convert.ToBase64String(ms.ToArray())}                            
                        };
                        try
                        {
                            w.UploadValuesAsync(new Uri("https://api.imgur.com/3/image"), "POST", vals);
                            pbUpload.Visible = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Upload failed: " + ex.Message);
                        }

                        break;

                    case (int)Options.ImgProviders.webdav:

                        vals = new NameValueCollection
                        {
                            {"type", "base64"},
                            {"data", Convert.ToBase64String(ms.ToArray())}                            
                        };

                        try
                        {
                            w.UploadValuesAsync(new Uri("https://api.imgur.com/3/image"), "POST", vals);
                            pbUpload.Visible = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Exception trying to upload: " + ex.Message);
                        }

                        break;
                }
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
            tsDraw.Checked = true;
            drawObfuscate = true;            
            pbImg.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void pbImg_MouseDown(object sender, MouseEventArgs e)
        {
            if((drawObfuscate || hasDrawn) && e.Button == MouseButtons.Left)
            {
                hasDrawn = true;
                lastPoint = e.Location;                
                drawing = true;
                pbImg.Cursor = Cursors.Hand;
                tsDraw.Checked = true;
            }
        }

        private void pbImg_MouseMove(object sender, MouseEventArgs e)
        {
            if(drawing && lastPoint != null)
            {
                using (Graphics g = Graphics.FromImage(pbImg.Image))                          
                    g.DrawLine(new Pen(penColor, penSize), lastPoint, e.Location);                
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
                tsDraw.Checked = false;
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
