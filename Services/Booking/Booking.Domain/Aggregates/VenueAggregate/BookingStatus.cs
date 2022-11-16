using Booking.Domain.Common;
using Booking.Domain.Exceptions;

namespace Booking.Domain.Aggregates.VenueAggregate
{
    public class BookingStatus : Enumeration
    {
        public const int MaxNameLenght = 50;

        public const int MaxCodeLenght = 10;

        public static readonly BookingStatus Booked = new(1, nameof(Booked));

        public static readonly BookingStatus Cancelled = new(2, nameof(Cancelled));

        public static readonly BookingStatus Performed = new(3, nameof(Performed));

        public static readonly BookingStatus Outcome = new(4, nameof(Outcome));

        public static IEnumerable<BookingStatus> List() => new[] { Booked, Cancelled, Performed, Outcome };

        private string _code;

        private BookingStatus()
        {
        }

        private BookingStatus(int id, string name) : base(id, name)
        {
            SetName(name);
        }

        protected override void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length > MaxNameLenght)
            {
                throw new BookingDomainException("Name is not valid");
            }

            base.SetName(name);
        }

        public string GetCode() => _code;

        public void SetCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code) || code.Length > MaxCodeLenght)
            {
                throw new BookingDomainException("Code is not valid");
            }

            _code = code;
        }
    }
}
