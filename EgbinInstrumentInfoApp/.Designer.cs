namespace EgbinInstrumentInfoApp
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.StaffIdLabel = new System.Windows.Forms.Label();
            this.StaffIdTextBox = new System.Windows.Forms.TextBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.ForgotPassLbl = new System.Windows.Forms.Label();
            this.InfoIcon = new System.Windows.Forms.PictureBox();
            this.EgbinLogo = new System.Windows.Forms.PictureBox();
            this.StaffIdPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.InfoIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EgbinLogo)).BeginInit();
            this.StaffIdPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // StaffIdLabel
            // 
            this.StaffIdLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StaffIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StaffIdLabel.Location = new System.Drawing.Point(11, 38);
            this.StaffIdLabel.Name = "StaffIdLabel";
            this.StaffIdLabel.Size = new System.Drawing.Size(90, 30);
            this.StaffIdLabel.TabIndex = 1;
            this.StaffIdLabel.Text = "Staff ID:";
            this.StaffIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.StaffIdLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // StaffIdTextBox
            // 
            this.StaffIdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StaffIdTextBox.Location = new System.Drawing.Point(107, 38);
            this.StaffIdTextBox.Name = "StaffIdTextBox";
            this.StaffIdTextBox.Size = new System.Drawing.Size(324, 30);
            this.StaffIdTextBox.TabIndex = 2;
            // 
            // LoginBtn
            // 
            this.LoginBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginBtn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LoginBtn.Location = new System.Drawing.Point(255, 365);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(150, 29);
            this.LoginBtn.TabIndex = 5;
            this.LoginBtn.Text = "LOGIN";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // ForgotPassLbl
            // 
            this.ForgotPassLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ForgotPassLbl.AutoSize = true;
            this.ForgotPassLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForgotPassLbl.Location = new System.Drawing.Point(238, 409);
            this.ForgotPassLbl.Name = "ForgotPassLbl";
            this.ForgotPassLbl.Size = new System.Drawing.Size(122, 17);
            this.ForgotPassLbl.TabIndex = 7;
            this.ForgotPassLbl.Text = "Forgot Password?";
            this.ForgotPassLbl.Visible = false;
            // 
            // InfoIcon
            // 
            this.InfoIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.InfoIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.InfoIcon.Image = ((System.Drawing.Image)(resources.GetObject("InfoIcon.Image")));
            this.InfoIcon.Location = new System.Drawing.Point(12, 409);
            this.InfoIcon.Name = "InfoIcon";
            this.InfoIcon.Size = new System.Drawing.Size(56, 40);
            this.InfoIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.InfoIcon.TabIndex = 6;
            this.InfoIcon.TabStop = false;
            this.InfoIcon.Click += new System.EventHandler(this.InfoIcon_Click);
            // 
            // EgbinLogo
            // 
            this.EgbinLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EgbinLogo.Image = global::EgbinInstrumentInfoApp.Properties.Resources.iilogotransparent;
            this.EgbinLogo.Location = new System.Drawing.Point(12, 43);
            this.EgbinLogo.Name = "EgbinLogo";
            this.EgbinLogo.Size = new System.Drawing.Size(669, 216);
            this.EgbinLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.EgbinLogo.TabIndex = 0;
            this.EgbinLogo.TabStop = false;
            // 
            // StaffIdPanel
            // 
            this.StaffIdPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StaffIdPanel.Controls.Add(this.StaffIdLabel);
            this.StaffIdPanel.Controls.Add(this.StaffIdTextBox);
            this.StaffIdPanel.Location = new System.Drawing.Point(176, 249);
            this.StaffIdPanel.Name = "StaffIdPanel";
            this.StaffIdPanel.Size = new System.Drawing.Size(443, 94);
            this.StaffIdPanel.TabIndex = 8;
            // 
            // Login
            // 
            this.AcceptButton = this.LoginBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.StaffIdPanel);
            this.Controls.Add(this.ForgotPassLbl);
            this.Controls.Add(this.InfoIcon);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.EgbinLogo);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(50, 50);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.Load += new System.EventHandler(this.Login_Load);
            this.Resize += new System.EventHandler(this.Login_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.InfoIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EgbinLogo)).EndInit();
            this.StaffIdPanel.ResumeLayout(false);
            this.StaffIdPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox EgbinLogo;
        private System.Windows.Forms.Label StaffIdLabel;
        private System.Windows.Forms.TextBox StaffIdTextBox;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.PictureBox InfoIcon;
        private System.Windows.Forms.Label ForgotPassLbl;
        private System.Windows.Forms.Panel StaffIdPanel;
    }
}

