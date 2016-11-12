﻿namespace Screen_Grab
{
    partial class Options
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbImgProvider = new System.Windows.Forms.GroupBox();
            this.rbWebDav = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbAPIkey = new System.Windows.Forms.TextBox();
            this.rbImgur = new System.Windows.Forms.RadioButton();
            this.rbSlimg = new System.Windows.Forms.RadioButton();
            this.cbUploadEnabled = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbAnnounceEnabled = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAnnounceURI = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAuthor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbChannel = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.gbImgProvider.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbImgProvider);
            this.groupBox1.Controls.Add(this.cbUploadEnabled);
            this.groupBox1.Location = new System.Drawing.Point(14, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 146);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Automatic Upload";
            // 
            // gbImgProvider
            // 
            this.gbImgProvider.Controls.Add(this.rbWebDav);
            this.gbImgProvider.Controls.Add(this.groupBox3);
            this.gbImgProvider.Controls.Add(this.rbImgur);
            this.gbImgProvider.Controls.Add(this.rbSlimg);
            this.gbImgProvider.Location = new System.Drawing.Point(6, 42);
            this.gbImgProvider.Name = "gbImgProvider";
            this.gbImgProvider.Size = new System.Drawing.Size(420, 98);
            this.gbImgProvider.TabIndex = 1;
            this.gbImgProvider.TabStop = false;
            this.gbImgProvider.Text = "Image Provider";
            // 
            // rbWebDav
            // 
            this.rbWebDav.AutoSize = true;
            this.rbWebDav.Location = new System.Drawing.Point(131, 20);
            this.rbWebDav.Name = "rbWebDav";
            this.rbWebDav.Size = new System.Drawing.Size(127, 17);
            this.rbWebDav.TabIndex = 3;
            this.rbWebDav.Text = "custom (uri in api key)";
            this.rbWebDav.UseVisualStyleBackColor = true;
            this.rbWebDav.CheckedChanged += new System.EventHandler(this.rbWebDav_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbAPIkey);
            this.groupBox3.Location = new System.Drawing.Point(7, 44);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(398, 48);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "API Key (optional)";
            // 
            // tbAPIkey
            // 
            this.tbAPIkey.Location = new System.Drawing.Point(7, 19);
            this.tbAPIkey.Name = "tbAPIkey";
            this.tbAPIkey.Size = new System.Drawing.Size(385, 20);
            this.tbAPIkey.TabIndex = 0;
            // 
            // rbImgur
            // 
            this.rbImgur.AutoSize = true;
            this.rbImgur.Checked = true;
            this.rbImgur.Location = new System.Drawing.Point(74, 20);
            this.rbImgur.Name = "rbImgur";
            this.rbImgur.Size = new System.Drawing.Size(50, 17);
            this.rbImgur.TabIndex = 1;
            this.rbImgur.TabStop = true;
            this.rbImgur.Text = "imgur";
            this.rbImgur.UseVisualStyleBackColor = true;
            this.rbImgur.CheckedChanged += new System.EventHandler(this.rbImgur_CheckedChanged);
            // 
            // rbSlimg
            // 
            this.rbSlimg.AutoSize = true;
            this.rbSlimg.Enabled = false;
            this.rbSlimg.Location = new System.Drawing.Point(14, 20);
            this.rbSlimg.Name = "rbSlimg";
            this.rbSlimg.Size = new System.Drawing.Size(51, 17);
            this.rbSlimg.TabIndex = 0;
            this.rbSlimg.Text = "sli.mg";
            this.rbSlimg.UseVisualStyleBackColor = true;
            this.rbSlimg.CheckedChanged += new System.EventHandler(this.rbSlimg_CheckedChanged);
            // 
            // cbUploadEnabled
            // 
            this.cbUploadEnabled.AutoSize = true;
            this.cbUploadEnabled.Enabled = false;
            this.cbUploadEnabled.Location = new System.Drawing.Point(13, 19);
            this.cbUploadEnabled.Name = "cbUploadEnabled";
            this.cbUploadEnabled.Size = new System.Drawing.Size(65, 17);
            this.cbUploadEnabled.TabIndex = 0;
            this.cbUploadEnabled.Text = "&Enabled";
            this.cbUploadEnabled.UseVisualStyleBackColor = true;
            this.cbUploadEnabled.CheckedChanged += new System.EventHandler(this.cbUploadEnabled_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(380, 284);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbChannel);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbAuthor);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbAnnounceURI);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbAnnounceEnabled);
            this.groupBox2.Location = new System.Drawing.Point(14, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(441, 114);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Urlbot Announcement";
            // 
            // cbAnnounceEnabled
            // 
            this.cbAnnounceEnabled.AutoSize = true;
            this.cbAnnounceEnabled.Location = new System.Drawing.Point(13, 20);
            this.cbAnnounceEnabled.Name = "cbAnnounceEnabled";
            this.cbAnnounceEnabled.Size = new System.Drawing.Size(65, 17);
            this.cbAnnounceEnabled.TabIndex = 0;
            this.cbAnnounceEnabled.Text = "Enabled";
            this.cbAnnounceEnabled.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "URI:";
            // 
            // tbAnnounceURI
            // 
            this.tbAnnounceURI.Location = new System.Drawing.Point(49, 41);
            this.tbAnnounceURI.Name = "tbAnnounceURI";
            this.tbAnnounceURI.Size = new System.Drawing.Size(356, 20);
            this.tbAnnounceURI.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Author:";
            // 
            // tbAuthor
            // 
            this.tbAuthor.Location = new System.Drawing.Point(144, 71);
            this.tbAuthor.Name = "tbAuthor";
            this.tbAuthor.Size = new System.Drawing.Size(100, 20);
            this.tbAuthor.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Channel:";
            // 
            // tbChannel
            // 
            this.tbChannel.Location = new System.Drawing.Point(305, 71);
            this.tbChannel.Name = "tbChannel";
            this.tbChannel.Size = new System.Drawing.Size(100, 20);
            this.tbChannel.TabIndex = 6;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 319);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Options";
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Options_FormClosing);
            this.Load += new System.EventHandler(this.Options_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbImgProvider.ResumeLayout(false);
            this.gbImgProvider.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbImgProvider;
        private System.Windows.Forms.RadioButton rbWebDav;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbAPIkey;
        private System.Windows.Forms.RadioButton rbImgur;
        private System.Windows.Forms.RadioButton rbSlimg;
        private System.Windows.Forms.CheckBox cbUploadEnabled;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbAnnounceURI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbAnnounceEnabled;
        private System.Windows.Forms.TextBox tbChannel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbAuthor;
        private System.Windows.Forms.Label label2;
    }
}