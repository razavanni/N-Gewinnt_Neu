using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace N_Gewinnt
{
    internal class Chip
    {
        public Ellipse Ball { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public double diameter { get; set; }

        public Chip(int col)
        {
            this.Column = col;
            Row = 0;
            diameter = 40;

            Ball = new Ellipse
            {
                Width = 40,
                Height = 40,
                Fill = Brushes.Red,
                Stroke = Brushes.Black,
                StrokeThickness = 2,
            };
        }
    }
}
