using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Configuration;

namespace WPFStockControlSystemWPFVersion
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        string AccessString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        public Login()
        {
            InitializeComponent();
        }

        public void nextPageCheck()
        {

            SqlConnection con = new SqlConnection(AccessString);
            //startConnection();

            try
            {
                //startConnection();
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Users WHERE Username = '" + Username.Text + "' AND Password = '" + Password.Text + "' AND AdminAccess = 'Yes'", con);
                con.Close();
                con.Open();
                SqlDataAdapter sda2 = new SqlDataAdapter("SELECT * FROM Users WHERE Username = '" + Username.Text + "' AND Password = '" + Password.Text + "' AND AdminAccess = 'No'", con);
                con.Close();

                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();

                sda.Fill(dt);
                sda2.Fill(dt2);

                if (dt.Rows.Count == 1) //Checks if the user exists in the table and is a normal user or not
                {
                    Admin_Menu admin = new Admin_Menu();
                    admin.Show();
                    this.Close();
                    //HomePage homePage = new HomePage();
                    //homePage.Show();

                }
                else if (dt2.Rows.Count == 1)   //Checks if the user is in the table and is an admin or not
                {
                    NormalUserMenu normal = new NormalUserMenu();
                    normal.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You entered a wrong username and password", "Error");  //Tells the user if they ahgve entered a wrong username or password
                }
            }
            catch (Exception f)
            {
                MessageBox.Show("exception occured while accessing the database:" + f.Message + "\t" + f.GetType());    //Tells the user what error has occured
            }
        }

        public void startConnection()
        {
            //+ access);
            //SqlConnection con = new SqlConnection(AccessString);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            nextPageCheck();
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                nextPageCheck();
            }
        }

        private void Username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                nextPageCheck();
            }
        }
    }
}
