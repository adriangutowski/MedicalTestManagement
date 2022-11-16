using Booking.Domain.Common;
using Booking.Domain.Exceptions;

namespace Booking.Domain.Aggregates.VenueAggregate
{
    public class Venue : Entity, IAggregateRoot
    {
        public const int MaxCodeLenght = 10;

        public const int MaxNameLenght = 50;

        private string _code;

        private string _name;

        private readonly List<TestBooking> _testBookings;

        private readonly List<VenueAllocation> _venueAllocations;

        private Venue()
        {
        }

        public Venue(string code, string name)
        {
            SetCode(code);
            SetName(name);
            _testBookings = new();
            _venueAllocations = new();
        }

        public string GetCode() => _code;

        private void SetCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code) || code.Length > MaxCodeLenght)
            {
                throw new BookingDomainException("Code is not valid");  
            }

            _code = code;
        }

        public string GetName() => _name;

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length > MaxNameLenght)
            {
                throw new BookingDomainException("Name is not valid");
            }

            _name = name;
        }

        public void SetBookingCapacity(DateTime allocationDate, int maximumCapacity)
        {
            var existingAllocation = _venueAllocations.Find(i => i.GetAllocationDate() == allocationDate);

            if (existingAllocation != null)
            {
                existingAllocation.SetAllocationDate(allocationDate);
                existingAllocation.SetMaximumCapacity(maximumCapacity);
            }
            else
            {
                var newAllocation = new VenueAllocation(allocationDate, maximumCapacity);
                _venueAllocations.Add(newAllocation);
            }
        }

        public IEnumerable<DateTime> GetAvailableBookingDates()
        {
            if(_venueAllocations.Count == 0)
            {
                throw new BookingDomainException("There are no booking dates available for this venue");
            }

            if(_testBookings.Count == 0)
            {
                return _venueAllocations
                    .Where(i => !i.IsPastDate())
                    .Select(i => i.GetAllocationDate());
            }

            var allocatedCapacity = _venueAllocations.Where(i => !i.IsPastDate());

            var bookedCapacity = _testBookings.Where(i => !(i.IsPastDate() || i.IsCanceled()));

            return allocatedCapacity.GroupJoin(bookedCapacity, i => i.GetAllocationDate(), i => i.GetBookingDate(), (allocation, bookings) => new
                {
                    AllocatedDate = allocation.GetAllocationDate(),
                    AvailableCapacity = allocation.GetMaximumCapacity() - bookings.Count()
                })
                .Where(i => i.AvailableCapacity > 0)
                .Select(i => i.AllocatedDate);
        }

        public void BookTest(string identityCardNumber, DateTime bookingDate)
        {
            if (GetAvailableBookingDates().Contains(bookingDate))
            {
                var newBooking = new TestBooking(identityCardNumber, bookingDate);
                _testBookings.Add(newBooking);
            }
            else
            {
                throw new BookingDomainException("Booking date is no longer available");
            }
        }
    }
}
