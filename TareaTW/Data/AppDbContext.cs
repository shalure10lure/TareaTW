using System.Collections.Generic;
using System.Reflection.Emit;
using TareaTW.Models;

namespace TareaTW.Data
{
    public class AppDbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Book> Books => Set<Book>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Book>();
        }
    }
}
