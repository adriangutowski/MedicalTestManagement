namespace Booking.Domain.Common
{
    public abstract class Enumeration : Entity, IComparable
    {
        private string _name;

        protected Enumeration()
        {
        }

        protected Enumeration(int id, string name)
        {
            Id = id;
            SetName(name);
        }

        public string GetName() => _name;

        protected virtual void SetName(string name) => _name = name;

        public override string ToString() => _name;

        public override int GetHashCode() => Id.GetHashCode();

        public int CompareTo(object? obj) => Id.CompareTo((obj as Enumeration)?.Id);

        public override bool Equals(object? obj) => obj is Enumeration enumeration && Id == enumeration.Id;
    }
}
