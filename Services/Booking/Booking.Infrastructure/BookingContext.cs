using Booking.Domain.Aggregates.VenueAggregate;
using Booking.Domain.Common;
using Booking.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure
{
    public class BookingContext : DbContext
    {
        public DbSet<Venue> Venues { get; set; }

        public DbSet<VenueAllocation> VenueAllocations { get; set; }

        public DbSet<TestBooking> TestBookings { get; set; }

        public DbSet<BookingStatus> BookingStatuses { get; set; }

        //public BookingContext(DbContextOptions<BookingContext> options) : base(options)
        //{
        //}

        public BookingContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VenuEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VenueAllocationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BookingStatusEntityTypeConfiguration());

            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(IEntityTypeConfiguration<Entity>).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Booking");
            }
        }

    }
}
