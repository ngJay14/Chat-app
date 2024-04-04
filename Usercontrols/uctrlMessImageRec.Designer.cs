namespace chatApp
{
    partial class uctrlMessImageRec
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
            this.pcImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pcAva = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lbTime = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pcImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAva)).BeginInit();
            this.SuspendLayout();
            // 
            // pcImage
            // 
            this.pcImage.BorderRadius = 8;
            this.pcImage.ImageRotate = 0F;
            this.pcImage.Location = new System.Drawing.Point(59, 16);
            this.pcImage.Name = "pcImage";
            this.pcImage.Size = new System.Drawing.Size(150, 150);
            this.pcImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcImage.TabIndex = 1;
            this.pcImage.TabStop = false;
            // 
            // pcAva
            // 
            this.pcAva.ImageRotate = 0F;
            this.pcAva.Location = new System.Drawing.Point(13, 3);
            this.pcAva.Name = "pcAva";
            this.pcAva.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pcAva.Size = new System.Drawing.Size(40, 40);
            this.pcAva.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcAva.TabIndex = 2;
            this.pcAva.TabStop = false;
            // 
            // lbTime
            // 
            this.lbTime.BackColor = System.Drawing.Color.Transparent;
            this.lbTime.ForeColor = System.Drawing.Color.Gray;
            this.lbTime.Location = new System.Drawing.Point(215, 151);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(106, 15);
            this.lbTime.TabIndex = 3;
            this.lbTime.Text = "11:04:23 27/03/2024";
            // 
            // uctrlMessImageRec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.pcAva);
            this.Controls.Add(this.pcImage);
            this.Name = "uctrlMessImageRec";
            this.Size = new System.Drawing.Size(338, 178);
            ((System.ComponentModel.ISupportInitialize)(this.pcImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAva)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox pcImage;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pcAva;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbTime;
    }
}
