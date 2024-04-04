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
    public partial class uctrlImage : UserControl
    {
        public uctrlImage()
        {
            InitializeComponent();
        }

        private Image _image;

        public Image Image
        { get { return _image; } set {  _image = value; pcImage.Image = value; } }
    }
}
