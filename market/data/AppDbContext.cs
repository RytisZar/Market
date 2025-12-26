using Microsoft.EntityFrameworkCore;

namespace market.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    // Example table
    public DbSet<User> Users {get; set;}

    public DbSet<Role> Roles {get; set;}
}
