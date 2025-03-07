using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;

namespace RepositoryLayer.Context
{
    //Connects the application to database
    public class GreetingDBContext : DbContext
    {
        public GreetingDBContext(DbContextOptions<GreetingDBContext> options) : base(options) { }
        public DbSet<GreetingEntity> Greetings { get; set; } //Ensures DbSet<> is correct

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GreetingEntity>().HasKey(e => e.Id);  // ✅ Explicitly defining primary key
        }
    }
}
