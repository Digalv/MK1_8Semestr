using AutoMapper;
using MK1_8Semestr.Entity;
using MK1_8Semestr.Entity.DTO;

namespace MK1_8Semestr.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BrandDTO, Brand>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<ProduktChangeDTO, Produkt>();
            CreateMap<Produkt, ProduktGetDTO>();
        }
    }
}
