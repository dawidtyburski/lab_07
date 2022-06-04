using Microsoft.EntityFrameworkCore;
using Models;

namespace lab_07
{
    class ProjectDBContext : DbContext
    {
        public DbSet<Persons> Persons { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\mssqllocaldb;database=lab07;trusted_connection=true;");
        }
    }
}
