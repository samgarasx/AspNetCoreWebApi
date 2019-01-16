using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApi.Entities
{
    public class FruitContext : DbContext
    {
        public DbSet<FruitEntity> Fruits { get; set; }

        public FruitContext(DbContextOptions<FruitContext> options)
            : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FruitEntity>()
                .ToTable("fruit");

            modelBuilder.Entity<FruitEntity>()
                .Property(f => f.Id)
                .HasColumnName("id");

            modelBuilder.Entity<FruitEntity>()
                .Property(f => f.No)
                .IsRequired()
                .HasColumnName("no");

            modelBuilder.Entity<FruitEntity>()
                .Property(f => f.Description)
                .HasColumnName("description");

            modelBuilder.Entity<FruitEntity>()
                .HasIndex(f => f.No)
                .IsUnique();
        }
    }
}
