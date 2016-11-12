using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Specialized;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


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
        private Image originalImage;

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
            int[] pensizes = { 1, 2, 4, 6, 8, 10, 12, 14, 18, 20, 36};
            
            this.originalImage = Clipboard.GetImage();
            pbImg.Image = Clipboard.GetImage();
            pbImg.Size = Clipboard.GetImage().Size;            

            penColor = Properties.Settings.Default.penColor;
            penSize = Properties.Settings.Default.penSize;

            this.Size = new Size(400, pbImg.Size.Height + 70);
            if(pbImg.Size.Width > 400)
                this.Size = new Size(pbImg.Size.Width + 20 , (pbImg.Size.Height < 900) ? pbImg.Size.Height + 70 : 970);

            foreach (var color in colorsilike)
            {
                ToolStripMenuItem x = new ToolStripMenuItem(color);
                x.Click += new System.EventHandler(color_Click);
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
                x.Image = new Bitmap(32, 32);
                x.Click += new System.EventHandler(size_Click);
                using (Graphics g = Graphics.FromImage(x.Image))                
                    g.DrawLine(new Pen(penColor, size), new Point(8,16), new Point(24,16));                                
                tsddSize.DropDownItems.Add(x);
            }

            ToolStripItem y = new ToolStripMenuItem("Custom...");
            y.Click += new System.EventHandler(customColor_Click);
            tsddColors.DropDownItems.Add(y);

            tsddSize.Text = "Size: " + penSize.ToString();
            redrawColorMenu();
            redrawSizeMenu();

        }

        void redrawColorMenu()
        {
            tsddColors.Image = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(tsddColors.Image))
            {
                Rectangle r = new Rectangle(0, 0, 32, 32);
                g.FillRectangle(new SolidBrush(penColor), r);
                g.DrawRectangle(Pens.Transparent, r);
            }            
            tsddColors.Invalidate();
            redrawSizeMenu();
        }

        void redrawSizeMenu()
        {
            foreach (ToolStripMenuItem i in tsddSize.DropDownItems)
            {
                i.Image = new Bitmap(32, 32);
                using (Graphics g = Graphics.FromImage(i.Image))
                    g.DrawLine(new Pen(penColor, int.Parse(i.Text)), new Point(8, 16), new Point(24, 16));
                i.Invalidate();
            }
            tsddSize.Image = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(tsddSize.Image))
                g.DrawLine(new Pen(penColor, penSize), new Point(8, 16), new Point(24, 16));       
            tsddColors.Invalidate();
        }

        void color_Click(object sender, EventArgs e)
        {           
            penColor = Color.FromName(sender.ToString());
            tsDraw.Checked = true;
            redrawColorMenu();
            drawObfuscate = true;
            pbImg.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        void size_Click(object sender, EventArgs e)
        {
            tsddSize.Text = "Size: " + sender.ToString();
            penSize = int.Parse(sender.ToString());
            redrawSizeMenu();
        }

        void customColor_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            c.Color = penColor;
            if (c.ShowDialog() == DialogResult.OK)
            {
                penColor = c.Color;
                redrawColorMenu();
                drawObfuscate = true;
                tsDraw.Checked = true;
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
                JObject j = JObject.Parse(System.Text.Encoding.UTF8.GetString(e.Result));
                string link = j["data"]["link"].Value<string>();
                string deletehash = j["data"]["deletehash"].Value<string>();
                Clipboard.SetText(link);

                var hashfile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "delete_hashes.txt");
                var output = "Link: " + link + " deletehash: https://imgur.com/delete/" + deletehash + "\r\n";
                byte[] xz = System.Text.UTF8Encoding.UTF8.GetBytes(output);
                using(var fd = new FileStream(hashfile, FileMode.Append))
                    fd.Write(xz,0,xz.Length);

                parent.Text = "Snap (" + j["data"]["link"].Value<string>() + ")";

                if(Properties.Settings.Default.announce == true && Properties.Settings.Default.announceuri.Length > 0)
                {
                    try
                    {
                        using(var w = new WebClient())
                        {
                            w.UploadValuesAsync(new Uri(Properties.Settings.Default.announceuri), new NameValueCollection{
                                {"uri", link}, {"author", Properties.Settings.Default.announceauthor}, {"channel", Properties.Settings.Default.announcechannel}
                            });
                        }
                    }
                    catch
                    {

                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error decoding link: " + ex.InnerException.Message);
            }
        }

        private void upload_Click(object sender, EventArgs e)
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
                            w.UploadValuesAsync(new Uri(Properties.Settings.Default.apikey), "POST", vals);
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
                tsDraw.Checked = false;
            }
        }

        private void tsLogReader_Click(object sender, EventArgs e)
        {
            var l = new LogForm();
            l.Show();
        }

        private void tsClear_Click(object sender, EventArgs e)
        {
            pbImg.Image = (Image)originalImage.Clone();
        }

    }
}
