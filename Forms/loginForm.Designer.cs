namespace chatApp
{
    partial class loginForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginForm));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnLogin = new System.Windows.Forms.Panel();
            this.pnForgetPass = new System.Windows.Forms.Panel();
            this.pcReturn = new System.Windows.Forms.PictureBox();
            this.lbDesForPass = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbForPass = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnSend = new Guna.UI2.WinForms.Guna2Button();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.lnkLbForgetPass = new System.Windows.Forms.LinkLabel();
            this.lnkLbLogup = new System.Windows.Forms.LinkLabel();
            this.lbQues = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbLogin = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnLogin = new Guna.UI2.WinForms.Guna2Button();
            this.txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pcBanner = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnLogin.SuspendLayout();
            this.pnForgetPass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcBanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pnLogin
            // 
            this.pnLogin.Controls.Add(this.pnForgetPass);
            this.pnLogin.Controls.Add(this.lnkLbForgetPass);
            this.pnLogin.Controls.Add(this.lnkLbLogup);
            this.pnLogin.Controls.Add(this.lbQues);
            this.pnLogin.Controls.Add(this.txtPassword);
            this.pnLogin.Controls.Add(this.lbLogin);
            this.pnLogin.Controls.Add(this.btnLogin);
            this.pnLogin.Controls.Add(this.txtUsername);
            this.pnLogin.Location = new System.Drawing.Point(558, 134);
            this.pnLogin.Name = "pnLogin";
            this.pnLogin.Size = new System.Drawing.Size(306, 378);
            this.pnLogin.TabIndex = 25;
            // 
            // pnForgetPass
            // 
            this.pnForgetPass.Controls.Add(this.pcReturn);
            this.pnForgetPass.Controls.Add(this.lbDesForPass);
            this.pnForgetPass.Controls.Add(this.lbForPass);
            this.pnForgetPass.Controls.Add(this.btnSend);
            this.pnForgetPass.Controls.Add(this.txtEmail);
            this.pnForgetPass.Location = new System.Drawing.Point(0, 3);
            this.pnForgetPass.Name = "pnForgetPass";
            this.pnForgetPass.Size = new System.Drawing.Size(306, 372);
            this.pnForgetPass.TabIndex = 26;
            // 
            // pcReturn
            // 
            this.pcReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pcReturn.Image = global::chatApp.Properties.Resources._return;
            this.pcReturn.Location = new System.Drawing.Point(277, 7);
            this.pcReturn.Margin = new System.Windows.Forms.Padding(4);
            this.pcReturn.Name = "pcReturn";
            this.pcReturn.Size = new System.Drawing.Size(25, 25);
            this.pcReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcReturn.TabIndex = 29;
            this.pcReturn.TabStop = false;
            this.pcReturn.Click += new System.EventHandler(this.pcReturn_Click);
            // 
            // lbDesForPass
            // 
            this.lbDesForPass.AutoSize = false;
            this.lbDesForPass.BackColor = System.Drawing.Color.Transparent;
            this.lbDesForPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDesForPass.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbDesForPass.Location = new System.Drawing.Point(36, 86);
            this.lbDesForPass.Margin = new System.Windows.Forms.Padding(4);
            this.lbDesForPass.Name = "lbDesForPass";
            this.lbDesForPass.Size = new System.Drawing.Size(234, 48);
            this.lbDesForPass.TabIndex = 28;
            this.lbDesForPass.Text = "Please enter your email and we will send password to your email address\r\n";
            this.lbDesForPass.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbForPass
            // 
            this.lbForPass.BackColor = System.Drawing.Color.Transparent;
            this.lbForPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbForPass.Location = new System.Drawing.Point(48, 40);
            this.lbForPass.Margin = new System.Windows.Forms.Padding(4);
            this.lbForPass.Name = "lbForPass";
            this.lbForPass.Size = new System.Drawing.Size(221, 33);
            this.lbForPass.TabIndex = 27;
            this.lbForPass.Text = "Forget password";
            // 
            // btnSend
            // 
            this.btnSend.BorderRadius = 5;
            this.btnSend.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSend.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSend.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSend.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(54, 203);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(201, 50);
            this.btnSend.TabIndex = 26;
            this.btnSend.Text = "Send";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.BorderRadius = 5;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Location = new System.Drawing.Point(19, 143);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PlaceholderText = "Email";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(272, 41);
            this.txtEmail.TabIndex = 24;
            // 
            // lnkLbForgetPass
            // 
            this.lnkLbForgetPass.AutoSize = true;
            this.lnkLbForgetPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkLbForgetPass.Location = new System.Drawing.Point(74, 298);
            this.lnkLbForgetPass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkLbForgetPass.Name = "lnkLbForgetPass";
            this.lnkLbForgetPass.Size = new System.Drawing.Size(152, 17);
            this.lnkLbForgetPass.TabIndex = 30;
            this.lnkLbForgetPass.TabStop = true;
            this.lnkLbForgetPass.Text = "Forget your passwod ?";
            this.lnkLbForgetPass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLbForgetPass_LinkClicked);
            // 
            // lnkLbLogup
            // 
            this.lnkLbLogup.AutoSize = true;
            this.lnkLbLogup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkLbLogup.Location = new System.Drawing.Point(199, 261);
            this.lnkLbLogup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkLbLogup.Name = "lnkLbLogup";
            this.lnkLbLogup.Size = new System.Drawing.Size(56, 17);
            this.lnkLbLogup.TabIndex = 29;
            this.lnkLbLogup.TabStop = true;
            this.lnkLbLogup.Text = "Sign up";
            this.lnkLbLogup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLbLogup_LinkClicked);
            // 
            // lbQues
            // 
            this.lbQues.BackColor = System.Drawing.Color.Transparent;
            this.lbQues.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQues.Location = new System.Drawing.Point(48, 261);
            this.lbQues.Margin = new System.Windows.Forms.Padding(4);
            this.lbQues.Name = "lbQues";
            this.lbQues.Size = new System.Drawing.Size(148, 18);
            this.lbQues.TabIndex = 28;
            this.lbQues.Text = "Dont\'t have an account ?";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderRadius = 5;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.Location = new System.Drawing.Point(16, 125);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.PlaceholderText = "Password";
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(272, 41);
            this.txtPassword.TabIndex = 25;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lbLogin
            // 
            this.lbLogin.BackColor = System.Drawing.Color.Transparent;
            this.lbLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLogin.Location = new System.Drawing.Point(109, 10);
            this.lbLogin.Margin = new System.Windows.Forms.Padding(4);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(82, 33);
            this.lbLogin.TabIndex = 27;
            this.lbLogin.Text = "Log in";
            // 
            // btnLogin
            // 
            this.btnLogin.BorderRadius = 5;
            this.btnLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(51, 189);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(201, 50);
            this.btnLogin.TabIndex = 26;
            this.btnLogin.Text = "Log in";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.BorderRadius = 5;
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.DefaultText = "";
            this.txtUsername.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUsername.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUsername.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUsername.ForeColor = System.Drawing.Color.Black;
            this.txtUsername.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUsername.Location = new System.Drawing.Point(16, 74);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '\0';
            this.txtUsername.PlaceholderText = "Username";
            this.txtUsername.SelectedText = "";
            this.txtUsername.Size = new System.Drawing.Size(272, 41);
            this.txtUsername.TabIndex = 24;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::chatApp.Properties.Resources.logo_removebg_preview;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(588, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(243, 105);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // pcBanner
            // 
            this.pcBanner.BackColor = System.Drawing.Color.Transparent;
            this.pcBanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcBanner.Location = new System.Drawing.Point(0, 0);
            this.pcBanner.Name = "pcBanner";
            this.pcBanner.Size = new System.Drawing.Size(550, 550);
            this.pcBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcBanner.TabIndex = 24;
            this.pcBanner.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::chatApp.Properties.Resources.exit1;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(839, 13);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            this.pictureBox2.MouseHover += new System.EventHandler(this.pictureBox2_MouseHover);
            // 
            // loginForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(874, 549);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnLogin);
            this.Controls.Add(this.pcBanner);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "loginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log in";
            this.Load += new System.EventHandler(this.loginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnLogin.ResumeLayout(false);
            this.pnLogin.PerformLayout();
            this.pnForgetPass.ResumeLayout(false);
            this.pnForgetPass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcBanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pcBanner;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel pnLogin;
        private System.Windows.Forms.LinkLabel lnkLbForgetPass;
        private System.Windows.Forms.LinkLabel lnkLbLogup;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbQues;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbLogin;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private System.Windows.Forms.Panel pnForgetPass;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbDesForPass;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbForPass;
        private Guna.UI2.WinForms.Guna2Button btnSend;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private System.Windows.Forms.PictureBox pcReturn;
    }
}