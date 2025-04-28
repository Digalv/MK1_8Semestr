using System.ComponentModel.DataAnnotations;

namespace MK1_8Semestr.Entity.DTO
{
    public class ProduktChangeDTO
    {
        public required string Title { get; set; }
        
        [Range(0, int.MaxValue, ErrorMessage = "Amount must be non-negative.")]
        public int Amount { get; set; }
        public Guid? BrandId { get; set; }
        public List<Guid>? CategoriesId { get; set; }
    }
}
