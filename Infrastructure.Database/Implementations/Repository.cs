using Core.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Database.Implementations
{
    internal abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly BankApi_DbContext context;
        public Repository(BankApi_DbContext context) => this.context = context;


        public virtual async Task Create(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task Delete(int id)
        {
            var entity = context.Set<TEntity>().Find(id);
            if (entity != null)
            {
                context.Set<TEntity>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public virtual async Task Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync();
        }

        //public virtual async Task<IEnumerable<TEntity>> GetAll() => await context.Set<TEntity>().ToListAsync(); //TODO  ToListAsync

        public virtual async Task<TEntity> GetById(int id) => await context.Set<TEntity>().FindAsync(id);
        public virtual async Task<bool> Exists(int id) => await context.Set<TEntity>().FindAsync(id) != null;
        public virtual async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> clause = null, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = context.Set<TEntity>().AsQueryable();

            if (clause != null)
            {
                query = query.Where(clause);
            }

            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));

            }
            return await query.AsNoTracking().ToListAsync();
        }
    }
}
