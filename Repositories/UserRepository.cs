using ApiAuth.Models;

namespace ApiAuth.Repositories;

public static class UserRepository
{
    public static User Get(string username, string password)
    {
        var users = new List<User>
        {
            new () { Id = 1, Username = "batman", Password = "batman", Role = "admin" },
            new () { Id = 2, Username = "robin", Password = "robin", Role = "admin" }
        };

        return users.FirstOrDefault(x =>
            string.Equals(x.Username, username, StringComparison.CurrentCulture) && 
            x.Password.ToLower() == password.ToLower());
    }    
}
