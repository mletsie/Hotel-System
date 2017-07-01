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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private Register register;
        private LandingWindow landingwindow;

        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int registersuccess;
            try
            {
                register = new Register();
                registersuccess = register.individualRegister(NameTextbox.Text, SurnameTextbox.Text, DateOfBirthPicker.SelectedDate.Value.ToString(), EmailTextBox.Text, ContactTextbox.Text, PasswordTextbox.Password);

                if (registersuccess == 1)
                {
                    this.Hide();
                    landingwindow = new LandingWindow();
                    landingwindow.Show();
                }
                else if (registersuccess == 0)
                {
                    MessageBox.Show("There was an error registering");
                }
                else
                {
                    MessageBox.Show("Unknown error");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
