using AspNetCoreWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApi.Data
{
    public class FruitStoreContext : DbContext
    {
        public DbSet<Fruit> Fruits { get; set; }

        public FruitStoreContext(DbContextOptions<FruitStoreContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fruit>()
                .ToTable("fruits");

            modelBuilder.Entity<Fruit>()
                .Property(f => f.Id)
                .HasColumnName("id");

            modelBuilder.Entity<Fruit>()
                .Property(f => f.No)
                .HasColumnName("no");

            modelBuilder.Entity<Fruit>()
                .Property(f => f.Description)
                .HasColumnName("description");

            modelBuilder.Entity<Fruit>()
                .HasIndex(f => f.No)
                .IsUnique();
        }
    }
}