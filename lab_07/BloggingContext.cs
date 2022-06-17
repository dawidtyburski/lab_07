using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class BloggingContext : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Role> Role { get; set; }

    public string ConnectionString { get; }

    public BloggingContext(string connectionString)
    {
        this.ConnectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(this.ConnectionString);
    }
}

public class User
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public long RoleId { get; set; }
    public Role Role { get; set; }


}

public class Role
{
    public long Id { get; set; }
    public string Title { get; set; }

    
}
