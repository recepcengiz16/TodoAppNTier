using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.Entities.Concrete;

namespace TodoAppNTier.DataAccess.Interfaces
{
    public interface IRepository<T> where T:BaseEntity
    {
        Task<List<T>> GetAll();
        Task<T> Find(int id);
        Task<T> GetByFilter(Expression<Func<T,bool>> expression, bool asNotracking=false);
        Task Create(T entity);
        void Update(T entity, T unchanged);
        void Remove(T entity);
        IQueryable<T> GetQuery();
    }
}
