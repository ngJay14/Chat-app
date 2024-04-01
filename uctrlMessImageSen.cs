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
    public partial class uctrlMessImageSen : UserControl
    {
        public uctrlMessImageSen()
        {
            InitializeComponent();
        }

        private Image _image;
        private string _time;

        public Image Image
        {
            get { return _image; }
            set { _image = value; pcImage.Image = value; }
        }
        public string Time
        {
            get { return _time; }
            set { _time = value; lbTime.Text = value; }
        }
    }
}
