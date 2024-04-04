namespace chatApp
{
    partial class uctrlMessVideoRec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uctrlMessVideoRec));
            this.lbTime = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pcAva = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.videoPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.pcAva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTime
            // 
            this.lbTime.BackColor = System.Drawing.Color.Transparent;
            this.lbTime.ForeColor = System.Drawing.Color.Gray;
            this.lbTime.Location = new System.Drawing.Point(218, 158);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(106, 15);
            this.lbTime.TabIndex = 6;
            this.lbTime.Text = "11:04:23 27/03/2024";
            // 
            // pcAva
            // 
            this.pcAva.ImageRotate = 0F;
            this.pcAva.Location = new System.Drawing.Point(16, 10);
            this.pcAva.Name = "pcAva";
            this.pcAva.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pcAva.Size = new System.Drawing.Size(40, 40);
            this.pcAva.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcAva.TabIndex = 5;
            this.pcAva.TabStop = false;
            // 
            // videoPlayer
            // 
            this.videoPlayer.Enabled = true;
            this.videoPlayer.Location = new System.Drawing.Point(62, 23);
            this.videoPlayer.Name = "videoPlayer";
            this.videoPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("videoPlayer.OcxState")));
            this.videoPlayer.Size = new System.Drawing.Size(150, 150);
            this.videoPlayer.TabIndex = 7;
            // 
            // uctrlMessVideoRec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.videoPlayer);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.pcAva);
            this.Name = "uctrlMessVideoRec";
            this.Size = new System.Drawing.Size(340, 182);
            ((System.ComponentModel.ISupportInitialize)(this.pcAva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lbTime;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pcAva;
        private AxWMPLib.AxWindowsMediaPlayer videoPlayer;
    }
}
