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
/// Interaction logic for TravelsWindow.xaml
/// </summary>
public partial class TravelsWindow : Window
{
    UserManager userManager;
    MainWindow mainWindow = new();
    IUser user;
    public TravelsWindow(UserManager userManager)
    {
        InitializeComponent();

        this.userManager = userManager;

        lbUsername.Content = userManager.SignedInUser.Username;
    }

    private void btnInfo_Click(object sender, RoutedEventArgs e)
    {
        if(txtInfo.Text.Length == 0)
        {
            txtInfo.Text = "TravelPal was founded in 2022 in San Fransisco CA";
        }
        else
        {
            txtInfo.Text = "";
        }
    }

    private void btnSignOut_Click(object sender, RoutedEventArgs e)
    {
        mainWindow.Show();
        Close();
    }

    private void btnUserDetails_Click(object sender, RoutedEventArgs e)
    {
        UserDetails userDetails = new(userManager);

        userDetails.Show();

    }
}
