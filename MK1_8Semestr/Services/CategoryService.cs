using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MK1_8Semestr.Context;
using MK1_8Semestr.Entity;
using MK1_8Semestr.Entity.DTO;
using MK1_8Semestr.Exceptions;

namespace MK1_8Semestr.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CategoryService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> CreateCategory(CategoryDTO categoryDTO)
        {
            if (CategoryExists(categoryDTO.Title))
            {
                throw new ObjectiveExistException(nameof(categoryDTO.Title), "Produkt with this name is exist");
            }
            if (string.IsNullOrWhiteSpace(categoryDTO.Title) || categoryDTO.Title.Length < 3 || categoryDTO.Title.Length > 50)
            {
                throw new TitelValidationException(nameof(categoryDTO.Title), "Produkt with this name is exist");
            }
            var category = _mapper.Map<Category>(categoryDTO);
            category.Id = Guid.NewGuid();

            _context.Add(category);
            await _context.SaveChangesAsync();

            return category.Id;
        }

        public async Task DeleteCategory(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                throw new NotFoundException(nameof(category.Id), "Category not found");
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task EditCategory(Guid id, CategoryDTO categoryDTO)
        {
            try
            {
                var category = await _context.Categories.FindAsync(id);
                category.Title = categoryDTO.Title;
                _context.Update(category);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new NotFoundException(nameof(categoryDTO.Title), "Category not found");
            }
        }

        public async Task<Category> GetCategory(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                throw new Exception("Category not found.");
            }
            return category;
        }

        public async Task<List<Category>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }
        private bool CategoryExists(string title)
        {
            return _context.Categories.FirstOrDefault(e => e.Title.ToLower() == title.ToLower()) is null ? false : true;
        }
    }
}
