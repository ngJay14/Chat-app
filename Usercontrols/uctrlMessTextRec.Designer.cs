namespace chatApp
{
    partial class uctrlMessTextRec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uctrlMessTextRec));
            this.lbTime = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pcAva = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lbMessage = new System.Windows.Forms.Label();
            this.richTxtMessage = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcAva)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTime
            // 
            this.lbTime.BackColor = System.Drawing.Color.Transparent;
            this.lbTime.ForeColor = System.Drawing.Color.Gray;
            this.lbTime.Location = new System.Drawing.Point(317, 155);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(106, 15);
            this.lbTime.TabIndex = 2;
            this.lbTime.Text = "11:04:23 27/03/2024";
            // 
            // pcAva
            // 
            this.pcAva.ImageRotate = 0F;
            this.pcAva.Location = new System.Drawing.Point(14, 13);
            this.pcAva.Name = "pcAva";
            this.pcAva.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pcAva.Size = new System.Drawing.Size(40, 40);
            this.pcAva.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcAva.TabIndex = 1;
            this.pcAva.TabStop = false;
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMessage.Location = new System.Drawing.Point(61, 13);
            this.lbMessage.MaximumSize = new System.Drawing.Size(250, 0);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(250, 180);
            this.lbMessage.TabIndex = 4;
            this.lbMessage.Text = resources.GetString("lbMessage.Text");
            // 
            // richTxtMessage
            // 
            this.richTxtMessage.BackColor = System.Drawing.Color.White;
            this.richTxtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTxtMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTxtMessage.Location = new System.Drawing.Point(61, 26);
            this.richTxtMessage.Name = "richTxtMessage";
            this.richTxtMessage.Size = new System.Drawing.Size(250, 144);
            this.richTxtMessage.TabIndex = 5;
            this.richTxtMessage.Text = "";
            // 
            // uctrlMessTextRec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.pcAva);
            this.Controls.Add(this.richTxtMessage);
            this.Controls.Add(this.lbMessage);
            this.MaximumSize = new System.Drawing.Size(450, 0);
            this.Name = "uctrlMessTextRec";
            this.Size = new System.Drawing.Size(450, 193);
            ((System.ComponentModel.ISupportInitialize)(this.pcAva)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2CirclePictureBox pcAva;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbTime;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.RichTextBox richTxtMessage;
    }
}
