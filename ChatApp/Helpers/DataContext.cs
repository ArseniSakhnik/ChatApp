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
        public DbSet<Message> Messages { get; set; }
        public DbSet<Dialog> Dialogs { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserDialog>().HasKey(k => new { k.UserId, k.DialogId });

            modelBuilder.Entity<UserDialog>()
                .HasOne(ud => ud.User)
                .WithMany(u => u.UserDialog)
                .HasForeignKey(ud => ud.UserId);

            modelBuilder.Entity<UserDialog>()
                .HasOne(ud => ud.Dialog)
                .WithMany(d => d.UserDialog)
                .HasForeignKey(ud => ud.DialogId);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>().HasData(
                    new { Id = 1, FirstName = "Alex", LastName = "Alekseew", Username = "test", Password = "test" },
                    new { Id = 2, FirstName = "Alexandr", LastName = "Userowich", Username = "test2", Password = "test2" }
                );

            modelBuilder.Entity<Dialog>().HasData(
                    new { Id = 1 }
                );

            modelBuilder.Entity<UserDialog>().HasData(
                    new { UserId = 1, DialogId = 1 },
                    new { UserId = 2, DialogId = 1 }
                );

            modelBuilder.Entity<Message>().HasData(
                    new { Id = 1, SenderId = 1, DialogId = 1, Text = "Hi" },
                    new { Id = 2, SenderId = 2, DialogId = 1, Text = "Hi, how are you?" },
                    new { Id = 3, SenderId = 1, DialogId = 1, Text = "I'm fine, what about you?" },
                    new { Id = 4, SenderId = 2, DialogId = 1, Text = "I'm fine too. It's cool" }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
