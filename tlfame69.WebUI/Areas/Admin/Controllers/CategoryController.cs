using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using tflame69.Models.dbo;
using tlfame69.DataAccess;
using tlfame69.DataAccess.Repository.IRepository;

namespace tlfame69.WebUI.Controllers;

[Area("Admin")]
public class CategoryController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    
    public CategoryController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    public IActionResult Index()
    {
        List<Category> categories = this._unitOfWork.CategoryRepository.GetAll().ToList();
        return View(categories);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View(new Category());
    }

    [HttpPost]
    public IActionResult Create(Category category)
    {
        if (category.Name == category.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The Display Order cannot exactly match the name");
        }
        
        if (ModelState.IsValid)
        {
            this._unitOfWork.CategoryRepository.Add(category);
            this._unitOfWork.Save();
            TempData["success"] = "Succesfully created";
            return RedirectToAction("Index");
        }
        
        return View();
    }

    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (id is null || id == 0)
        {
            return NotFound();
        }

        Category? updateCategory = this._unitOfWork.CategoryRepository.GetFirstOrDefault(category => category.Id == id);

        if (updateCategory is null)
        {
            return NotFound();
        }
        
        return View(updateCategory);
    }

    [HttpPost]
    public IActionResult Edit(Category category)
    {
        if (ModelState.IsValid)
        {
            this._unitOfWork.CategoryRepository.Update(category);
            this._unitOfWork.Save();
            TempData["success"] = "Succesfully updated";
            return RedirectToAction(nameof(Index));
        }
        
        return View();
    }
    
    
    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if (id is null or 0)
        {
            return NotFound();
        }

        Category? deleteCategory = this._unitOfWork.CategoryRepository.GetFirstOrDefault(category => category.Id == id);

        if (deleteCategory is null)
        {
            return NotFound();
        }
        
        return View(deleteCategory);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePost(int? id)
    {
        if (id is null or 0)
        {
            return NotFound();
        }

        Category? deleteCategory = this._unitOfWork.CategoryRepository.GetFirstOrDefault(category => category.Id == id);

        if (deleteCategory is null)
        {
            return NotFound();
        }

        this._unitOfWork.CategoryRepository.Remove(deleteCategory);
        this._unitOfWork.Save();
        TempData["success"] = "Succesfully deleted";
        
        return RedirectToAction(nameof(Index));
    }
}