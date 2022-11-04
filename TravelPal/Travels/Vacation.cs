using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.Travels;

internal class Vacation : Travel
{
    public bool AllInclusive { get; set; }

    //Constructor of vacation
    public Vacation(string destination, Countries country, int travelers, bool allInclusive, string UserID) : base(destination, country, travelers, UserID)
    {
        AllInclusive = allInclusive;
    }


    public override string GetInfo()
    {
        //method that returns a string from the object
        return $"From: {Destination} To: {Country} /user: {UserID}";
    }

    public override string GetDetailedInfo()
    {
        //More detailed info from the object in string format
        if (AllInclusive)
        {
            return $"From: {Destination} To: {Country} / Number of travellers: {Travelers} / Vacation / All inclusive ";
        }
        else
        {
            return $"From:{Destination} To: {Country} / Number of travellers: {Travelers} / Vacation ";
        }
    }
}
