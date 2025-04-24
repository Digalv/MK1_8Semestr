namespace MK1_8Semestr.Entity
{
    public class Produkt
    {
        public Guid Id { get; set; }
        public required string  Title  { get; set; }
        public int Amount { get; set; }
        public Brand? Brand { get; set; }
        public List<Category>? Categories { get; set; }
    }
}
