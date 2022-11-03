using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TravelPal.Enums;
using TravelPal.Travels;
using TravelPal.Users;

namespace TravelPal.Managers;

public class TravelManager
{
    public List<Travel> travels = new();
    public string Destination { get; set; }
    public Countries Country { get; set; }
    User user;
    UserManager userManager;


    public Travel AddTravel(string destination, Countries country, int travelers, TripTypes tripType, string UserID)
    {
        Trip trip = new(destination, country, travelers, tripType, UserID);

        travels.Add(trip);

        return trip;
    }

    public Travel AddTravel(string destination, Countries country, int travelers, bool allInclusive, string UserID)
    {
        Vacation vacation = new(destination, country, travelers, allInclusive, UserID);

        travels.Add(vacation);

        return vacation;
    }
    public string GetInfo()
    {

        foreach (Travel travel in travels)
        {
            return $"{Destination} / {Country}";
        }
        return null;
      
    }
    public void RemoveUserTravels(Travel travel, User user)
    {
        if (user.Username == travel.UserID)
        {
            user.Travels.Remove(travel);
        }
    }
}
