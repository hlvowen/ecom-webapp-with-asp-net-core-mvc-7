using tflame69.Models.dbo;

namespace tlfame69.DataAccess.Repository.IRepository;

public interface IProductRepository : IRepository<Product>
{
    void Update(Product product);
}