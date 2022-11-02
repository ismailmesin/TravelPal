﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.Travels;

public class Travel
{
    public string Destination { get; set; }
    public Countries Country { get; set; }
    public int Travelers { get; set; }

    public Travel(string destination, Countries country, int travelers)
    {
        Destination = destination;
        this.Country = country;
        Travelers = travelers;
    }

    public virtual string GetInfo() 
    {
       return  $"{Destination} / {Country}";
    }

    public virtual string GetDetailedInfo()
    {
        return $"{Destination} / {Country} / Number of travellers: {Travelers}";

    }
}
