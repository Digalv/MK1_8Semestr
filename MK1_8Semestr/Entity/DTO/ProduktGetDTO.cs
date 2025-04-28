namespace MK1_8Semestr.Entity.DTO
{
    public class ProduktGetDTO
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public int Amount { get; set; }
        public Guid? BrandId { get; set; }
        public List<Guid>? CategoriesId { get; set; }
    }
}
