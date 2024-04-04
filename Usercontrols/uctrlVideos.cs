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

        private void setVidPlayer()
        {
            videoPlayer.uiMode = "mini";
            videoPlayer.Ctlcontrols.stop();
        }

        public void minimize(int width, int height, string mode)
        {
            videoPlayer.Size = new Size(width, height);
            videoPlayer.uiMode=mode;
            videoPlayer.Ctlcontrols.play();
        }
    }
}
