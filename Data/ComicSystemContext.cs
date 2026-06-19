using ComicSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ComicSystem.Data;

public class ComicSystemContext : DbContext
{
    public ComicSystemContext(DbContextOptions<ComicSystemContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<ComicBook> ComicBooks => Set<ComicBook>();
    public DbSet<Rental> Rentals => Set<Rental>();
    public DbSet<RentalDetail> RentalDetails => Set<RentalDetail>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customers");
            entity.HasKey(e => e.CustomerID);
        });

        modelBuilder.Entity<ComicBook>(entity =>
        {
            entity.ToTable("ComicBooks");
            entity.HasKey(e => e.ComicBookID);
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.ToTable("Rentals");
            entity.HasKey(e => e.RentalID);
            entity.HasOne(e => e.Customer)
                .WithMany(c => c.Rentals)
                .HasForeignKey(e => e.CustomerID);
        });

        modelBuilder.Entity<RentalDetail>(entity =>
        {
            entity.ToTable("RentalDetails");
            entity.HasKey(e => e.RentalDetailID);
            entity.HasOne(e => e.Rental)
                .WithMany(r => r.RentalDetails)
                .HasForeignKey(e => e.RentalID);
            entity.HasOne(e => e.ComicBook)
                .WithMany(c => c.RentalDetails)
                .HasForeignKey(e => e.ComicBookID);
        });
    }
}
