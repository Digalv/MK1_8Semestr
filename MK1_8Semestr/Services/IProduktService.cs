using MK1_8Semestr.Entity;
using MK1_8Semestr.Entity.DTO;

namespace MK1_8Semestr.Services
{
    public interface IProduktService
    {
        Task<Guid> CreateProdukt(ProduktChangeDTO produktChangeDTO);
        Task EditProdukt(Guid id, ProduktChangeDTO produktChangeDTO);
        Task DeleteProdukt(Guid id);
        Task<List<Produkt>> GetProduktByBrand(Guid brandId);
        Task<List<Produkt>> GetProduktByCategories(List<Guid> categories);
    }
}
