using tflame69.Models.dbo;
using tlfame69.DataAccess.Repository.IRepository;

namespace tlfame69.DataAccess.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    
    public CategoryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        this._applicationDbContext = applicationDbContext;
    }

    public void Update(Category category)
    {
        this._applicationDbContext.Update(category);
    }
}