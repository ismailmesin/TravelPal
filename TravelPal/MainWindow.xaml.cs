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
using TravelPal.Enums;
using TravelPal.Managers;
using TravelPal.Users;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserManager userManager = new();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new(userManager);
            //show register window to user
            registerWindow.Show();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            //create variables of user inputs in textboxes
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if(userManager.SignInUser(username, password))
            {
                // Log in

                userManager.SignedInUser = userManager.GetUser(username);

                TravelsWindow travelsWindow = new(userManager);

                //if log in succesfull
                travelsWindow.Show();
                //close the mainwindow
                Close();
            }
            else
            {
                //Is username or password is incorect 
                //print warning messagebox
                MessageBox.Show("Warning! Invalid username or password!");
            }


        }
    }
}
