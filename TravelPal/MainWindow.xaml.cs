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
using TravelPal.Travels;
using TravelPal.Users;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserManager userManager;
        TravelManager travelManager;
        Travel travel;
        public MainWindow()
        {
            InitializeComponent();

            userManager = new();
            travelManager = new();

            User user1 = new User("Gandalf", "password", Countries.nigeria);
            userManager.users.Add(user1);

            Admin admin = new("Admin", "password");
            userManager.users.Add(admin);

            Travel travel = travelManager.AddTravel("Middle Earth", Countries.argentina, 5, TripTypes.Leisure);
            Travel travel2 = travelManager.AddTravel("Middle Earth", Countries.USA, 2, TripTypes.Work);

            user1.Travels.Add(travel);
            user1.Travels.Add(travel2);
        }
        public MainWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();

            this.userManager = userManager;
            this.travelManager = travelManager;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new(userManager, travelManager);
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

                TravelsWindow travelsWindow = new(userManager, travelManager);

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
