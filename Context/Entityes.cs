using app_web.Mapping;
using app_web.Models;
using Microsoft.EntityFrameworkCore;

namespace app_web.Context
{
    public class Entityes: DbContext
    {
        public Entityes(DbContextOptions<Entityes> options ) : base(options){}

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
        }
    }
}
