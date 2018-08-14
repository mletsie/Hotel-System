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
using WpfApp1.Business_Logic;
using WpfApp1.UI_Layer;

namespace WpfApp1.UI_Layer
{
    /// <summary>
    /// Interaction logic for Landing.xaml
    /// </summary>
    public partial class LandingWindow : Window
    {
        private MainWindow loginpage;
        private WelcomeWindow welcome;

        public LandingWindow(string message, int button)
        {
            InitializeComponent();
            MyLabel.Content = message;

            if(button == 1)
            {
                MyButton.Content = "Main Page";
                MyButton.Click += MyButton_Click;
            }
            if(button == 2)
            {
                MyButton.Content = "Login";
                MyButton.Click += MyButton_Click1;
            }
        }

        private void MyButton_Click1(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            this.Hide();
            loginpage = new MainWindow();
            loginpage.Show();
        }

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            welcome = new WelcomeWindow();
            welcome.Show();
        }
    }
}
