using Assignment2.Login;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DNPAssignment3.ContextClasses
{
    public class AdultContext : DbContext
    {
        public DbSet<Adult> Adults { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source= Adult.db");
        }
    }
}