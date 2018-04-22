using AspNetCoreWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApi.Data
{
    public class FruitContext : DbContext
    {
        public DbSet<Fruit> Fruits { get; set; }

        public FruitContext(DbContextOptions<FruitContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fruit>()
                .ToTable("fruit");

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