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
    /// Interaction logic for TablesMenu.xaml
    /// </summary>
    public partial class TablesMenu : Window
    {
        public TablesMenu()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Admin_Menu adminMenu = new Admin_Menu();
            adminMenu.Show();
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            CreateTablesForm createTables = new CreateTablesForm();
            createTables.Show();
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            View_or_Edit_Tables viewTables = new View_or_Edit_Tables();
            viewTables.Show();
            this.Close();
        }
    }
}
