using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        //SaveChanges Method for UnitOfWork Imp 
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOFWork _unitOfWork;

        //Just Ctor
        public Service(IGenericRepository<T> repository, IUnitOFWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> AddRangeAsyn(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsyn(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> RemoveRangeAsyn(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
