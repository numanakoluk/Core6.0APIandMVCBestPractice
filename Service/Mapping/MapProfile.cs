using AutoMapper;
using Core.DTOs;
using Core.Models;

namespace Service.Mapping
{
    //Add MVC And API just Project Public
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap(); //JUST THE opposite
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>(); //Update Entity

            //Mapping for category
            CreateMap<Product, ProductWithCategoryDto>().ReverseMap();

            //CategoryByIdProduct
            CreateMap<Category, CategoryWithProductsDto>();

        }
    }
}
