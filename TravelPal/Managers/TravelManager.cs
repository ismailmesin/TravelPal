using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TravelPal.Enums;
using TravelPal.Travels;

namespace TravelPal.Managers;

public class TravelManager
{
    public List<Travel> travels = new();

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
    public Travel GetInfo()
    {
        if (travels != null)
        {
            foreach (Travel travel in travels)
            {
                return travel;
            }
        }
        else
        {
            MessageBox.Show("You have not added any trips!");
        }
        return null;
      
    }

}
