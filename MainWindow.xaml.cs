using System.Windows;
using System.Windows.Input;

namespace N_Gewinnt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StartWindow dlg;
        Spielfeld spielfeld;
        Chip chip;


        public int cols { get; set; }
        public int rows { get; set; }
        public int n { get; set; }
        public int currentPlayer = 1;
        public double paddingX { get; set; }
        public double paddingY { get; set; }
        public bool isAnimating { get; set; }
        public int[] usedSpaces { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            dlg = new StartWindow();

            if ((bool)dlg.ShowDialog())
            {
                cols = dlg.GetColumns();
                rows = dlg.GetRows();
                n = dlg.GetN();

                paddingX = 20;
                paddingY = 240;
                isAnimating = false;
                spielfeld = new Spielfeld(cols, rows, paddingX, paddingY, Cvs, currentPlayer);
                chip = new Chip(0, spielfeld.cellWidth, paddingX, paddingY, currentPlayer, Cvs, cols, rows);

                usedSpaces = new int[cols];
                foreach (int col in usedSpaces)
                {
                    usedSpaces[col] = 0;
                }
            }
            else
            {
                Close();
            }
        }

        private void Wnd_Loaded(object sender, RoutedEventArgs e)
        {
            // spielfeld = new Spielfeld(cols, rows, paddingX, paddingY);
            spielfeld.Draw(Cvs);
            chip.Draw(Cvs, 0, spielfeld.cellWidth);
        }

        private void Wnd_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (chip != null)
            {
                if (!isAnimating)
                {
                    if (e.Key == Key.Left)
                    {
                        chip.MoveLeft();
                    }
                    else if (e.Key == Key.Right)
                    {
                        chip.MoveRight();
                    }
                    else if (e.Key == Key.Left)
                    {
                        isAnimating = true;
                        chip.MoveDown();
                    }
                }
            }
        }
    }
}
