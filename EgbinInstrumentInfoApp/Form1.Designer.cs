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
            this.UsernameLbl = new System.Windows.Forms.Label();
            this.UsernameBx = new System.Windows.Forms.TextBox();
            this.PasswordLbl = new System.Windows.Forms.Label();
            this.PasswordBx = new System.Windows.Forms.TextBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.ForgotPassLbl = new System.Windows.Forms.Label();
            this.InfoIcon = new System.Windows.Forms.PictureBox();
            this.EgbinLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.InfoIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EgbinLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // UsernameLbl
            // 
            this.UsernameLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UsernameLbl.AutoSize = true;
            this.UsernameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLbl.Location = new System.Drawing.Point(127, 230);
            this.UsernameLbl.Name = "UsernameLbl";
            this.UsernameLbl.Size = new System.Drawing.Size(87, 20);
            this.UsernameLbl.TabIndex = 1;
            this.UsernameLbl.Text = "Username:";
            this.UsernameLbl.Click += new System.EventHandler(this.label1_Click);
            // 
            // UsernameBx
            // 
            this.UsernameBx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UsernameBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameBx.Location = new System.Drawing.Point(265, 224);
            this.UsernameBx.Name = "UsernameBx";
            this.UsernameBx.Size = new System.Drawing.Size(260, 26);
            this.UsernameBx.TabIndex = 2;
            // 
            // PasswordLbl
            // 
            this.PasswordLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordLbl.AutoSize = true;
            this.PasswordLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLbl.Location = new System.Drawing.Point(127, 294);
            this.PasswordLbl.Name = "PasswordLbl";
            this.PasswordLbl.Size = new System.Drawing.Size(82, 20);
            this.PasswordLbl.TabIndex = 3;
            this.PasswordLbl.Text = "Password:";
            this.PasswordLbl.Click += new System.EventHandler(this.PasswordLbl_Click);
            // 
            // PasswordBx
            // 
            this.PasswordBx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordBx.Location = new System.Drawing.Point(265, 288);
            this.PasswordBx.Name = "PasswordBx";
            this.PasswordBx.Size = new System.Drawing.Size(260, 26);
            this.PasswordBx.TabIndex = 4;
            // 
            // LoginBtn
            // 
            this.LoginBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginBtn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LoginBtn.Location = new System.Drawing.Point(208, 367);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(176, 29);
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
            this.ForgotPassLbl.Location = new System.Drawing.Point(238, 419);
            this.ForgotPassLbl.Name = "ForgotPassLbl";
            this.ForgotPassLbl.Size = new System.Drawing.Size(122, 17);
            this.ForgotPassLbl.TabIndex = 7;
            this.ForgotPassLbl.Text = "Forgot Password?";
            // 
            // InfoIcon
            // 
            this.InfoIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.InfoIcon.Image = ((System.Drawing.Image)(resources.GetObject("InfoIcon.Image")));
            this.InfoIcon.Location = new System.Drawing.Point(12, 409);
            this.InfoIcon.Name = "InfoIcon";
            this.InfoIcon.Size = new System.Drawing.Size(56, 40);
            this.InfoIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.InfoIcon.TabIndex = 6;
            this.InfoIcon.TabStop = false;
            // 
            // EgbinLogo
            // 
            this.EgbinLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EgbinLogo.Image = global::EgbinInstrumentInfoApp.Properties.Resources.egbin;
            this.EgbinLogo.Location = new System.Drawing.Point(35, 34);
            this.EgbinLogo.Name = "EgbinLogo";
            this.EgbinLogo.Size = new System.Drawing.Size(625, 159);
            this.EgbinLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.EgbinLogo.TabIndex = 0;
            this.EgbinLogo.TabStop = false;
            // 
            // Login
            // 
            this.AcceptButton = this.LoginBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.ForgotPassLbl);
            this.Controls.Add(this.InfoIcon);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.PasswordBx);
            this.Controls.Add(this.PasswordLbl);
            this.Controls.Add(this.UsernameBx);
            this.Controls.Add(this.UsernameLbl);
            this.Controls.Add(this.EgbinLogo);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Location = new System.Drawing.Point(50, 50);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.Resize += new System.EventHandler(this.Login_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.InfoIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EgbinLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox EgbinLogo;
        private System.Windows.Forms.Label UsernameLbl;
        private System.Windows.Forms.TextBox UsernameBx;
        private System.Windows.Forms.Label PasswordLbl;
        private System.Windows.Forms.TextBox PasswordBx;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.PictureBox InfoIcon;
        private System.Windows.Forms.Label ForgotPassLbl;
    }
}

