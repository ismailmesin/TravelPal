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
    //Creating a List for travels
    public List<Travel> travels = new();
    public string Destination { get; set; }
    public Countries Country { get; set; }
    User user;
    UserManager userManager;


    //Method that adds travels to travelsList
    public Travel AddTravel(string destination, Countries country, int travelers, TripTypes tripType, string UserID)
    {
        //Introducing trip class
        //creating a object of the trip class
        Trip trip = new(destination, country, travelers, tripType, UserID);

        //Adding a trip to the list
        travels.Add(trip);

        return trip;
    }

    //Method that adds vacations to the travels list
    public Travel AddTravel(string destination, Countries country, int travelers, bool allInclusive, string UserID)
    {
        //introducing vacation class
        //Creating a object of the vacation class
        Vacation vacation = new(destination, country, travelers, allInclusive, UserID);

        //adding the object to the travels list
        travels.Add(vacation);

        return vacation;
    }
      
    public void RemoveUserTravels(Travel travel, User user)
    { //method that remove a travel from the travel List

        //Checks to see which user created the travel
        if (user.Username == travel.UserID)
        {
            //deletes object from the list
            user.Travels.Remove(travel);
        }
    }
}
