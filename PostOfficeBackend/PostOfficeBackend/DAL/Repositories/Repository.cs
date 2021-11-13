using Microsoft.EntityFrameworkCore;
using PostOfficeBackend.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PostOfficeBackend.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            Context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<List<T>> GetAllAsync(
                    Expression<Func<T, bool>> filterBy = null,
                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                    string includeProperties = null)
        {
            IQueryable<T> query = _dbSet;

            if (filterBy != null)
            {
                query = query.Where(filterBy);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(',', StringSplitOptions.TrimEntries))
                {
                    query = query.Include(property);
                }
            }

            return await query.ToListAsync();
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<T> GetSingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
