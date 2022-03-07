using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Service.Exceptions;
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

        public async Task<T> AddAsync(T entity)
        {
            
              await _repository.AddAsync(entity);
              await _unitOfWork.CommitAsync();
              return entity;
            
        }

        public async Task<IEnumerable<T>> AddRangeAsyn(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        //For Extra Custom 
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
           return await _repository.AnyAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        //Try Catch Control Generic.
        public async Task<T> GetByIdAsyn(int id)
        {
            var hasProduct= await _repository.GetByIdAsyn(id);
            if (hasProduct==null)
            {
                throw new ClientSideException($"{typeof(T).Name} Not Found");

            }
            return hasProduct;
        }

        public async Task RemoveAsync(T entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();   
        }

        public async Task RemoveRangeAsyn(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            
            return _repository.Where(expression);
        }

        
    }
}
