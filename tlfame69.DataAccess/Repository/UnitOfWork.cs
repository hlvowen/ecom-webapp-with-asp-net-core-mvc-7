using tlfame69.DataAccess.Repository.IRepository;

namespace tlfame69.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _applicationDbContext;
    public ICategoryRepository CategoryRepository { get; private set; }
    public IProductRepository ProductRepository { get; private set; }

    public UnitOfWork(ApplicationDbContext applicationDbContext)
    {
        this._applicationDbContext = applicationDbContext;
        this.CategoryRepository = new CategoryRepository(this._applicationDbContext);
        this.ProductRepository = new ProductRepository(this._applicationDbContext);
    }
    
    public void Save()
    {
        this._applicationDbContext.SaveChanges();
    }
}