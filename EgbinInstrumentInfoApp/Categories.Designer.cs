using System.Windows.Forms;
namespace EgbinInstrumentInfoApp
{
    partial class Categories
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Categories));
            this.HeaderPnl = new System.Windows.Forms.Panel();
            this.FullnameLbl = new System.Windows.Forms.Label();
            this.ProfilePic = new System.Windows.Forms.PictureBox();
            this.MenuIcon = new System.Windows.Forms.PictureBox();
            this.EgbinPic = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.AddNewPanel = new System.Windows.Forms.Panel();
            this.newLbl = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.DeptLbl = new System.Windows.Forms.Label();
            this.WelcomePagePanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Backpic = new System.Windows.Forms.PictureBox();
            this.MenuPnl = new System.Windows.Forms.Panel();
            this.HelpOptn = new System.Windows.Forms.Button();
            this.AboutOptn = new System.Windows.Forms.Button();
            this.LogoutOptn = new System.Windows.Forms.Button();
            this.DepartmentsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.HeaderPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EgbinPic)).BeginInit();
            this.panel4.SuspendLayout();
            this.AddNewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.WelcomePagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Backpic)).BeginInit();
            this.MenuPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeaderPnl
            // 
            this.HeaderPnl.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.HeaderPnl.Controls.Add(this.FullnameLbl);
            this.HeaderPnl.Controls.Add(this.ProfilePic);
            this.HeaderPnl.Controls.Add(this.MenuIcon);
            this.HeaderPnl.Controls.Add(this.EgbinPic);
            this.HeaderPnl.Location = new System.Drawing.Point(12, 12);
            this.HeaderPnl.Name = "HeaderPnl";
            this.HeaderPnl.Size = new System.Drawing.Size(1134, 62);
            this.HeaderPnl.TabIndex = 2;
            // 
            // FullnameLbl
            // 
            this.FullnameLbl.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FullnameLbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.FullnameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FullnameLbl.ForeColor = System.Drawing.SystemColors.Control;
            this.FullnameLbl.Location = new System.Drawing.Point(845, 0);
            this.FullnameLbl.Name = "FullnameLbl";
            this.FullnameLbl.Size = new System.Drawing.Size(223, 62);
            this.FullnameLbl.TabIndex = 15;
            this.FullnameLbl.Text = "SURNAME, FIRSTNAME";
            this.FullnameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.FullnameLbl.Click += new System.EventHandler(this.FullnameLbl_Click);
            // 
            // ProfilePic
            // 
            this.ProfilePic.Dock = System.Windows.Forms.DockStyle.Right;
            this.ProfilePic.Image = ((System.Drawing.Image)(resources.GetObject("ProfilePic.Image")));
            this.ProfilePic.Location = new System.Drawing.Point(1068, 0);
            this.ProfilePic.Name = "ProfilePic";
            this.ProfilePic.Size = new System.Drawing.Size(66, 62);
            this.ProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProfilePic.TabIndex = 14;
            this.ProfilePic.TabStop = false;
            // 
            // MenuIcon
            // 
            this.MenuIcon.Image = ((System.Drawing.Image)(resources.GetObject("MenuIcon.Image")));
            this.MenuIcon.Location = new System.Drawing.Point(3, 3);
            this.MenuIcon.Name = "MenuIcon";
            this.MenuIcon.Size = new System.Drawing.Size(55, 43);
            this.MenuIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MenuIcon.TabIndex = 27;
            this.MenuIcon.TabStop = false;
            this.MenuIcon.Click += new System.EventHandler(this.MenuIcon_Click);
            // 
            // EgbinPic
            // 
            this.EgbinPic.Image = ((System.Drawing.Image)(resources.GetObject("EgbinPic.Image")));
            this.EgbinPic.Location = new System.Drawing.Point(64, 3);
            this.EgbinPic.Name = "EgbinPic";
            this.EgbinPic.Size = new System.Drawing.Size(100, 43);
            this.EgbinPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.EgbinPic.TabIndex = 1;
            this.EgbinPic.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel4.Controls.Add(this.AddNewPanel);
            this.panel4.Controls.Add(this.DeptLbl);
            this.panel4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel4.Location = new System.Drawing.Point(12, 80);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(279, 48);
            this.panel4.TabIndex = 0;
            // 
            // AddNewPanel
            // 
            this.AddNewPanel.Controls.Add(this.newLbl);
            this.AddNewPanel.Controls.Add(this.pictureBox6);
            this.AddNewPanel.Location = new System.Drawing.Point(182, 3);
            this.AddNewPanel.Name = "AddNewPanel";
            this.AddNewPanel.Size = new System.Drawing.Size(97, 45);
            this.AddNewPanel.TabIndex = 1;
            // 
            // newLbl
            // 
            this.newLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newLbl.ForeColor = System.Drawing.SystemColors.Control;
            this.newLbl.Location = new System.Drawing.Point(38, 6);
            this.newLbl.Name = "newLbl";
            this.newLbl.Size = new System.Drawing.Size(50, 36);
            this.newLbl.TabIndex = 2;
            this.newLbl.Text = "New";
            this.newLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.newLbl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.newLbl_MouseDown);
            this.newLbl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.newLbl_MouseUp);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(3, 3);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(43, 39);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 1;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox6_MouseDown);
            this.pictureBox6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox6_MouseUp);
            // 
            // DeptLbl
            // 
            this.DeptLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeptLbl.ForeColor = System.Drawing.SystemColors.Control;
            this.DeptLbl.Location = new System.Drawing.Point(18, 12);
            this.DeptLbl.Name = "DeptLbl";
            this.DeptLbl.Size = new System.Drawing.Size(171, 27);
            this.DeptLbl.TabIndex = 0;
            this.DeptLbl.Text = "DEPARTMENTS";
            // 
            // WelcomePagePanel
            // 
            this.WelcomePagePanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.WelcomePagePanel.Controls.Add(this.pictureBox1);
            this.WelcomePagePanel.Controls.Add(this.label3);
            this.WelcomePagePanel.Controls.Add(this.label2);
            this.WelcomePagePanel.Controls.Add(this.label1);
            this.WelcomePagePanel.Controls.Add(this.Backpic);
            this.WelcomePagePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomePagePanel.Location = new System.Drawing.Point(297, 80);
            this.WelcomePagePanel.Name = "WelcomePagePanel";
            this.WelcomePagePanel.Padding = new System.Windows.Forms.Padding(10);
            this.WelcomePagePanel.Size = new System.Drawing.Size(849, 519);
            this.WelcomePagePanel.TabIndex = 4;
            this.WelcomePagePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.CategoryInfoPnl_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::EgbinInstrumentInfoApp.Properties.Resources.iilogo;
            this.pictureBox1.Location = new System.Drawing.Point(261, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 214);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(69, 396);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(322, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "Please select a department";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(139, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(644, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "All equipment maintenance records are at your disposal";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(553, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to Instrument Information!";
            // 
            // Backpic
            // 
            this.Backpic.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Backpic.Image = ((System.Drawing.Image)(resources.GetObject("Backpic.Image")));
            this.Backpic.Location = new System.Drawing.Point(13, 386);
            this.Backpic.Name = "Backpic";
            this.Backpic.Size = new System.Drawing.Size(62, 52);
            this.Backpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Backpic.TabIndex = 11;
            this.Backpic.TabStop = false;
            // 
            // MenuPnl
            // 
            this.MenuPnl.BackColor = System.Drawing.SystemColors.MenuBar;
            this.MenuPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MenuPnl.Controls.Add(this.HelpOptn);
            this.MenuPnl.Controls.Add(this.AboutOptn);
            this.MenuPnl.Controls.Add(this.LogoutOptn);
            this.MenuPnl.Location = new System.Drawing.Point(12, 64);
            this.MenuPnl.Name = "MenuPnl";
            this.MenuPnl.Size = new System.Drawing.Size(113, 111);
            this.MenuPnl.TabIndex = 2;
            this.MenuPnl.Visible = false;
            // 
            // HelpOptn
            // 
            this.HelpOptn.BackColor = System.Drawing.SystemColors.Menu;
            this.HelpOptn.Location = new System.Drawing.Point(7, 74);
            this.HelpOptn.Name = "HelpOptn";
            this.HelpOptn.Size = new System.Drawing.Size(97, 32);
            this.HelpOptn.TabIndex = 2;
            this.HelpOptn.Text = "Help";
            this.HelpOptn.UseVisualStyleBackColor = false;
            // 
            // AboutOptn
            // 
            this.AboutOptn.BackColor = System.Drawing.SystemColors.Menu;
            this.AboutOptn.Location = new System.Drawing.Point(8, 39);
            this.AboutOptn.Name = "AboutOptn";
            this.AboutOptn.Size = new System.Drawing.Size(97, 32);
            this.AboutOptn.TabIndex = 1;
            this.AboutOptn.Text = "About";
            this.AboutOptn.UseVisualStyleBackColor = false;
            this.AboutOptn.Click += new System.EventHandler(this.AboutOptn_Click);
            // 
            // LogoutOptn
            // 
            this.LogoutOptn.BackColor = System.Drawing.SystemColors.Menu;
            this.LogoutOptn.Location = new System.Drawing.Point(8, 6);
            this.LogoutOptn.Name = "LogoutOptn";
            this.LogoutOptn.Size = new System.Drawing.Size(97, 32);
            this.LogoutOptn.TabIndex = 0;
            this.LogoutOptn.Text = "Sign Out";
            this.LogoutOptn.UseVisualStyleBackColor = false;
            this.LogoutOptn.Click += new System.EventHandler(this.LogoutOptn_Click);
            // 
            // DepartmentsFlowLayoutPanel
            // 
            this.DepartmentsFlowLayoutPanel.AutoScroll = true;
            this.DepartmentsFlowLayoutPanel.Location = new System.Drawing.Point(12, 135);
            this.DepartmentsFlowLayoutPanel.Name = "DepartmentsFlowLayoutPanel";
            this.DepartmentsFlowLayoutPanel.Size = new System.Drawing.Size(279, 383);
            this.DepartmentsFlowLayoutPanel.TabIndex = 5;
            // 
            // Categories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1158, 614);
            this.Controls.Add(this.MenuPnl);
            this.Controls.Add(this.DepartmentsFlowLayoutPanel);
            this.Controls.Add(this.WelcomePagePanel);
            this.Controls.Add(this.HeaderPnl);
            this.Controls.Add(this.panel4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1174, 653);
            this.Name = "Categories";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Categories";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Categories_FormClosed);
            this.Load += new System.EventHandler(this.Categories_Load);
            this.Resize += new System.EventHandler(this.Categories_Resize);
            this.HeaderPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EgbinPic)).EndInit();
            this.panel4.ResumeLayout(false);
            this.AddNewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.WelcomePagePanel.ResumeLayout(false);
            this.WelcomePagePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Backpic)).EndInit();
            this.MenuPnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel HeaderPnl;
        private System.Windows.Forms.PictureBox EgbinPic;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label DeptLbl;
        private System.Windows.Forms.PictureBox ProfilePic;
        private System.Windows.Forms.PictureBox Backpic;
        private System.Windows.Forms.Panel WelcomePagePanel;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label newLbl;
        private System.Windows.Forms.Panel AddNewPanel;
        private System.Windows.Forms.PictureBox MenuIcon;
        private System.Windows.Forms.Panel MenuPnl;
        private System.Windows.Forms.Button HelpOptn;
        private System.Windows.Forms.Button AboutOptn;
        private System.Windows.Forms.Button LogoutOptn;
        private FlowLayoutPanel DepartmentsFlowLayoutPanel;
        private Label FullnameLbl;
        private Label label1;
        private Label label3;
        private Label label2;
        private PictureBox pictureBox1;
    }
}