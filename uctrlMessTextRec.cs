using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace chatApp
{
    public partial class uctrlMessTextRec : UserControl
    {
        public uctrlMessTextRec()
        {
            InitializeComponent();
        }

        private string _message;
        private Image _ava;
        private string _time;

        public string Message
        {
            get { return _message; }
            set { _message = value; richTxtMessage.Text = value; setSizeofRichTextbox(); }
        }

        public Image Ava
        { 
            get { return _ava; } 
            set { _ava = value; pcAva.Image = value; } 
        }

        public string Time
        {
            get { return _time; }
            set { _time = value; lbTime.Text = value; }
        }

        void setSizeofRichTextbox()
        {
            lbMessage.Visible = false;
            lbMessage.Text = _message;

            int width = lbMessage.Width;
            int height = lbMessage.Height;
            int padding = 10;

            richTxtMessage.Size = new Size(width + padding, height + 5);
            richTxtMessage.BorderStyle = BorderStyle.None;
            richTxtMessage.Cursor = Cursors.Arrow;

            this.Width = richTxtMessage.Width + lbTime.Width + pcAva.Width + 15;
            this.Height = richTxtMessage.Height + lbTime.Height + pcAva.Height + 2;

            lbMessage.Location = new Point(10, 10);

            lbTime.Location = new Point(richTxtMessage.Location.X + richTxtMessage.Width + 5, richTxtMessage.Location.Y + richTxtMessage.Height - 17);
        }

        public bool searchMess(string text)
        {
            unSearchMess();

            int count = 0;
            int start = 0;
            int end = richTxtMessage.Text.Length;
            while (true)
            {
                int pos = richTxtMessage.Find(text, start, end, RichTextBoxFinds.None);
                if (pos != -1)
                {
                    richTxtMessage.SelectionStart = pos;
                    richTxtMessage.SelectionLength = text.Length;
                    richTxtMessage.SelectionBackColor = Color.Aqua;
                    start = pos + 1;
                    count++;
                    richTxtMessage.SelectionStart = 0;
                    richTxtMessage.SelectionLength = 0;

                }
                else { break; }
            }

            if (count == 0) { return false; }
            else
                return true;

        }

        public void unSearchMess()
        {
            richTxtMessage.SelectAll();
            richTxtMessage.SelectionBackColor = Color.White;
            richTxtMessage.SelectionLength = 0;

        }

    }
}
