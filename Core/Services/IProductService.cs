using Core.DTOs;
using Core.Models;

namespace Core.Services
{
    public interface IProductService : IService<Product>
    {
        //MVC Data
        Task<List<ProductWithCategoryDto>> GetProductsWithCategory();
    }
}
