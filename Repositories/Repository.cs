using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using X.PagedList;

namespace Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal DbContext context;
        internal DbSet<TEntity> dbSet;

        public Repository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public EntityEntry<TEntity> Add(TEntity entity)
        {
            return dbSet.Add(entity);
        }

        public bool AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                dbSet.AddRange(entities);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

        public bool AddAll(IEnumerable<TEntity> tList)
        {
            try
            {
                dbSet.AddRange(tList);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public IEnumerable<TEntity> GetPage(int pageSize, int pageNumber, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return orderBy(query).ToPagedList(pageNumber, pageSize);
        }

        public async Task<IEnumerable<TEntity>> GetPageAsync(int pageSize, int pageNumber, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return await orderBy(query).ToPagedListAsync(pageNumber, pageSize);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> match)
        {
            return dbSet.SingleOrDefault(match);
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match)
        {
            return await dbSet.SingleOrDefaultAsync(match);
        }

        public TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public TEntity Update(TEntity entity)
        {
            try
            {
                dbSet.Attach(entity);
                var entry = context.Entry(entity);
                entry.State = EntityState.Modified;
                return entity;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }

            return null;
        }

        public IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                return null;
            try
            {
                foreach (var item in entities)
                {
                    dbSet.Attach(item);
                    var entry = context.Entry(item);
                    entry.State = EntityState.Modified;
                }

                return entities;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }

        public bool DeleteRange(IEnumerable<TEntity> entities)
        {
            try
            {
                dbSet.RemoveRange(entities);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

        public long Count()
        {
            return dbSet.Count();
        }
    }
}
