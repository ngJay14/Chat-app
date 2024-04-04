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
    public partial class uctrlUsers : UserControl
    {
        public uctrlUsers()
        {
            InitializeComponent();
        }

        private string _fullname;
        private string _username;
        private Image _ava;
        private Color _color;

        public string Fullname
        {
            get { return _fullname; }
            set { _fullname = value; lbFullname.Text = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; lbUsername.Text = value; }
        }

        public Image Ava
        { 
            get { return _ava; }
            set { _ava = value; pcAva.Image = value; } 
        }

        public Color Color
        { get { return _color; } set { _color = value; } }

        private void uctrlUsers_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = _color;
        }

        private void uctrlUsers_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }
    }
}
