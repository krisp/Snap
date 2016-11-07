using System;
using System.Windows.Forms;

namespace Screen_Grab
{
    public partial class Options : Form
    {
        public enum ImgProviders { slimg=0, imgur=1, webdav=2 };
        private int imgProvider;
        private Form2 parent;

        public Options(Form2 _parent)
        {
            this.parent = _parent;
            InitializeComponent();
        }

        public static int getImgProvider()
        {
            return Properties.Settings.Default.provider;
        }

        public static bool isUploadEnabled()
        {
            return Properties.Settings.Default.uploadEnabled;
        }

        public static bool isPreviewEnabled()
        {
            return Properties.Settings.Default.preview;
        }

        public static string getAPIkey()
        {
            return Properties.Settings.Default.apikey;
        }

        private void cbUploadEnabled_CheckedChanged(object sender, EventArgs e)
        {
            //gbImgProvider.Enabled = cbUploadEnabled.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveSettings();
            this.Close();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            cbUploadEnabled.Checked = Properties.Settings.Default.uploadEnabled;
            tbAPIkey.Text = Properties.Settings.Default.apikey;
            //cbPreview.Checked = Properties.Settings.Default.preview;
            imgProvider = Properties.Settings.Default.provider;
            if (imgProvider == (int)ImgProviders.imgur)
                rbImgur.Checked = true;
            else if (imgProvider == (int)ImgProviders.slimg)
                rbSlimg.Checked = true;
            else
                rbWebDav.Checked = true;
        }

        private void rbSlimg_CheckedChanged(object sender, EventArgs e)
        {
            imgProvider = (int)ImgProviders.slimg;
        }

        private void rbImgur_CheckedChanged(object sender, EventArgs e)
        {
            imgProvider = (int)ImgProviders.imgur;
        }

        private void rbWebDav_CheckedChanged(object sender, EventArgs e)
        {
            imgProvider = (int)ImgProviders.webdav;
        }

        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveSettings();
            this.parent.Show();
        }

        private void saveSettings()
        {
            Properties.Settings.Default.uploadEnabled = cbUploadEnabled.Checked;
            Properties.Settings.Default.apikey = tbAPIkey.Text;
            Properties.Settings.Default.preview = true;
            Properties.Settings.Default.provider = imgProvider;
            Properties.Settings.Default.Save();
        }
    }
}
