using Core.Models;

namespace Core.Repositories
{
    //Special or customer for Product
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetProductsWithCategory();
    }
}
