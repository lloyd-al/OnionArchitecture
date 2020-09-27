using AutoMapper;
using OnionArchitecture.Catalog.Application.DTOs;
using OnionArchitecture.Catalog.Core.Entities;

namespace OnionArchitecture.Catalog.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<Product, ProductDto>();
        }
    }
}