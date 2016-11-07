namespace Screen_Grab
{
    partial class LogForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblLogfile = new System.Windows.Forms.Label();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Logfile:";
            // 
            // lblLogfile
            // 
            this.lblLogfile.AutoSize = true;
            this.lblLogfile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLogfile.Location = new System.Drawing.Point(47, 3);
            this.lblLogfile.Name = "lblLogfile";
            this.lblLogfile.Size = new System.Drawing.Size(37, 15);
            this.lblLogfile.TabIndex = 1;
            this.lblLogfile.Text = "label2";
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(3, 21);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(506, 261);
            this.tbLog.TabIndex = 2;
            this.tbLog.WordWrap = false;
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 285);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.lblLogfile);
            this.Controls.Add(this.label1);
            this.Name = "LogForm";
            this.Text = "Image Log";
            this.Load += new System.EventHandler(this.LogForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLogfile;
        private System.Windows.Forms.TextBox tbLog;
    }
}