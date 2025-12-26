using System.Data.Common;
using market.Data;
using Microsoft.EntityFrameworkCore;

namespace market.Services;

public class GreetingService : UserService 
{
    private readonly AppDbContext _db;

    public GreetingService(AppDbContext db)
    {
        _db = db;
    }

    public User Add(string name)
    {
        var user = _db.Users.Include(x => x.Role).FirstOrDefault(x => x.Name == name);
        if (user == null)
        {
            var role = _db.Roles.FirstOrDefault(x => x.Name == "Regular" );
            user = new User
            {
                Name = name,
                Role = role
            };

            _db.Users.Add(user);
            _db.SaveChanges();
        }

        return user;
    }

    public void Delete(int id)
    {
        var user = _db.Users.FirstOrDefault(x => x.Id == id);
        if (user != null)
        {
            _db.Users.Remove(user);
            _db.SaveChanges();
        }
    }

    public object GetUser(string id)
    {
        throw new NotImplementedException();
    }

    public List<User> GetUsers()
    {
        var result = _db.Users
                        .Include(x => x.Role)
                        .ToList();
        
        return result;
    }
}
