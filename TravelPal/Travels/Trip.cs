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
    public Trip(string destination, Countries country, int travelers, TripTypes tripType) : base(destination, country, travelers)
    {
        Type = tripType;
    }

    public override string GetInfo()
    {
        return base.GetInfo();
    }
}
