using tflame69.Models.dbo;

namespace tlfame69.DataAccess.Repository.IRepository;

public interface ICategoryRepository : IRepository<Category>
{
    void Update(Category category);
}