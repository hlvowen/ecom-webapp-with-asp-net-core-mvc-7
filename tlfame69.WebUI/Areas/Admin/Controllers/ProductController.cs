using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using tflame69.Models.dbo;
using tlfame69.DataAccess.Repository.IRepository;
using tlfame69.WebUI.Areas.Admin.Models;

namespace tlfame69.WebUI.Controllers;

[Area("Admin")]
public class ProductController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _webHostEnvironment;
    
    public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
    {
        this._unitOfWork = unitOfWork;
        this._webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index()
    {
        List<Product> products = this._unitOfWork.ProductRepository.GetAll("Category").ToList();
        return View(products);
    }

    public IActionResult Upsert(int? id)
    {
        IEnumerable<SelectListItem> categorySelectOptions = this._unitOfWork.CategoryRepository
            .GetAll()
            .Select(
                category => new SelectListItem()
                {
                    Text = category.Name,
                    Value = category.Id.ToString()
                });

        ProductUpsertFormViewModel viewModel = new ProductUpsertFormViewModel()
        {
            Product = new Product(),
            CategorySelectOptions = categorySelectOptions
        };
        
        if (id is null or  0)
        {
            return View(viewModel);
        }

        Product? product = this._unitOfWork.ProductRepository.GetFirstOrDefault(category => category.Id == id);

        if (product is not null)
        {
            viewModel.Product = product;
        }

        return View(viewModel);
    }
    
    [HttpPost]
    public IActionResult Upsert(ProductUpsertFormViewModel viewModel, IFormFile? file)
    {
        if (ModelState.IsValid)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;

            if (file is not null)
            {
                string fileName = $@"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}" ;
                string productFolderPath = Path.Combine(wwwRootPath, $@"images{Path.DirectorySeparatorChar}product");

                if (!string.IsNullOrEmpty(viewModel.Product.ImageUrl))
                {
                    string oldProductImagePath = Path.Combine(wwwRootPath, viewModel.Product.ImageUrl.TrimStart('\\'));

                    if (System.IO.File.Exists(oldProductImagePath))
                    {
                        System.IO.File.Delete(oldProductImagePath);
                    }
                }
                
                using (var fileStream = new FileStream(Path.Combine(productFolderPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                viewModel.Product.ImageUrl = $@"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}images{Path.DirectorySeparatorChar}product{Path.DirectorySeparatorChar}{fileName}";
            }
            if (viewModel.Product.Id == 0)
            {
                this._unitOfWork.ProductRepository.Add(viewModel.Product);
                TempData["success"] = "Succesfully created";
            }
            else
            {
                this._unitOfWork.ProductRepository.Update(viewModel.Product);
                TempData["success"] = "Succesfully updated";
            }
            
            this._unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        return View(viewModel);
    }

    #region API Calls

    public IActionResult GetAllProducts()
    {
        List<Product> products = _unitOfWork.ProductRepository.GetAll(includeProperties: "Category").ToList();
        return Json(new { data = products });
    }

    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        Product? productToBeDeleted = _unitOfWork.ProductRepository.GetFirstOrDefault(p => p.Id == id);

        if (productToBeDeleted is null)
        {
            return Json(new { success = false, message = "Error while deleting. No product to be deleted." });
        }
        
        string oldProductImagePath = Path.Combine(_webHostEnvironment.WebRootPath, 
                                                  productToBeDeleted.ImageUrl.TrimStart('\\'));

        if (System.IO.File.Exists(oldProductImagePath))
        {
            System.IO.File.Delete(oldProductImagePath);
        }
        
        _unitOfWork.ProductRepository.Remove(productToBeDeleted);
        _unitOfWork.Save();
        
        return Json(new { success = true, message = "Delete sucessful" });
    }

    #endregion
}