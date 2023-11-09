using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace N_Gewinnt
{
    internal class Spielfeld
    {
        Chip chip;

        public double boardHeight { get; set; }
        public double cellWidth { get; set; }
        public double screenWidth { get; set; }
        public double screenHeight { get; set; }
        public double maxBoardHeight { get; set; }
        public int columns { get; set; }
        public int rows { get; set; }
        public double paddingX { get; set; }
        public double paddingY { get; set; }
        public Canvas Cvs { get; set; }
        public int currentPlayer { get; set; }
        public double cellHeight { get; set; }

        public Spielfeld(int columns, int rows, double paddingX, double paddingY, Canvas c, int currentPlayer)
        {
            this.columns = columns;
            this.rows = rows;
            this.paddingX = paddingX;
            this.paddingY = paddingY;
            this.Cvs = c;
            this.currentPlayer = currentPlayer;

            chip = new Chip(0, cellWidth, paddingX, paddingY, currentPlayer, Cvs, columns, rows);
            // chip.Draw(Cvs, 0, cellWidth);
        }

        public void Draw(Canvas c)
        {
            screenWidth = SystemParameters.PrimaryScreenWidth;
            screenHeight = SystemParameters.PrimaryScreenHeight;

            cellWidth = (screenWidth * 0.9 - paddingX) / columns;
            cellHeight = (screenHeight * 0.9  - paddingY) / columns;
            maxBoardHeight = screenHeight * 0.9;

            boardHeight = rows * chip.diameter;

            if (boardHeight > maxBoardHeight)
            {
                boardHeight = maxBoardHeight;
            }

            // Vertikale Linie
            for (int col = 0; col <= columns; col++)
            {
                Line verticalLine = new Line
                {
                    X1 = paddingX + col * cellWidth,
                    X2 = paddingX + col * cellWidth,

                    Y1 = paddingY,
                    Y2 = paddingY + boardHeight,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };

                c.Children.Add(verticalLine);
            }

            // Horizontale Linie
            Line horizontalLine = new Line
            {
                X1 = paddingX,
                X2 = paddingX + columns * cellWidth,

                Y1 = paddingY + boardHeight,
                Y2 = paddingY + boardHeight,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };

            c.Children.Add(horizontalLine);
        }
    }
}
