using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Screen_Grab
{
    public partial class Form1 : Form  //these form are used for selected screen grabing
    {
        Form2 Parent;
        int xMouse = 0, yMouse = 0, newX=0, newY=0, mousedown = 0, penwidth = 3;
        int screennumber=0; // parameter to save its screen number for easy reference later
        int grabmode = 0;
        public struct IconInfo
        {
            public bool fIcon;
            public int xHotspot;
            public int yHotspot;
            public IntPtr hbmMask;
            public IntPtr hbmColor;
        }

        public Form1(Form2 par, string cursor_text, int a,int b, int c,int d, int scn)
        {  //(Parent Form2, string for cursor , X bound, Y bound, Width, Height, Screen number)
            InitializeComponent(par, cursor_text,a,b,c,d, scn);
        }

        private void InitializeComponent(Form2 par, string cursor_text, int xstart, int ystart, int xwidth, int ywidth, int scn)
        {
            screennumber = scn;
            Parent = par;

            // Set Mouse cursor based on screen grab or Area Grab
            if (cursor_text.Length != 0)  //text string cursor for area select forms
            {
                Bitmap bitmap = new Bitmap(230, 25);
                Graphics g = Graphics.FromImage(bitmap);
                using (Font f = new Font("Arial", 15))
                    g.DrawString(cursor_text, f, Brushes.Red, 0, 0);
                Pen pen = new Pen(Color.Red);
                g.DrawRectangle(pen, 0, 0, bitmap.Width - 1, bitmap.Height - 1);
                pen.Dispose();
                this.Cursor = CreateCursor(bitmap, 0, 0);
                bitmap.Dispose();
                grabmode = 0;  //parameter to show if area grab mode or not; 0 is full screen grab
            }
            else
            {
                this.Cursor = System.Windows.Forms.Cursors.Cross;
                grabmode = 1;
            }
            this.SuspendLayout();
            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ShowInTaskbar = false;
            this.ClientSize = new System.Drawing.Size(xwidth, ywidth);

            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Child Form";
            this.Opacity = 0.3;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual; //important in mutiple monitor environment
            this.Location = new Point(xstart, ystart);
            this.Text = "ChildForm";
            this.TopMost = true;

            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.ResumeLayout(false);

        }

       
        private void OnMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //if full screen capture is ON, just detect any click and return
            if (grabmode == 0) { //Call parent funstion to close child window and grab screen
                Parent.grabwholescreen(screennumber); return; } 
            
            switch (e.Button)
            {
       case MouseButtons.Left:
            mousedown = 1;
            xMouse = e.X; // first click position stored in xMouse,yMouse
            yMouse = e.Y;
            newX = xMouse;
            newY = yMouse;
        
            Graphics gfx = CreateGraphics();
            Pen linePen = new Pen(Color.Black);
            linePen.Width = penwidth;

            gfx.DrawLine(linePen, xMouse, yMouse, xMouse,newY); // Draw rectangle, used rectangle function also but was giving errors
            gfx.DrawLine(linePen, xMouse, yMouse, newX, yMouse);
            gfx.DrawLine(linePen, newX, newY, newX, yMouse);
            gfx.DrawLine(linePen, newX, newY, xMouse, newY);

            linePen.Dispose();
            gfx.Dispose();
                  
            break;
          
            case MouseButtons.None:
            default:
            break;
            }
            
        }
        
        private void OnMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (mousedown != 1) return; //check if the left button is pressed, if not return
      
          //  this.Cursor = new Cursor(Cursor.Current.Handle);
       //     Cursor.Clip = new Rectangle(this.Location, this.ClientSize);  //limit cursor to this screen

               Graphics gfx = CreateGraphics();
           
                 Pen erasePen = new Pen(Color.White);
                 erasePen.Width = penwidth;
         
                 gfx.DrawLine(erasePen, xMouse, yMouse, xMouse, newY); //remove the old rectangle
                 gfx.DrawLine(erasePen, xMouse, yMouse, newX, yMouse);
                 gfx.DrawLine(erasePen, newX, newY, newX, yMouse);
                 gfx.DrawLine(erasePen, newX, newY, xMouse, newY);
          
                Pen linePen = new Pen(Color.Black);
                linePen.Width = penwidth;
                newX = e.X;
                newY = e.Y;
          
               gfx.DrawLine(linePen, xMouse, yMouse, xMouse, newY); //draw new rectangle on the Form
               gfx.DrawLine(linePen, xMouse, yMouse, newX, yMouse);
               gfx.DrawLine(linePen, newX, newY, newX, yMouse);
               gfx.DrawLine(linePen, newX, newY, xMouse, newY);

               erasePen.Dispose();
               linePen.Dispose();
               gfx.Dispose();

        }

        private void OnMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    mousedown = 0;
                    //call the parent function to close child windows and grab screen
                    Parent.smallscreengrab(screennumber, xMouse, yMouse, newX, newY); 
                    break;

                case MouseButtons.None:
                default:
                break;
            }

        }

        

        #region Make cursor from bitmap: Use CreateCursor
        [DllImport("user32.dll")]
        public static extern IntPtr CreateIconIndirect(ref IconInfo icon);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);

        public static Cursor CreateCursor(Bitmap bmp, int xHotSpot, int yHotSpot)
        {
            IconInfo tmp = new IconInfo();
            GetIconInfo(bmp.GetHicon(), ref tmp);
            tmp.xHotspot = xHotSpot;
            tmp.yHotspot = yHotSpot;
            tmp.fIcon = false;
            return new Cursor(CreateIconIndirect(ref tmp));
        }

        #endregion

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }
    }
}
