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
    public partial class uctrlMessIconSen : UserControl
    {
        public uctrlMessIconSen()
        {
            InitializeComponent();
        }

        private Image _icon;
        private string _time;

        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; pcIcon.Image = _icon; }
        }
        public string Time
        {
            get { return _time; }
            set { _time = value; lbTime.Text = value; }
        }
    }
}
