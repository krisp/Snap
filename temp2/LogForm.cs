using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screen_Grab
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            var hashfile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "delete_hashes.txt");
            lblLogfile.Text = hashfile;
            if (File.Exists(hashfile))
                tbLog.Text = File.ReadAllText(hashfile);
            else
                tbLog.Text = "Log empty";

            tbLog.Select(1, 0);
        }
    }
}
