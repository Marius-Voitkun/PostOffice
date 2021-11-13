using Microsoft.EntityFrameworkCore;
using PostOfficeBackend.Models;

namespace PostOfficeBackend.DAL
{
    public class DataContext : DbContext
    {
        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<ParcelLocker> ParcelLockers { get; set; }

        public DataContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parcel>()
                .Property(p => p.ReceiverName)
                .IsRequired()
                .HasMaxLength(55);

            modelBuilder.Entity<Parcel>()
                .Property(p => p.ReceiverPhone)
                .HasColumnType("char")
                .IsRequired()
                .HasMaxLength(12)
                .IsFixedLength();

            modelBuilder.Entity<Parcel>()
                .Property(p => p.WeightInKg)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ParcelLocker>()
                .Property(pl => pl.Code)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<ParcelLocker>()
                .Property(pl => pl.Town)
                .IsRequired()
                .HasMaxLength(55);

            modelBuilder.Entity<Parcel>()
                .HasOne(p => p.ParcelLocker)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
