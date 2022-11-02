using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;
using TravelPal.Travels;

namespace TravelPal.Users;

public class User : IUser
{
    public string Username { get; set; }
    public string Password { get; set; }
    public Countries Country { get; set; }
    public List<Travel> Travels { get; set; } = new();

    public User(string username, string password, Countries country)
    {
        Username = username;
        Password = password;
        Country = country;
    }
}
