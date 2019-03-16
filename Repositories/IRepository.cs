using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");

        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");

        IEnumerable<TEntity> GetPage(int pageSize, int pageNumber, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, bool>> filter = null, string includeProperties = "");
        Task<IEnumerable<TEntity>> GetPageAsync(int pageSize, int pageNumber, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, bool>> filter = null, string includeProperties = "");

        TEntity Find(Expression<Func<TEntity, bool>> match);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match);

        TEntity GetById(object id);
        Task<TEntity> GetByIdAsync(object id);
        EntityEntry<TEntity> Add(TEntity entity);
        bool AddRange(IEnumerable<TEntity> entities);
        bool AddAll(IEnumerable<TEntity> tList);
        TEntity Update(TEntity entity);
        IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities);
        bool DeleteRange(IEnumerable<TEntity> entities);
        long Count();
    }
}
