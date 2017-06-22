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
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using WpfApp1.DB_Layer;
using WpfApp1.Business_Logic;
using WpfApp1.UI_Layer;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Login login;
        private LandingWindow landingwindow;
        
        public MainWindow()
        {
            InitializeComponent();
            login = new Login();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int loginsuccess;
            try
            {
                loginsuccess = login.LoginAttempt(Username.Text, Password.Password);

                if(loginsuccess == 1)
                {
                    this.Hide();
                    landingwindow = new LandingWindow();
                    landingwindow.Show();
                }
                else if (loginsuccess == 2)
                {
                    MessageBox.Show("Multiple records with the same username exist");
                }
                else if (loginsuccess == 0)
                {
                    MessageBox.Show("Incorrect username/password");
                }
                else
                {
                    MessageBox.Show("There was an error logging in");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
