using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using tlfame69.DataAccess.Repository.IRepository;

namespace tlfame69.DataAccess.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _applicationDbContext;
    private DbSet<T> _dbSet;

    public Repository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
        this._dbSet = _applicationDbContext.Set<T>();
    }
    
    public IEnumerable<T> GetAll(string? includeProperties = null)
    {
        IQueryable<T> query = this._dbSet;
        
        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (string includeProperty in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }
        
        return query.ToList();
    }

    public T? GetFirstOrDefault(Expression<Func<T, bool>> filters, string? includeProperties = null)
    {
        IQueryable<T> query = this._dbSet;
        query = query.Where(filters);

        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (string includeProperty in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }
        
        return query.FirstOrDefault();
    }

    public void Add(T entity)
    {
        this._dbSet.Add(entity);
    }

    public void Remove(T entity)
    {
        this._dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        this._dbSet.RemoveRange(entities);
    }
}