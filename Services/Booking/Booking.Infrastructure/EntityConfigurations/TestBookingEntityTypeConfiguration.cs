using Booking.Domain.Aggregates.VenueAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Infrastructure.EntityConfigurations
{
    internal class TestBookingEntityTypeConfiguration : IEntityTypeConfiguration<TestBooking>
    {
        public void Configure(EntityTypeBuilder<TestBooking> builder)
        {
            builder.ToTable("TestBookings");

            builder.HasKey(e => e.Id)
                .HasName("TestBookingId");

            builder.Property<string>("_identityCardNumber")
                .HasMaxLength(TestBooking.MaxIdentityCardNumberLenght);

            builder.Property(e => e.CreationDate);

            builder.Property(e => e.ModificationDate)
                .IsConcurrencyToken();

            builder.Property<DateTime>("_bookingDate")
                .HasColumnName("BookingDate")
                .HasColumnType("date");

            builder.Property<int>("_bookingStatusId")
                .HasColumnName("BookingStatusId");

            builder.HasOne(o => o.BookingStatus)
                .WithMany()
                .HasForeignKey("BookingStatusId");

            //builder.Property<int>("_venueId")
            //    .HasColumnName("VenueId");

            //builder.HasOne<Venue>()
            //    .WithMany()
            //    .HasForeignKey("VenueId");
        }
    }
}
