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

namespace WPFStockControlSystemWPFVersion
{
    /// <summary>
    /// Interaction logic for View_or_Edit_Tables.xaml
    /// </summary>
    public partial class View_or_Edit_Tables : Window
    {
        public View_or_Edit_Tables()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            TablesMenu tableMenu = new TablesMenu();
            tableMenu.Show();
            this.Close();
        }
    }
}
