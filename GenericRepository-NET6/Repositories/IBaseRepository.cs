using System.Linq.Expressions;

namespace GenericRepository_NET6.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> Add(T entity);
        Task AddRange(IEnumerable<T> entities);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        List<T> GetAll();
        Task<T> GetById(int id);
        Task<T> Update(T entity);
        Task Remove(T entity);
        Task RemoveRange(IEnumerable<T> entities);
    }
}