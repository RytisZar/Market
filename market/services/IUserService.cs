using market.Data;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace market.Services;

public interface UserService
{
    List<User> GetUsers();
    User Add(string name);

    void Delete(int id);
    object GetUser(string id);
}
