namespace MK1_8Semestr.Exceptions
{
    public class NotFoundException : Exception
    {
        public string Field { get; }
        public string Description { get; }

        public NotFoundException(string field, string description)
        {
            Field = field;
            Description = description;
        }
    }
}
