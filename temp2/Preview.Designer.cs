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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preview));
            this.pbImg = new System.Windows.Forms.PictureBox();
            this.pbUpload = new System.Windows.Forms.ProgressBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsUpload2 = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsDraw = new System.Windows.Forms.ToolStripButton();
            this.tsddColors = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsddSize = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsLogReader = new System.Windows.Forms.ToolStripButton();
            this.tsClear = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbImg)).BeginInit();
            this.toolStrip1.SuspendLayout();
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
            // pbUpload
            // 
            this.pbUpload.Location = new System.Drawing.Point(0, 27);
            this.pbUpload.Name = "pbUpload";
            this.pbUpload.Size = new System.Drawing.Size(204, 23);
            this.pbUpload.TabIndex = 2;
            this.pbUpload.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsUpload2,
            this.tsSave,
            this.toolStripSeparator1,
            this.tsDraw,
            this.tsddColors,
            this.tsddSize,
            this.tsClear,
            this.toolStripSeparator2,
            this.tsLogReader});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsUpload2
            // 
            this.tsUpload2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsUpload2.Image = ((System.Drawing.Image)(resources.GetObject("tsUpload2.Image")));
            this.tsUpload2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsUpload2.Name = "tsUpload2";
            this.tsUpload2.Size = new System.Drawing.Size(23, 22);
            this.tsUpload2.Text = "Upload";
            this.tsUpload2.Click += new System.EventHandler(this.upload_Click);
            // 
            // tsSave
            // 
            this.tsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSave.Image = ((System.Drawing.Image)(resources.GetObject("tsSave.Image")));
            this.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSave.Name = "tsSave";
            this.tsSave.Size = new System.Drawing.Size(23, 22);
            this.tsSave.Text = "Save";
            this.tsSave.Click += new System.EventHandler(this.saveToDiskToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsDraw
            // 
            this.tsDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsDraw.Image = ((System.Drawing.Image)(resources.GetObject("tsDraw.Image")));
            this.tsDraw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDraw.Name = "tsDraw";
            this.tsDraw.Size = new System.Drawing.Size(23, 22);
            this.tsDraw.Text = "Draw";
            this.tsDraw.Click += new System.EventHandler(this.drawObfuscationToolStripMenuItem_Click);
            // 
            // tsddColors
            // 
            this.tsddColors.Name = "tsddColors";
            this.tsddColors.Size = new System.Drawing.Size(13, 22);
            this.tsddColors.ToolTipText = "Color";
            // 
            // tsddSize
            // 
            this.tsddSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddSize.Name = "tsddSize";
            this.tsddSize.Size = new System.Drawing.Size(40, 22);
            this.tsddSize.Text = "Size";
            this.tsddSize.ToolTipText = "Size";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsLogReader
            // 
            this.tsLogReader.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsLogReader.Image = ((System.Drawing.Image)(resources.GetObject("tsLogReader.Image")));
            this.tsLogReader.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsLogReader.Name = "tsLogReader";
            this.tsLogReader.Size = new System.Drawing.Size(23, 22);
            this.tsLogReader.ToolTipText = "Upload Log";
            this.tsLogReader.Click += new System.EventHandler(this.tsLogReader_Click);
            // 
            // tsClear
            // 
            this.tsClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsClear.Image = ((System.Drawing.Image)(resources.GetObject("tsClear.Image")));
            this.tsClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsClear.Name = "tsClear";
            this.tsClear.Size = new System.Drawing.Size(23, 22);
            this.tsClear.ToolTipText = "Clear changes";
            this.tsClear.Click += new System.EventHandler(this.tsClear_Click);
            // 
            // Preview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pbUpload);
            this.Controls.Add(this.pbImg);
            this.Name = "Preview";
            this.Text = "Snap Preview";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Preview_FormClosing);
            this.Load += new System.EventHandler(this.Preview_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Preview_KeyPress);
            this.Resize += new System.EventHandler(this.Preview_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbImg)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImg;
        private System.Windows.Forms.ProgressBar pbUpload;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsUpload2;
        private System.Windows.Forms.ToolStripButton tsSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsDraw;
        private System.Windows.Forms.ToolStripDropDownButton tsddColors;
        private System.Windows.Forms.ToolStripDropDownButton tsddSize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsLogReader;
        private System.Windows.Forms.ToolStripButton tsClear;
    }
}