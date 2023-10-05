using AutoMapper;
using E_Commerce.DTOs;
using E_Commerce.Entities;

namespace E_Commerce.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product,ProductToReturnDTO>()
                .ForMember(d=>d.ProductBrand,o=>o.MapFrom(s=>s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d=>d.PictureUrl,o=>o.MapFrom<ProductUrlResolver>());
        }
    }
}
