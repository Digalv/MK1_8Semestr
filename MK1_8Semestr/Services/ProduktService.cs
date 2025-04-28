using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MK1_8Semestr.Context;
using MK1_8Semestr.Entity;
using MK1_8Semestr.Entity.DTO;
using MK1_8Semestr.Exceptions;

namespace MK1_8Semestr.Services
{
    public class ProduktService : IProduktService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProduktService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> CreateProdukt(ProduktChangeDTO produktChangeDTO)
        {
            if (ProduktExists(produktChangeDTO.Title))
            {
                throw new ObjectiveExistException(nameof(produktChangeDTO.Title), "Produkt with this name is exist");
            }
            if (string.IsNullOrWhiteSpace(produktChangeDTO.Title) || produktChangeDTO.Title.Length < 3 || produktChangeDTO.Title.Length > 50)
            {
                throw new TitelValidationException(nameof(produktChangeDTO.Title), "Produkt with this name is exist");
            }
            var produkt = _mapper.Map<Produkt>(produktChangeDTO);
            produkt.Id = Guid.NewGuid();
            if (produktChangeDTO.BrandId is not null)
            {
                var brand = await _context.Brands.FindAsync(produktChangeDTO.BrandId);
                if (brand is null)
                {
                    throw new NotFoundException(nameof(produktChangeDTO.BrandId), "Brand not found");
                }
                produkt.Brand = brand; 
            }
            if (produktChangeDTO.CategoriesId is not null)
            {
                var categories = await _context.Categories
                    .Where(c => produktChangeDTO.CategoriesId.Contains(c.Id))
                    .ToListAsync();

                if (categories.Count != produktChangeDTO.CategoriesId.Count)
                {
                    throw new NotFoundException(nameof(produktChangeDTO.BrandId), "One of the category not found");
                }

                produkt.Categories = categories;
            }

            _context.Produkts.Add(produkt);
            await _context.SaveChangesAsync();
            return produkt.Id;
        }

        public async Task DeleteProdukt(Guid id)
        {
            var produkt = await _context.Produkts.FindAsync(id);
            if(produkt == null)
            {
                throw new NotFoundException(nameof(Produkt.Id), "This product was not found");
            }
            _context.Produkts.Remove(produkt);
            await _context.SaveChangesAsync();
        }

        public async Task EditProdukt(Guid id, ProduktChangeDTO produktChangeDTO)
        {
            try
            {
                var produkt = await _context.Produkts.FindAsync(id);
                produkt.Title = produktChangeDTO.Title;
                produkt.Amount = produktChangeDTO.Amount;
                if (produktChangeDTO.BrandId is not null)
                {
                    var brand = await _context.Brands.FindAsync(produktChangeDTO.BrandId);
                    if (brand is null)
                    {
                        throw new NotFoundException(nameof(produktChangeDTO.BrandId), "Brand not found");
                    }
                    produkt.Brand = brand;
                }
                if (produktChangeDTO.CategoriesId is not null)
                {
                    var categories = await _context.Categories
                        .Where(c => produktChangeDTO.CategoriesId.Contains(c.Id))
                        .ToListAsync();

                    if (categories.Count != produktChangeDTO.CategoriesId.Count)
                    {
                        throw new NotFoundException(nameof(produktChangeDTO.BrandId), "One of the category not found");
                    }

                    produkt.Categories = categories;
                }
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new NotFoundException(nameof(Produkt.Id), "This product was not found");
            }
        }

        public async Task<List<Produkt>> GetProduktByCategories(List<Guid> categories)
        {
            var produkts = await _context.Produkts
                .Where(p => p.Categories.Any(c => categories.Contains(c.Id)))
                .ToListAsync();

            return produkts.OrderByDescending(p => p.Amount).ToList();
        }

        public async Task<List<Produkt>> GetProduktByBrand(Guid brandId)
        {
            List<Produkt> produkts = await _context.Produkts
                .Where(p => p.Brand.Id == brandId)
                .ToListAsync();

            return produkts.OrderByDescending(p => p.Amount).ToList();
        }
        private bool ProduktExists(string title)
        {
            return _context.Produkts.FirstOrDefault(e => e.Title.ToLower() == title.ToLower()) is null ? false : true;
        }
    }
}
