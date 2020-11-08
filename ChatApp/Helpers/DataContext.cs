using ChatApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Helpers
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            User user = new User {Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" };

            modelBuilder.Entity<User>().HasData(new User[] { user });
        }
    }
}
