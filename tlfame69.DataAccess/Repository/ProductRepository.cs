using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using tflame69.Models.dbo;
using tlfame69.DataAccess.Repository.IRepository;

namespace tlfame69.DataAccess.Repository;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    
    public ProductRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        this._applicationDbContext = applicationDbContext;
    }

    public void Update(Product product)
    {
        Product? updateProduct = _applicationDbContext.Product.FirstOrDefault(p => p.Id == product.Id);
        if (updateProduct is not null)
        {
            updateProduct.Title = product.Title;
            updateProduct.Description = product.Description;
            updateProduct.ISBN = product.ISBN;
            updateProduct.Author = product.Author;
            updateProduct.PriceList = product.PriceList;
            updateProduct.Price = product.Price;
            updateProduct.PriceForMoreThan50 = product.PriceForMoreThan50;
            updateProduct.PriceForMoreThan100 = product.PriceForMoreThan100;

            if (!string.IsNullOrEmpty(product.ImageUrl))
            {
                updateProduct.ImageUrl = product.ImageUrl;
            }
        }
    }
}