using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatApp
{
    internal class lightmode1
    {
        private Color c1 = ColorTranslator.FromHtml("#00A9FF");
        private Color c2 = ColorTranslator.FromHtml("#89CFF3");
        private Color c3 = ColorTranslator.FromHtml("#A0E9FF");
        private Color c4 = ColorTranslator.FromHtml("#CDF5FD");

        public Color C1 { get { return c1; } set {  c1 = value; } }
        public Color C2 { get { return c2; } set { c2 = value; } }
        public Color C3 { get { return c3;} set { c3 = value; } }
        public Color C4 { get { return c4;} set { c4 = value; } }
    }
}
