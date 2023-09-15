using System.Linq.Expressions;

namespace tlfame69.DataAccess.Repository.IRepository;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll(string? includeProperties = null);
    T? GetFirstOrDefault(Expression<Func<T, bool>> filters, string? includeProperties = null);
    void Add(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
}