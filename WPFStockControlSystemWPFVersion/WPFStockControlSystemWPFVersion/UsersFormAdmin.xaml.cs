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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WPFStockControlSystemWPFVersion
{
    /// <summary>
    /// Interaction logic for UsersFormAdmin.xaml
    /// </summary>
    public partial class UsersFormAdmin : Window
    {
        public UsersFormAdmin()
        {
            InitializeComponent();
        }

        string AccessString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        private void btnViewUsers_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(AccessString);

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Users", con); //This works
                con.Open();

                //Method 1
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.ItemsSource = dt.DefaultView;
            }
            catch (Exception f)
            {
                MessageBox.Show("exception occured while creating table:" + f.Message + "\t" + f.GetType());
                con.Close();
            }
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(AccessString);

            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string adminAccess = cmbAdmin.Text;

            try
            {
                if (username == "" || password == "" || adminAccess == "")
                {
                    MessageBox.Show("Please enter a username and a password and select admin access");
                }
                else
                {
                    SqlCommand sda = new SqlCommand("INSERT INTO Users VALUES ('" + username + "','" + password + "','" + adminAccess + "')", con); //This works
                    con.Open();

                    sda.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User " + username + " has been created");
                    btnViewUsers_Click(sender, e);
                    txtPassword.Clear();
                    txtUsername.Clear();
                    cmbAdmin.Text = "";
                }
            }
            catch (Exception f)
            {
                MessageBox.Show("exception occured while creating table:" + f.Message + "\t" + f.GetType());
                con.Close();
            }
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(AccessString);

            string username = txtDelUserName.Text;


            try
            {
                if (username == "" || username == null)
                {
                    MessageBox.Show("Please enter a valid username");
                }
                else
                {
                    SqlCommand sda = new SqlCommand("DELETE FROM Users WHERE Username = '" + username + "'", con); //This works
                    con.Open();

                    sda.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User " + username + " has been deleted");
                    btnViewUsers_Click(sender, e);
                    txtDelUserName.Clear();
                }

            }
            catch (Exception f)
            {
                MessageBox.Show("exception occured while creating table:" + f.Message + "\t" + f.GetType());
                con.Close();
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Admin_Menu adminMenu = new Admin_Menu();
            adminMenu.Show();
            this.Close();
        }
    }
}
