using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcApp.Models;
using MvcApp.Data;
using System.Linq;

namespace MvcApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
     private readonly ApplicationDbContext _context;


    public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
    {
        _logger = logger;
         _context = context;
    }

    public IActionResult Index()
    {
         var products = _context.Products.ToList();
            return View(products);
    }
[HttpPost]
        public IActionResult AddProduct(string name, decimal price)
        {
            _context.Products.Add(new Product { Name = name, Price = price });
            _context.SaveChanges();
            return RedirectToAction("Index");
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
