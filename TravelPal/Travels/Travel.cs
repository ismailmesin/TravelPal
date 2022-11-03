using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;
using TravelPal.Managers;
using TravelPal.Users;

namespace TravelPal.Travels;

public class Travel
{
    public string Destination { get; set; }
    public Countries Country { get; set; }
    public int Travelers { get; set; }
    public string UserID { get; set; }
    UserManager userManager;

    public Travel(string destination, Countries country, int travelers, string userID)
    {
        Destination = destination;
        this.Country = country;
        Travelers = travelers;
        UserID = userID;
    }

    public virtual string GetInfo() 
    {
        if(userManager.SignedInUser is User)
        {
            return $"{Destination} / {Country}";

        }
        else if(userManager.SignedInUser is Admin)
        {
            return $"{Destination} / {Country} / {UserID}";
        }
        return string.Empty;    
    }

    public virtual string GetDetailedInfo()
    {
        return $"{Destination} / {Country} / Number of travellers: {Travelers}";

    }
}
