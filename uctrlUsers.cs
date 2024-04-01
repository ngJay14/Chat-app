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
    }
}
