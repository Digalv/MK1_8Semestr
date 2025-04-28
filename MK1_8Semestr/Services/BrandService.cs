using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MK1_8Semestr.Context;
using MK1_8Semestr.Entity;
using MK1_8Semestr.Entity.DTO;
using MK1_8Semestr.Exceptions;
using System.Drawing.Drawing2D;
using System.Linq.Expressions;

namespace MK1_8Semestr.Services
{
    public class BrandService : IBrandService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public BrandService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> CreateBrand(BrandDTO brandDTO)
        {
            if (BrandExists(brandDTO.Title))
            {
                throw new ObjectiveExistException(nameof(brandDTO.Title), "Brand with this Name is exist");
            }
            if (string.IsNullOrWhiteSpace(brandDTO.Title) || brandDTO.Title.Length < 3 || brandDTO.Title.Length > 50)
            {
                throw new TitelValidationException(nameof(brandDTO.Title), "Brand with this Name ist exist");
            }
            var brand = _mapper.Map <Brand>(brandDTO);
            brand.Id = Guid.NewGuid();

            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();

            return brand.Id;
        }

        public async Task DeleteBrand(Guid id)
        {

            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
            {
                throw new NotFoundException(nameof(brand.Id), "Brand not found");
            }

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
        }

        public async Task EditBrand(Guid id, BrandDTO brandDTO)
        {
            try
            {
                var brand = await _context.Brands.FindAsync(id);
                brand.Title = brandDTO.Title;
                _context.Update(brand);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new NotFoundException(nameof(brandDTO.Title), "Brand not found");
            }
            
        }

        public async Task<Brand> GetBrand(Guid id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
            {
                throw new Exception();
            }
            return brand;
        }

        public  async Task<List<Brand>> GetBrands()
        {
            var brands = await _context.Brands.ToListAsync();
            return brands;
        }
        private bool BrandExists(string title)
        {
            return _context.Brands.FirstOrDefault(e => e.Title.ToLower() == title.ToLower()) is null ? false : true;
        }
    }
}
