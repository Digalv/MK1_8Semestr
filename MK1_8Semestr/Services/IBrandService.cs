using Microsoft.AspNetCore.Mvc;
using MK1_8Semestr.Entity;
using MK1_8Semestr.Entity.DTO;

namespace MK1_8Semestr.Services
{
    public interface IBrandService
    {
         Task<List<Brand>> GetBrands();
         Task<Brand> GetBrand(Guid id);
         Task<Guid> CreateBrand(BrandDTO brandDTO);
         Task EditBrand(Guid id, BrandDTO brandDTO);
         Task DeleteBrand(Guid id);
    }
}
