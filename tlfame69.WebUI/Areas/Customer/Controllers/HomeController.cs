using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tflame69.Models.dbo;
using tlfame69.DataAccess.Repository.IRepository;
using tlfame69.WebUI.Models;

namespace tlfame69.WebUI.Controllers;

[Area("Customer")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        this._unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Product> products = _unitOfWork.ProductRepository.GetAll(includeProperties: "Category");
        return View(products);
    }

    public IActionResult Details(int productId)
    {
        Product? product = _unitOfWork.ProductRepository.GetFirstOrDefault(p => p.Id == productId,
                                                            includeProperties: "Category");

        return View(product);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}