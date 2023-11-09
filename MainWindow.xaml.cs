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
        public MainWindow()
        {
            InitializeComponent();

            StartWindow dlg = new StartWindow();

            if ((bool)dlg.ShowDialog())
            {
                MessageBox.Show($"Columns: {dlg.GetColumns()}, Rows: {dlg.GetRows()}, N: {dlg.GetN()}");
            }
            else
            {
                Close();
            }
        }
    }
}
