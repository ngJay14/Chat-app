using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chatApp
{
    public partial class uctrlMessTextSen : UserControl
    {
        public uctrlMessTextSen()
        {
            InitializeComponent();
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value; richTxtMessage.Text = value; setSizeofRichTextbox(); }
        }

        private string _time;

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

            this.Size = new Size(richTxtMessage.Width + lbTime.Width + 15, richTxtMessage.Height + lbTime.Height + 2);


            lbTime.Location = new Point(0, richTxtMessage.Height);
            richTxtMessage.Location = new Point(lbTime.Width + 15, lbTime.Height + 2);
        }

        public bool searchMess (string text)
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
                else { break;}
            }

            if (count == 0) { return false; }
            else
                return true;
            
        }

        public void unSearchMess ()
        {
            richTxtMessage.SelectAll();
            richTxtMessage.SelectionBackColor = Color.White;
            richTxtMessage.SelectionLength = 0;

        }

    }
}
