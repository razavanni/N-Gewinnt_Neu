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
using System.Windows.Shapes;

namespace N_Gewinnt
{
    /// <summary>
    /// Interaktionslogik für StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        public int GetColumns()
        {
            return int.Parse(txt_columns.Text);
        }

        public int GetRows()
        {
            return int.Parse(txt_rows.Text);
        }

        public int GetN()
        {
            return int.Parse(txt_n.Text);
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int.TryParse(txt_columns.Text, out int columns);
                int.TryParse(txt_rows.Text, out int rows);
                int.TryParse(txt_n.Text, out int n);

                if (columns > 3 &&
                    rows > 3 &&
                    n < Math.Min(rows, columns))
                {
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Fehler: N muss Kleiner als Columns und Rows sein", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
