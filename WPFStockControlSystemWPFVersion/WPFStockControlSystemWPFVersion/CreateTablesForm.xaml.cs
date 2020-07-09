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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WPFStockControlSystemWPFVersion
{
    /// <summary>
    /// Interaction logic for CreateTablesForm.xaml
    /// </summary>
    public partial class CreateTablesForm : Window
    {
        public CreateTablesForm()
        {
            InitializeComponent();
        }

        string AccessString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;  //Connection String

        private void btnCreateTable_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(AccessString);

            string tableName = txtInput.Text;

            try
            {
                //User can create their own table with their own table name
                SqlCommand sda = new SqlCommand("CREATE TABLE " + tableName + " (ProductID INTEGER PRIMARY KEY, ProductName varchar(50), ProductSize varchar(50), ProductColour varchar(50), ProductStyle varchar(50))", con); //This works
                con.Open();
                //sda.ExecuteNonQuery();
                sda.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Table Created");
                btnViewAllTables_Click(sender, e);
            }
            catch (Exception a)
            {
                MessageBox.Show("exception occured while creating table:" + a.Message + "\t" + a.GetType());
            }
        }



        private void btnViewAllTables_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(AccessString);

            try
            {

                con.Open();

                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = con;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "Select table_name from information_schema.tables";

                SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

                DataTable dtRecord = new DataTable();
                sqlDataAdap.Fill(dtRecord);
                listBox1.Items.Clear();

                listBox1.ItemsSource = dtRecord.DefaultView;

                listBox1.DisplayMemberPath = "TABLE_NAME";

                con.Close();

            }
            catch (Exception f)
            {
                MessageBox.Show("exception occured while creating table:" + f.Message + "\t" + f.GetType());
                con.Close();
            }



        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            listBox1.ItemsSource = null;
            listBox1.Items.Clear();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            TablesMenu tablesMenu = new TablesMenu();
            tablesMenu.Show();
            this.Close();
        }
    }
}
