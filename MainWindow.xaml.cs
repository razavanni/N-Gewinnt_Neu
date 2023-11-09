using System.Windows;

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

                spielfeld = new Spielfeld(cols, rows, paddingX, paddingY, Cvs, currentPlayer);
                chip = new Chip(0, spielfeld.cellWidth, paddingX, paddingY, currentPlayer, Cvs, cols, rows);
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
    }
}
