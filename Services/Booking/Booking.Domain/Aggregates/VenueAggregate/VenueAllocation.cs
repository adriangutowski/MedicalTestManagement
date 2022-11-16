using Booking.Domain.Common;
using Booking.Domain.Exceptions;

namespace Booking.Domain.Aggregates.VenueAggregate
{
    public class VenueAllocation : Entity
    {
        private DateTime _allocationDate;

        private int _maximumCapacity;

        private VenueAllocation()
        {
        }

        public VenueAllocation(DateTime allocationDate, int maximumCapacity)
        {
            SetAllocationDate(allocationDate);
            SetMaximumCapacity(maximumCapacity);
        }

        public DateTime GetAllocationDate() => _allocationDate;

        public void SetAllocationDate(DateTime allocationDate)
        {
            if (allocationDate.Date < DateTime.UtcNow.Date)
            {
                throw new BookingDomainException("Allocation date is not valid");
            }

            _allocationDate = allocationDate;
        }

        public int GetMaximumCapacity() => _maximumCapacity;

        public void SetMaximumCapacity(int maximumCapacity)
        {
            if (maximumCapacity <= 0)
            {
                throw new BookingDomainException("Maximum capacity is not valid");
            }

            _maximumCapacity = maximumCapacity;
        }

        public bool IsPastDate() => _allocationDate.Date < DateTime.UtcNow.Date;
    }
}
