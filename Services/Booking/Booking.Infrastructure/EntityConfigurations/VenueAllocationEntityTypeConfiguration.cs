using Booking.Domain.Aggregates.VenueAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.EntityConfigurations
{
    internal class VenueAllocationEntityTypeConfiguration : IEntityTypeConfiguration<VenueAllocation>
    {
        public void Configure(EntityTypeBuilder<VenueAllocation> builder)
        {
            builder.ToTable("VenueAllocations");

            builder.HasKey(e => e.Id)
                .HasName("TestBookingId");

            builder.Property<DateTime>("_allocationDate")
                .HasColumnName("AllocationDate")
                .HasColumnType("date");

            builder.Property(e => e.CreationDate);

            builder.Property(e => e.ModificationDate)
                .IsConcurrencyToken();

            builder.Property<int>("_maximumCapacity")
                .HasColumnName("MaximumCapacity");

            //builder.Property<int>("_venueId")
            //    .HasColumnName("VenueId");

            //builder.HasOne<Venue>()
            //    .WithMany()
            //    .HasForeignKey("VenueId");
        }
    }
}
