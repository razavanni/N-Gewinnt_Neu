using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
                paddingY = 200;

                spielfeld = new Spielfeld(cols, rows, paddingX, paddingY);
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
        }
    }
}
