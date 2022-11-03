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
    User user;

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
        else if (userManager.SignedInUser is Admin)
        {
            txtConfirmPassword.IsEnabled = false;
            txtNewUsername.IsEnabled = false;
            txtNewPassword.IsEnabled = false;
            btnSave.IsEnabled = false;
            btnChangeInfo.IsEnabled = false;
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

        if (userManager.UpdateUsername(user, newUsername))
        {
            //userManager.SignedInUser.Username = newUsername;
            if (userManager.ValidatePassword(newPassword, confirmPassword))
            {
                //userManager.SignedInUser.Password = newPassword;

                if (newLocation != null && isUser)
                {
                    Countries country = (Countries)Enum.Parse(typeof(Countries), newLocation);
                    User user = userManager.SignedInUser as User;
                    user.Country = country;
                    userManager.SignedInUser = user;
                    userManager.SignedInUser.Username = newUsername;
                    userManager.SignedInUser.Password = newPassword;
                }
                else
                {
                    MessageBox.Show("Something went wrong with the location change, please try again!");
                }
            }
        }
    }

    private void btnReturn_Click(object sender, RoutedEventArgs e)
    {
        TravelsWindow travelsWindow = new(userManager, travelManager);
        travelsWindow.Show();
        Close();
    }
}
