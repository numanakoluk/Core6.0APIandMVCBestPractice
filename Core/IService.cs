using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IService<T> where T : class
    {
        Task<T> GetByIdAsyn(int id);
       
        Task<IEnumerable<T>> GetAllAsyn();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<T> AddAsync(T entity);

        Task<T> AddRangeAsyn(IEnumerable<T> entities);

        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);

        Task<T> RemoveRangeAsyn(IEnumerable<T> entities);
        

    }
}
