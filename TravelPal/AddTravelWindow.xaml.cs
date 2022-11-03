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
/// Interaction logic for AddTravelWindow.xaml
/// </summary>
public partial class AddTravelWindow : Window
{
    TravelManager travelManager;
    UserManager userManager;
    private string selectedTravelType;
    public AddTravelWindow(UserManager userManager, TravelManager travelManager)
    {
        InitializeComponent();

        string departureCountry = txtDepartureCountry.Text;

        string[] arrivalCountries = Enum.GetNames(typeof(Countries));
        cbArrivalCountry.ItemsSource = arrivalCountries;

        string travelers = txtTravelers.Text;

        string[] travelTypes = Enum.GetNames(typeof(TravelTypes));
        cbTravelType.ItemsSource = travelTypes;

        string[] tripTypes = Enum.GetNames(typeof(TripTypes));
        cbTripType.ItemsSource = tripTypes;

        this.userManager = userManager;
        this.travelManager = travelManager;
    }

    private void btnAdd_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            string departureCountry = txtDepartureCountry.Text;
            string arrivalCountry = cbArrivalCountry.SelectedItem as string;

            int numberOfTravelers = Convert.ToInt32(txtTravelers.Text);

            //int numberOfTravelers = Convert.ToInt32(txtTravelers.Text);
            Countries country = (Countries)Enum.Parse(typeof(Countries), arrivalCountry);


            if (selectedTravelType == "Trip")
            {
                string tripTypeString = cbTripType.SelectedItem as string;

                string userID = userManager.SignedInUser.Username;

                TripTypes tripType = (TripTypes)Enum.Parse(typeof(TripTypes), tripTypeString);

                Travel newTravel = travelManager.AddTravel(departureCountry, country, numberOfTravelers, tripType, userID);

                if (userManager.SignedInUser is User)
                {
                    User user = userManager.SignedInUser as User;

                    user.Travels.Add(newTravel);

                    userManager.SignedInUser = user;
                }
            }
            else if (selectedTravelType == "Vacation")
            {
                string userID = userManager.SignedInUser.Username;

                bool allInclusive = (bool)xbAllInclusive.IsChecked;

                Travel newTravel = travelManager.AddTravel(departureCountry, country, numberOfTravelers, allInclusive, userID);

                if (userManager.SignedInUser is User)
                {
                    User user = userManager.SignedInUser as User;

                    user.Travels.Add(newTravel);

                    userManager.SignedInUser = user;
                }
            }
            TravelsWindow travelsWindow = new(userManager, travelManager);
            travelsWindow.Show();
            Close();
        }

        catch
        {
            MessageBox.Show("Please type in a number in number of travelers");
        }
        //TravelsWindow travelsWindow = new(userManager, travelManager);
        //travelsWindow.Show();
        //Close();
    }

    private void cbTravelType_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        selectedTravelType = cbTravelType.SelectedItem as string;    

        if(selectedTravelType == "Trip")
        {
            cbTripType.Visibility = Visibility.Visible;
            xbAllInclusive.Visibility = Visibility.Hidden;
        }
        else if (selectedTravelType == "Vacation")
        {
            xbAllInclusive.Visibility = Visibility.Visible;
            cbTripType.Visibility = Visibility.Hidden;
        }
    }
}
