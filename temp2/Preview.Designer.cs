namespace Screen_Grab
{
    partial class Preview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbImg = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawObfuscationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.penMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelESCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbUpload = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pbImg)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbImg
            // 
            this.pbImg.Location = new System.Drawing.Point(0, 27);
            this.pbImg.Name = "pbImg";
            this.pbImg.Size = new System.Drawing.Size(526, 285);
            this.pbImg.TabIndex = 0;
            this.pbImg.TabStop = false;
            this.pbImg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbImg_MouseDown);
            this.pbImg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbImg_MouseMove);
            this.pbImg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbImg_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.saveToDiskToolStripMenuItem,
            this.drawObfuscationToolStripMenuItem,
            this.penMenu,
            this.cancelESCToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(57, 20);
            this.toolStripMenuItem1.Text = "Upload";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // saveToDiskToolStripMenuItem
            // 
            this.saveToDiskToolStripMenuItem.Name = "saveToDiskToolStripMenuItem";
            this.saveToDiskToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.saveToDiskToolStripMenuItem.Text = "Save to Disk";
            this.saveToDiskToolStripMenuItem.Click += new System.EventHandler(this.saveToDiskToolStripMenuItem_Click);
            // 
            // drawObfuscationToolStripMenuItem
            // 
            this.drawObfuscationToolStripMenuItem.Name = "drawObfuscationToolStripMenuItem";
            this.drawObfuscationToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.drawObfuscationToolStripMenuItem.Text = "Draw";
            this.drawObfuscationToolStripMenuItem.Click += new System.EventHandler(this.drawObfuscationToolStripMenuItem_Click);
            // 
            // penMenu
            // 
            this.penMenu.Name = "penMenu";
            this.penMenu.Size = new System.Drawing.Size(73, 20);
            this.penMenu.Text = "Pen: Black";
            // 
            // cancelESCToolStripMenuItem
            // 
            this.cancelESCToolStripMenuItem.Name = "cancelESCToolStripMenuItem";
            this.cancelESCToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.cancelESCToolStripMenuItem.Text = "Cancel (ESC)";
            this.cancelESCToolStripMenuItem.Click += new System.EventHandler(this.cancelESCToolStripMenuItem_Click);
            // 
            // pbUpload
            // 
            this.pbUpload.Location = new System.Drawing.Point(0, 27);
            this.pbUpload.Name = "pbUpload";
            this.pbUpload.Size = new System.Drawing.Size(204, 23);
            this.pbUpload.TabIndex = 2;
            this.pbUpload.Visible = false;
            // 
            // Preview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.pbUpload);
            this.Controls.Add(this.pbImg);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Preview";
            this.Text = "Preview";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Preview_FormClosing);
            this.Load += new System.EventHandler(this.Preview_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Preview_KeyPress);
            this.Resize += new System.EventHandler(this.Preview_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbImg)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImg;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToDiskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelESCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawObfuscationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem penMenu;
        private System.Windows.Forms.ProgressBar pbUpload;
    }
}