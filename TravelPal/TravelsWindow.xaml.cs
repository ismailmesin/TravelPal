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
using TravelPal.Travels;
using TravelPal.Users;

namespace TravelPal;

/// <summary>
/// Interaction logic for TravelsWindow.xaml
/// </summary>
public partial class TravelsWindow : Window
{
    TravelManager travelManager;
    UserManager userManager;
    public TravelsWindow(UserManager userManager, TravelManager travelManager)
    {
        InitializeComponent();

        this.userManager = userManager;
        this.travelManager = travelManager;
        UpdateUI();
    }

    private void UpdateUI()
    {
        txtTrips.Items.Clear();
        lbUsername.Content = userManager.SignedInUser.Username;

        if (userManager.SignedInUser is User)
        {
            User user = userManager.SignedInUser as User;

            foreach(Travel travel in user.Travels)
            {
                ListViewItem item = new();
                item.Content = travel.GetInfo();
                item.Tag = travel;

                txtTrips.Items.Add(item);
            }
        }
        else if (userManager.SignedInUser is Admin)
        {
            Admin admin = userManager.SignedInUser as Admin;

             foreach (Travel travel in travelManager.travels)
             {
              ListViewItem item = new();
              item.Content = travel.GetInfo();
              item.Tag = travel;

               txtTrips.Items.Add(item);
             }
        }
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
        MainWindow mainWindow = new(userManager, travelManager);
        mainWindow.Show();
        Close();
    }

    private void btnUserDetails_Click(object sender, RoutedEventArgs e)
    {
        UserDetails userDetails = new(userManager, travelManager);

        userDetails.Show();
        Close();
    }

    private void btnAddTravel_Click(object sender, RoutedEventArgs e)
    {
        AddTravelWindow addTravelWindow = new(userManager, travelManager);
        addTravelWindow.Show();
        Close();
    }

    private void btnTripDetails_Click(object sender, RoutedEventArgs e)
    {
        ListViewItem selectedItem = txtTrips.SelectedItem as ListViewItem;

        if(selectedItem != null)
        {
            Travel selectedTravel = selectedItem.Tag as Travel;

            TravelDetailsWindow travelDetailsWindow = new(userManager, travelManager, selectedTravel);
            travelDetailsWindow.Show();
        }
        else if (selectedItem == null)
        {
            MessageBox.Show("Please select a trip in the list");
        }
    }

    private void btnRemove_Click(object sender, RoutedEventArgs e)
    {
        ListViewItem selectedItem = txtTrips.SelectedItem as ListViewItem;

        if (selectedItem != null)
        {
            if (userManager.SignedInUser is User)
            {
                User user = userManager.SignedInUser as User;

                Travel selectedTravel = selectedItem.Tag as Travel;

                travelManager.travels.Remove(selectedTravel);
                user.Travels.Remove(selectedTravel);
            }
            else if (userManager.SignedInUser is Admin)
            {
                Admin admin = userManager.SignedInUser as Admin;

                Travel selectedTravel = selectedItem.Tag as Travel;

                travelManager.travels.Remove(selectedTravel);
                travelManager.RemoveUserTravels(selectedTravel);
                //user.Travels.Remove(selectedTravel);


            }

            UpdateUI();

            //TravelsWindow travelsWindow = new(userManager, travelManager);
            //travelsWindow.Show();
            //Close();

        }
    }
}

