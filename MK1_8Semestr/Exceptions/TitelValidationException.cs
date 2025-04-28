namespace MK1_8Semestr.Exceptions
{
    public class TitelValidationException : Exception
    {
        public string Field { get; }
        public string Description { get; }

        public TitelValidationException(string field, string description)
        {
            Field = field;
            Description = description;
        }

    }
}
