using Booking.Domain.Common;
using Booking.Domain.Exceptions;

namespace Booking.Domain.Aggregates.VenueAggregate
{
    public class TestBooking : Entity
    {
        public const int MaxIdentityCardNumberLenght = 50;

        private DateTime _bookingDate;

        private string _identityCardNumber;

        private int _bookingStatusId;

        public BookingStatus BookingStatus { get; private set; }

        private TestBooking()
        {
        }

        public TestBooking(string identityCardNumber, DateTime bookingDate)
        {
            SetBookingDate(bookingDate);
            SetIdentityCardNumber(identityCardNumber);
            _bookingStatusId = BookingStatus.Booked.Id;
        }

        public void SetIdentityCardNumber(string identityCardNumber)
        {
            if (string.IsNullOrWhiteSpace(identityCardNumber) || identityCardNumber.Length > MaxIdentityCardNumberLenght)
            {
                throw new BookingDomainException("Identity card number is not valid");
            }

            _identityCardNumber = identityCardNumber;
        }

        public DateTime GetBookingDate() => _bookingDate;

        public void SetBookingDate(DateTime bookingDate)
        {
            if (bookingDate.Date < DateTime.UtcNow.Date)
            {
                throw new BookingDomainException("Booking date is not valid");
            }

            _bookingDate = bookingDate;
        }

        public bool IsPastDate() => _bookingDate.Date < DateTime.UtcNow.Date;

        public bool IsCanceled() => _bookingStatusId == BookingStatus.Cancelled.Id;

        private void SetCanceledStatus()
        {
            if(_bookingStatusId != BookingStatus.Booked.Id)
            {
                StatusChangeException(BookingStatus.Cancelled);
            }

            _bookingStatusId = BookingStatus.Cancelled.Id;
        }

        private void SetPerformedStatus()
        {
            if(_bookingStatusId != BookingStatus.Booked.Id)
            {
                StatusChangeException(BookingStatus.Performed);
            }

            _bookingStatusId = BookingStatus.Performed.Id;
        }

        private void SetOutcomeStatus()
        {
            if (_bookingStatusId != BookingStatus.Performed.Id)
            {
                StatusChangeException(BookingStatus.Outcome);
            }

            _bookingStatusId = BookingStatus.Outcome.Id;
        }

        private void StatusChangeException(BookingStatus newBookingStatus)
        {
            throw new BookingDomainException($"Cannot change booking status from {BookingStatus.GetName()} to {newBookingStatus.GetName()}");
        }
    }
}
