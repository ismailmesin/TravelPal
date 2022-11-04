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
    //PROPS
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

    public User GetAllUsers()
    {
        //return users in list
        foreach(User user in users)
        {
            return user;

        }
        return null;
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
        foreach (IUser user in users)
        {
            if (user.Username == username)
            {
                return user;
            }
        }

        return null;
    }

    private bool ValidateUsername(string username)
    {
        //Method to see if username is ok to use
        foreach(IUser user in users)
        {
            if(user.Username == username)
            {
                //if there is a user with the same username
                MessageBox.Show("Username already exists!");
                return false;
            }
        }
        return true;
    }

    public bool UpdateUsername(IUser user, string username)
    {
        //checking if all criterias for username are met
        if(username.Length < 3)
        {
            MessageBox.Show("Username is to short");
            return false;
        }
        else if (username == null)
        {
            MessageBox.Show("You need to enter a username");
            return false;
        }
        else if (ValidateUsername(username)== false)
        {
            return false;
        }
        return true;
    }
    public bool ValidatePassword(string password, string newPassword)
    {
        //checking if all criterias for password are met
        if (password.Length < 5)
        {
            MessageBox.Show("password must be 5 characthers long");
            return false;
        }
        else if (password == null)
        {
            MessageBox.Show("You need to enter a password");
            return false;
        }
        else if (password != newPassword)
        {
            MessageBox.Show("The passwords did not match, Try again");
            return false;
        }
        return true;
    }
}
