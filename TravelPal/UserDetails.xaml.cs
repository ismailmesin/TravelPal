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

namespace TravelPal;

/// <summary>
/// Interaction logic for UserDetails.xaml
/// </summary>
public partial class UserDetails : Window
{
    private UserManager userManager;

    public UserDetails(UserManager userManager)
    {
        InitializeComponent();
        //userManager.SignedInUser = userManager.GetUser(username, password, country);

        this.userManager = userManager;

        lblUsername.Content = userManager.SignedInUser.Username;
        lblPassword.Content = userManager.SignedInUser.Password;
        lblCountry.Content = userManager.SignedInUser.Country.ToString();
    }

    private void btnChangeInfo_Click(object sender, RoutedEventArgs e)
    {
        txtConfirmPassword.IsEnabled = true;
        txtNewUsername.IsEnabled = true;
        txtNewPassword.IsEnabled = true;
        cbNewCountry.IsEnabled = true;
        btnSave.IsEnabled = true;

        this.userManager = userManager;

        string[] countries = Enum.GetNames(typeof(Countries));
        cbNewCountry.ItemsSource = countries;
    }

    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
        this.userManager = userManager;
        string newUsername = txtNewUsername.Text;
        string newPassword = txtNewPassword.Text;
        string confirmPassword = txtConfirmPassword.Text;
        string? newLocation = cbNewCountry.SelectedItem as string;

        if(newUsername != null)
        {
            userManager.SignedInUser.Username = newUsername;

        }
        else if (newUsername == null)
        {
            MessageBox.Show("Type in your new username", "WARNING");
        }
        if (newLocation != null)
        {
            Countries country = (Countries)Enum.Parse(typeof(Countries), newLocation);
            userManager.SignedInUser.Country = country;
        }
        else if (newLocation == null)
        {
            MessageBox.Show("Type in your new location", "WARNING");
        }

        if(newPassword != null)
        {
            if(newPassword == confirmPassword)
            {
                userManager.SignedInUser.Password = newPassword;

            }
        }
        else if(newPassword == null && confirmPassword == null)
        {
            MessageBox.Show("Type in your new password", "WARNING");
        }
        else
        {
            MessageBox.Show("The new passwords did not match!", "Warning");
        }
    }

    private void btnReturn_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
