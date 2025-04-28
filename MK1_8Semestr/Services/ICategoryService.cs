using MK1_8Semestr.Entity.DTO;
using MK1_8Semestr.Entity;

namespace MK1_8Semestr.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategories();
        Task<Category> GetCategory(Guid id);
        Task<Guid> CreateCategory(CategoryDTO categoryDTO);
        Task EditCategory(Guid id, CategoryDTO categoryDTO);
        Task DeleteCategory(Guid id);
    }
}
