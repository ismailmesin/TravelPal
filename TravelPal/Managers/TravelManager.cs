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


    public Travel AddTravel(string destination, Countries country, int travelers, TripTypes tripType)
    {
        Trip trip = new(destination, country, travelers, tripType);

        travels.Add(trip);

        return trip;
    }

    public Travel AddTravel(string destination, Countries country, int travelers, bool allInclusive)
    {
        Vacation vacation = new(destination, country, travelers, allInclusive);

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
    public void RemoveUserTravels(Travel travel)
    {
        foreach(Travel travel1 in travels)
        {
            user.Travels.Remove(travel);

        }
    }

}
