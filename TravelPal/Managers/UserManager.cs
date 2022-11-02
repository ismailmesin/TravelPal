using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TravelPal.Enums;
using TravelPal.Users;

namespace TravelPal.Managers;

public class UserManager
{
    public List<IUser> users = new();
    public IUser? SignedInUser { get; set; }

    public bool AddUser(string username, string password, Countries country)
    {
            User user = new(username, password, country);
            user.Username = username;
            user.Password = password;
            user.Country = country;

            //Add user to list
            users.Add(user);


        return true;
    }

    public List<IUser> GetAllUsers()
    {
        //return users in list
        return users;
    }

    public bool SignInUser(string username, string password)
    {

        //Loop the list of users
        foreach(IUser user in users)
        {
            //check if username and password exits in userlist
            if (user.Username == username && user.Password == password)
            {
                return true;
                //sign in user if succesfull
            }
        }

        //is username and password is incorrect
        return false;
    }

    public IUser GetUser(string username)
    {
        foreach(IUser user in users)
        {
            if(user.Username == username)
            {
                return user;
            }
        }

        return null;
    }

    //public void ValidateUsername(string username, string password, Countries country)
    //{
    //    foreach(IUser user1 in users)
    //    {
    //        if (user1.Username.Contains(username))
    //        {
    //            MessageBox.Show("This username is already in use, please choose another one", "WARNING");
    //        }
    //        else
    //        {
    //            AddUser(username,password,country);
    //        }
    //    }
    //}
}
