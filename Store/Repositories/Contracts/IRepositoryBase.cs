using System.Linq.Expressions;

namespace Repositories.Contracts
{

    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);

        //ilgili kural  1
        T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);

        void Remove(T entity);

        void Update(T entity);

    }

}
