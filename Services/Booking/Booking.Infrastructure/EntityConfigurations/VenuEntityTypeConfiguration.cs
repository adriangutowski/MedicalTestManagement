using Booking.Domain.Aggregates.VenueAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Infrastructure.EntityConfigurations
{
    internal class VenuEntityTypeConfiguration : IEntityTypeConfiguration<Venue>
    {
        public void Configure(EntityTypeBuilder<Venue> builder)
        {
            builder.ToTable("Venues");

            builder.HasKey(e => e.Id).
                HasName("VenueId");

            builder.Property<string>("_code")
                .HasColumnName("Code")
                .HasMaxLength(Venue.MaxCodeLenght);

            builder.Property(e => e.CreationDate);

            builder.Property(e => e.ModificationDate)
                .IsConcurrencyToken();

            builder.Property<string>("_name")
                .HasColumnName("Name")
                .HasMaxLength(Venue.MaxNameLenght);

            builder.HasMany<TestBooking>("_testBookings")
                .WithOne()
                .IsRequired();

            builder.HasMany<VenueAllocation>("_venueAllocations")
                .WithOne()
                .IsRequired();
        }
    }
}
