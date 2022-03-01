using System.Linq.Expressions;

namespace Core.Repositories
{
    public interface IGenericRepository<T> where T : class 
    {
        //Asenkron olması için Task ve method ismi asyn
        Task<T> GetByIdAsyn(int id);

        //Direk toList diyebilirim.
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression);



        //productRepository.where(x=>x.id>5).OrderBy.ToListAsync();
        IQueryable<T> Where(Expression<Func<T,bool>> expression);

        //True false dönecek
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression); 


        Task<T> AddAsync(T entity);

        //Birden fazla ekleme için.
         Task<T> AddRangeAsyn(IEnumerable<T> entities);

        void Remove(T entity);

        //Birden fazla data silmek için.
        Task<T> RemoveRangeAsyn(IEnumerable<T> entities); 
        void Update(T entity);

        


    }
}
