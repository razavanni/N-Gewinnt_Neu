using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace N_Gewinnt
{
    internal class Chip
    {
        public Ellipse Ball { get; set; }
        public Canvas Cvs { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public double diameter { get; set; }
        public double cellWidth { get; set; }
        public double X { get; set; }
        public double paddingX { get; set; }
        public double paddingY { get; set; }
        public int currentPlayer { get; set; }
        public int cols { get; set; }
        public int rows { get; set; }

        public Chip(int col, double cellWidth, double paddingX, double paddingY, int currentPlayer, Canvas c, int cols, int rows)
        {
            this.Column = col;
            this.Row = 0;
            this.diameter = 40;
            this.cellWidth = cellWidth;
            this.paddingX = paddingX;
            this.paddingY = paddingY;
            this.currentPlayer = currentPlayer;
            this.Cvs = c;
            this.cols = cols;
            this.rows = rows;

            Ball = new Ellipse
            {
                Width = diameter,
                Height = diameter,
                Fill = Brushes.Red,
                Stroke = Brushes.Black,
                StrokeThickness = 2,
            };

        }

        public void Draw(Canvas c, double column, double cellWidth)
        {
            if(Ball != null)
            {
                diameter = cellWidth;
                Ball.Width = diameter;
                Ball.Height = diameter;

                X = column * cellWidth + (cellWidth - diameter) / 2 + paddingX;

                Canvas.SetLeft(Ball, X);
                Canvas.SetTop(Ball, 0);

                c.Children.Add(Ball);
            }
        }

        // public void NewChip()
        // {
        //     if(currentPlayer == 1)
        //     {
        //         Ball.Fill = Brushes.Blue;
        //         currentPlayer = 2;
        //     }
        //     else if(currentPlayer == 2)
        //     {
        //         Ball.Fill = Brushes.Red;
        //         currentPlayer = 1;
        //     }
        // 
        //     double cellWidth = (SystemParameters.PrimaryScreenWidth * 0.7 - paddingX) / cols;
        //     int col = Column;
        // 
        //     Draw(Cvs, col, cellWidth);
        // }
    }
}
