using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.Travels;

internal class Trip : Travel
{
    public TripTypes Type { get; set; }
    public Trip(string destination, Countries country, int travelers, TripTypes tripType, string UserID) : base(destination, country, travelers, UserID)
    {
        Type = tripType;
    }

    public override string GetInfo()
    {
        return $"From: {Destination} To: {Country} /user: {UserID}";


        //return base.GetInfo();
    }
    public override string GetDetailedInfo()
    {
        if(Type == TripTypes.Leisure)
        {
            return $"From: {Destination} To: {Country} / Number of travellers: {Travelers} / Type of trip: Leisure";

        }
        else
        {
            return $"From: {Destination} To: {Country} / Number of travellers: {Travelers} / Type of trip: Work";

        }

    }
}
