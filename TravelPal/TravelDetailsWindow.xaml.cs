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
using TravelPal.Managers;
using TravelPal.Travels;
using TravelPal.Users;

namespace TravelPal;

/// <summary>
/// Interaction logic for TravelDetailsWindow.xaml
/// </summary>
public partial class TravelDetailsWindow : Window
{
    private readonly UserManager userManager;
    TravelManager travelManager;
    IUser user;
    public TravelDetailsWindow(UserManager userManager, TravelManager travelManager, Travel travel)
    {
        InitializeComponent();
        this.userManager = userManager;
        this.travelManager = travelManager;

        lvTripDetails.Items.Add(travel.GetDetailedInfo());
    }
}
