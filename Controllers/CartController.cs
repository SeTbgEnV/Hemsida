using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Kundkorg.Models;

namespace Kundkorg.Controllers;

public class CartController : Controller
{
    private readonly ILogger<CartController> _logger;

    public CartController(ILogger<CartController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
}