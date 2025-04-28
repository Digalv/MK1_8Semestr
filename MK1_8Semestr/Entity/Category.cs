namespace MK1_8Semestr.Entity
{
    public class Category
    {
        public Guid Id { get; set; }
        public required String Title { get; set; }
        public List<Produkt> Produkts { get; set; }
    }
}
