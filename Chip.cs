using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace N_Gewinnt
{
    internal class Chip
    {
        public Ellipse Ball { get; set; }
        public Canvas Cvs { get; set; }
        public MainWindow Wnd { get; set; }
        public Spielfeld spielfeld { get; set; }

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
            if (Ball != null)
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

        public void MoveLeft()
        {
            if (Ball != null)
            {
                if (Column > 0)
                {
                    Column--;
                    double cellWidth = (SystemParameters.PrimaryScreenWidth * 0.9 - paddingX) / cols;
                    double chipX = Column * cellWidth + (cellWidth - Ball.Width) / 2 + paddingX;
                    Canvas.SetLeft(Ball, chipX);
                }
            }
        }
        public void MoveRight()
        {
            if (Ball != null)
            {
                if (Column < cols - 1)
                {
                    Column++;
                    double cellWidth = (SystemParameters.PrimaryScreenWidth * 0.9 - paddingX) / cols;
                    double chipX = Column * cellWidth + (cellWidth - Ball.Width) / 2 + paddingX;
                    Canvas.SetLeft(Ball, chipX);
                }
            }
        }
        public void MoveDown()
        {
            double screenHeight = SystemParameters.PrimaryScreenHeight * 0.9;
            double chipHeight = Ball.Height;

            int targetRow = 0;

            for (int row = 0; row < rows; row++)
            {
                double rowTop = paddingY + row * (screenHeight * 0.9) / rows;
                if (rowTop > Canvas.GetTop(Ball))
                {
                    break;
                }
                targetRow = row;
            }

            int col = Column;

            Wnd.usedSpaces[col]++;

            DoubleAnimation animation = new DoubleAnimation
            {
                From = Canvas.GetTop(Ball),
                To = paddingY + spielfeld.boardHeight - chipHeight * Wnd.usedSpaces[col],
                Duration = TimeSpan.FromSeconds(0.5)
            };

            animation.Completed += (sender, e) =>
            {
                Wnd.isAnimating = false;

                if (Canvas.GetTop(Ball) > screenHeight - chipHeight * Wnd.usedSpaces[col])
                {
                    // NEw ball
                }
            };

            Ball.BeginAnimation(Canvas.TopProperty, animation);
        }
    }
}
