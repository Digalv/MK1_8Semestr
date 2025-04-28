namespace MK1_8Semestr.Exceptions
{
    public class ObjectiveExistException : Exception
    {
        
        public string Field { get; }
        public string Description { get; }

        public ObjectiveExistException(string field, string description)
        {
            Field = field;
            Description = description;
        }
    }
}
