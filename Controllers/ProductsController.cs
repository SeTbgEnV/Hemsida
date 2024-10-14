using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Kundkorg.Models;
using Kundkorg.models;

namespace Kundkorg.web.Controllers;

public class ProductsController : Controller
{
    // GET: ProductsController
    private List<Product> _products = [];
    private readonly IWebHostEnvironment _environment;

    // Depency Injection...
    public ProductsController(IWebHostEnvironment environment)
    {
        _environment = environment;
        /* ger oss den fysiska placeringen av wwwroot katalogen */
        var root = _environment.WebRootPath;
        var path = string.Concat(root, "/Data/product.json");

        GetProduct(path);
    }
    public ActionResult Index()
    {
        return View(_products);
    }
    public ActionResult Details(int ProductId)
    {
        var found = _products.SingleOrDefault(o => o.ProductId == ProductId);
        return View(found);
    }
    private void GetProduct(string path)
    {
        _products = Storage<Product>.ReadJson(path);
    }
}