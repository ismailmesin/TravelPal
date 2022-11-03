using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.Travels
{
    internal class Vacation : Travel
    {
        public bool AllInclusive { get; set; }
        public Vacation(string destination, Countries country, int travelers, bool allInclusive, string UserID) : base(destination, country, travelers, UserID)
        {
            AllInclusive = allInclusive;
        }

        public override string GetInfo()
        {
            return $"From: {Destination}/ To: {Country} / {UserID}";
            //return base.GetInfo();
        }

        public override string GetDetailedInfo()
        {
            if (AllInclusive)
            {
                return $"{Destination} / {Country} / Number of travellers: {Travelers} / All inclusive ";

            }
            else
            {
                return $"{Destination} / {Country} / Number of travellers: {Travelers} ";

            }
        }
    }
}
