using System;
using System.Windows.Forms;
using System.ComponentModel;
using Microsoft.Win32;

namespace Screen_Grab
{
    public partial class Form2 : Form
    {
        int noofscreens = 0;
        Form1[] grabwindow;
        Screen[] screens;
        RegistryKey key;
        public Form2()
        {
            screens = Screen.AllScreens;
            noofscreens = screens.Length;
            InitializeComponent();
        }
        
           
        private void smallscreen_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Refresh();
            System.Threading.Thread.Sleep(100);
            noofscreens = screens.Length;
            grabwindow = new Form1[noofscreens];
            int i = 0;
            foreach (var screen in System.Windows.Forms.Screen.AllScreens)
            {
               grabwindow[i] = new Form1(this,"", screen.Bounds.X, screen.Bounds.Y, screen.Bounds.Width, screen.Bounds.Height, i);
               grabwindow[i].Show();
               i++;
            }
         }
        private void allscreen_Click(object sender, EventArgs e) // grab all screen
        {
            this.Visible = false;
            this.Refresh();
            System.Threading.Thread.Sleep(100);
              
            noofscreens = screens.Length;
            grabwindow = new Form1[noofscreens];
            int i = 0;

            foreach (var screen in System.Windows.Forms.Screen.AllScreens)
            {   
                grabwindow[i] = new Form1(this, "Click to capture screen "+(i+1).ToString(), screen.Bounds.X, screen.Bounds.Y, screen.Bounds.Width, screen.Bounds.Height,i);
                grabwindow[i].Show();
                i++;
            }
        }
        private void helpbutton_Click(object sender, EventArgs e)  //help button pressed
        {
            MessageBox.Show("This program is used to capture either the entire screen or part of it and save it into Clipboard. It supports multiple screens. \n\nUSAGE:\n\n FOR CAPTURING ENTIRE SCREEN:\n\n 1. Select second button and then you shall see mouse cursor suggesting to click to capture that screen.\n\n2. Paste the image into any program for usage." +
            "\n\nFOR CAPTURING A SECTION OF THE SCREEN:\n\n1. Select button one and you shall see mouse cursor changing to tilted arrows.\n\n2. Click mouse left key and keeping it pressed, select the area of interest.\n\n3. Leave the left button and the image is saved to clipboard.\n\n FOR CAPTURING ALL SCREENS:\n\n1. Press the 3rd button and All the screens are captured into one image.\n\n\nThanks for using the utility. Send in your feedback or bugs to mittaltarsem@gmail.com"
            , "SCREEN CAPTURE HELP !!");
        }

        public void grabwholescreen(int sc)  // called when ALL screen capture; sc is screen number
        {
            for (int j = 0; j < noofscreens; j++) { grabwindow[j].Close(); grabwindow[j].Dispose(); }
            capture_class.CaptureScreentoClipboard(screens[sc].Bounds.X, screens[sc].Bounds.Y,screens[sc].Bounds.Width, screens[sc].Bounds.Height);
            Preview p = new Preview(this);
            p.Show();
        }
        public void smallscreengrab(int sc, int x, int y, int x1, int y1) // grab part of screen
        {
            for (int j = 0; j < noofscreens; j++) { grabwindow[j].Close(); grabwindow[j].Dispose(); }
            int finalx, finaly, finalwidth, finalheight;
            int X1 =Math.Min(x,x1), X2 = Math.Max(x,x1), Y1 = Math.Min(y,y1), Y2=Math.Max(y,y1);
            finalx = X1 + screens[sc].Bounds.X;
            finaly = Y1+ screens[sc].Bounds.Y;
            finalwidth = X2 - X1 + 1;
            finalheight = Y2 - Y1 + 1;
            capture_class.CaptureScreentoClipboard(finalx, finaly, finalwidth, finalheight);
            Preview p = new Preview(this);
            p.Show();
        }
        public void Form2_Closing(object sender, CancelEventArgs e)
        {
            try
            {
                //key = Registry.CurrentUser.CreateSubKey("Software\\Screen_Grab_MultiMonitor");
                //key.SetValue("Startx", this.Location.X);
                //key.SetValue("Starty", this.Location.Y);
                Properties.Settings.Default.Startx = this.Location.X;
                Properties.Settings.Default.Starty = this.Location.Y;
                Properties.Settings.Default.Save();
            }
            catch { }
            e.Cancel = false;
        }

        private void grabALL_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            System.Threading.Thread.Sleep(100);
           
            int maxwidth = 0, maxheight = 0;
            for (int i = 0; i < noofscreens; i++) 
            {
                if (maxwidth < (screens[i].Bounds.X + screens[i].Bounds.Width)) maxwidth = screens[i].Bounds.X + screens[i].Bounds.Width;
                if (maxheight < (screens[i].Bounds.Y + screens[i].Bounds.Height)) maxheight = screens[i].Bounds.Y + screens[i].Bounds.Height;
            }
            capture_class.CaptureScreentoClipboard(0,0, maxwidth, maxheight);
            this.Visible = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                //key = Registry.CurrentUser.CreateSubKey("Software\\Screen_Grab_MultiMonitor");
                //int tx = (int)key.GetValue("Startx");
                //int ty = (int)key.GetValue("Starty");
                int tx = Properties.Settings.Default.Startx;
                int ty = Properties.Settings.Default.Starty;
                
                //check if last close position is within first screen
                if (tx < screens[0].Bounds.X || tx > (screens[0].Bounds.X + screens[0].Bounds.Width) || ty < screens[0].Bounds.Y || ty > (screens[0].Bounds.Y + screens[0].Bounds.Height))
                { this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; }
                else
                {
                    this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                    this.Location = new System.Drawing.Point(tx, ty);
                }
            }
            catch { this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Options o = new Options(this);
            o.Show();
            this.Hide();
        }

      
    }
}
