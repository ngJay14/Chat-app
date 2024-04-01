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
    public partial class uctrlMessVideoRec : UserControl
    {
        public uctrlMessVideoRec()
        {
            InitializeComponent();
        }

        private string _vidPath;
        private string _time;
        private Image _ava;

        public Image Ava
        {
            get { return _ava; }
            set { _ava = value; pcAva.Image = value; }
        }
        public string VidPath
        {
            get { return _vidPath; }
            set { _vidPath = value; videoPlayer.URL = _vidPath; setVideoPlayer(); }
        }

        public string Time
        {
            get { return _time; }
            set { _time = value; lbTime.Text = value; }
        }

        void setVideoPlayer()
        {
            videoPlayer.uiMode = "mini";
            videoPlayer.Ctlcontrols.stop();
        }
    }
}
