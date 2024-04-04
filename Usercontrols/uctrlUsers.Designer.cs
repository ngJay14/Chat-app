namespace chatApp
{
    partial class uctrlUsers
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pcAva = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lbUsername = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbFullname = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pcAva)).BeginInit();
            this.SuspendLayout();
            // 
            // pcAva
            // 
            this.pcAva.FillColor = System.Drawing.Color.Gainsboro;
            this.pcAva.ImageRotate = 0F;
            this.pcAva.Location = new System.Drawing.Point(35, 16);
            this.pcAva.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pcAva.Name = "pcAva";
            this.pcAva.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pcAva.Size = new System.Drawing.Size(85, 79);
            this.pcAva.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcAva.TabIndex = 0;
            this.pcAva.TabStop = false;
            // 
            // lbUsername
            // 
            this.lbUsername.BackColor = System.Drawing.Color.Transparent;
            this.lbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsername.Location = new System.Drawing.Point(141, 32);
            this.lbUsername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(85, 22);
            this.lbUsername.TabIndex = 1;
            this.lbUsername.Text = "Username";
            // 
            // lbFullname
            // 
            this.lbFullname.BackColor = System.Drawing.Color.Transparent;
            this.lbFullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFullname.Location = new System.Drawing.Point(141, 66);
            this.lbFullname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbFullname.Name = "lbFullname";
            this.lbFullname.Size = new System.Drawing.Size(48, 15);
            this.lbFullname.TabIndex = 2;
            this.lbFullname.Text = "Full name";
            // 
            // uctrlUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lbFullname);
            this.Controls.Add(this.lbUsername);
            this.Controls.Add(this.pcAva);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "uctrlUsers";
            this.Size = new System.Drawing.Size(400, 111);
            this.MouseLeave += new System.EventHandler(this.uctrlUsers_MouseLeave);
            this.MouseHover += new System.EventHandler(this.uctrlUsers_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.pcAva)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox pcAva;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbUsername;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbFullname;
    }
}
