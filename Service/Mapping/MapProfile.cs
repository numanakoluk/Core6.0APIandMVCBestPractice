using AutoMapper;
using Core.DTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapping
{
    //Add MVC And API just Project Public
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap(); //JUST THE opposite
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
            CreateMap<ProductDto, Product>(); //Update Entity
        }
    }
}
