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
using TravelPal.Enums;
using TravelPal.Managers;
using TravelPal.Users;

namespace TravelPal;

/// <summary>
/// Interaction logic for UserDetails.xaml
/// </summary>
public partial class UserDetails : Window
{
    private UserManager userManager;
    private readonly TravelManager travelManager;
    private bool isUser;

    public UserDetails(UserManager userManager, TravelManager travelManager)
    {
        InitializeComponent();
        //userManager.SignedInUser = userManager.GetUser(username, password, country);

        this.userManager = userManager;
        this.travelManager = travelManager;
        lblUsername.Content = userManager.SignedInUser.Username;
        lblPassword.Content = userManager.SignedInUser.Password;

        if(userManager.SignedInUser is User)
        {
            isUser = true;
            User signedInUser = userManager.SignedInUser as User;
            lblCountry.Content = signedInUser.Country.ToString();
        }
    }

    private void btnChangeInfo_Click(object sender, RoutedEventArgs e)
    {
        txtConfirmPassword.IsEnabled = true;
        txtNewUsername.IsEnabled = true;
        txtNewPassword.IsEnabled = true;

        if (isUser)
        {
            cbNewCountry.IsEnabled = true;

            string[] countries = Enum.GetNames(typeof(Countries));
            cbNewCountry.ItemsSource = countries;
        }

        btnSave.IsEnabled = true;
    }

    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
        this.userManager = userManager;
        string newUsername = txtNewUsername.Text;
        string newPassword = txtNewPassword.Text;
        string confirmPassword = txtConfirmPassword.Text;
        string? newLocation = cbNewCountry.SelectedItem as string;

        if(newUsername != null && newUsername.Length >= 5)
        {
            userManager.SignedInUser.Username = newUsername;

        }
        else if (newUsername == null)
        {
            MessageBox.Show("Type in your new username", "WARNING");
        }
        else if(newUsername.Length <= 5)
        {
            MessageBox.Show("Your new username is less than 5 characters");
        }
        if (newLocation != null && isUser)
        {
            Countries country = (Countries)Enum.Parse(typeof(Countries), newLocation);
            User user = userManager.SignedInUser as User;
            user.Country = country;
            userManager.SignedInUser = user;
        }
        else if (newLocation == null)
        {
            MessageBox.Show("Type in your new location", "WARNING");
        }

        if(newPassword != null)
        {
            if(newPassword == confirmPassword && newPassword.Count() <= 5)
            {
                userManager.SignedInUser.Password = newPassword;

            }
            else if(newPassword.Length >= 4)
            {
                MessageBox.Show("Password must be atleast 5 Characters long", "OBS");
            }
            else
            {
                MessageBox.Show("The passwords did not match!", "WARNING");
            }
        }
        else if (newPassword == null)
        {
            MessageBox.Show("Please fill in the new password box!", "WARNING");
        }
        //else if(newPassword == null && confirmPassword == null)
        //{
        //    MessageBox.Show("Type in your new password", "WARNING");
        //}
        //else
        //{
        //    MessageBox.Show("The new passwords did not match!", "Warning");
        //}
    }

    private void btnReturn_Click(object sender, RoutedEventArgs e)
    {
        TravelsWindow travelsWindow = new(userManager, travelManager);
        travelsWindow.Show();
        Close();
    }
}
