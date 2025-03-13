using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;

namespace RepositoryLayer.Context
{
    //Connects the application to database
    public class GreetingDBContext : DbContext
    {
        public GreetingDBContext(DbContextOptions<GreetingDBContext> options) : base(options) { }
        public DbSet<GreetingEntity> Greetings { get; set; } //Ensures DbSet<> is correct
        public DbSet<UserEntity> Users { get; set; } // New table for Users
    }
}
