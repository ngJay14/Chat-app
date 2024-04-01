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
    public partial class uctrlVideos : UserControl
    {
        public uctrlVideos()
        {
            InitializeComponent();
        }

        private String _vidPath;

        public String VidPath
        { get { return _vidPath; } set { _vidPath = value; videoPlayer.URL = value; setVidPlayer(); } }

        void setVidPlayer()
        {
            videoPlayer.uiMode = "mini";
            videoPlayer.Ctlcontrols.stop();
        }
    }
}
