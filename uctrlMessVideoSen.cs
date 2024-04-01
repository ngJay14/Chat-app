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
    public partial class uctrlMessVideoSen : UserControl
    {
        public uctrlMessVideoSen()
        {
            InitializeComponent();
        }

        private string _vidPath;
        private string _time;

        public string VidPath
        {
            get { return _vidPath; }
            set { _vidPath = value; videoPlayer.URL = _vidPath; setVideoPlayer(); }
        }

        public string Time
        { 
            get { return _time; } 
            set {  _time = value; lbTime.Text = value; }
        }

        void setVideoPlayer()
        {
            videoPlayer.uiMode = "mini";
            videoPlayer.Ctlcontrols.stop();
        }
    }
}
