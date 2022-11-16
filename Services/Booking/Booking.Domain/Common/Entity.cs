namespace Booking.Domain.Common
{
    public abstract class Entity
    {
        public virtual int Id { get; protected set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
