using Booking.Domain.Aggregates.VenueAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Infrastructure.EntityConfigurations
{
    internal class BookingStatusEntityTypeConfiguration : IEntityTypeConfiguration<BookingStatus>
    {
        public void Configure(EntityTypeBuilder<BookingStatus> builder)
        {
            builder.ToTable("BookingStatuses");

            builder.HasKey(e => e.Id)
                .HasName("BookingStatusId");

            builder.Property(e => e.Id)
                .ValueGeneratedNever();

            builder.Property<string>("_code")
                .HasColumnName("Code")
                .HasMaxLength(BookingStatus.MaxCodeLenght);

            builder.Property(e => e.CreationDate);

            builder.Property(e => e.ModificationDate)
                .HasDefaultValueSql("(getutcdate())")
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken();

            builder.Property<string>("_name")
                .HasColumnName("Name")
                .HasMaxLength(BookingStatus.MaxNameLenght);
        }
    }
}
