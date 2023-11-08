using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Colorado
{
    public class ColorItem
    {
        public string Imya { get; set; }
        public SolidColorBrush color { get; set; }
        public byte Alpha { get; set; }
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }

        public ColorItem(byte alpha, byte red, byte green, byte blue)
        {
            Alpha = alpha;
            Red = red;
            Green = green;
            Blue = blue;
            Imya = "A: " + alpha.ToString() + "; R:" + red.ToString() + "; G:" + green.ToString() + "; B:" + blue.ToString();
            color = new SolidColorBrush(Color.FromArgb(alpha, red, green, blue));
        }

    }
}
