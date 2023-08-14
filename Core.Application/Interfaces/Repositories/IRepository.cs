using System.Linq.Expressions;

namespace Core.Application.Interfaces.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    //abstract Task<IEnumerable<TEntity>> GetAll();

    abstract Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> clause = null, params Expression<Func<TEntity, object>>[] includes);

    abstract Task<TEntity> GetById(int id);
    abstract Task Create(TEntity entity);
    abstract Task Update(TEntity entity);
    abstract Task Delete(int id);
    abstract Task<bool> Exists(int id);
}
