using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.Users;

public class User : IUser
{
    public string Username { get; set; }
    public string Password { get; set; }
    public Countries Country { get; set; }

    public User(string username, string password, Countries country)
    {

    }
}
