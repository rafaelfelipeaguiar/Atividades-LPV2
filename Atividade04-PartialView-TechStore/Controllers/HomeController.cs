using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AulaPartialView.Models;

namespace AulaPartialView.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var products = new List<Product>
        {
            new() { Id = 1, Name = "Notebook", Description = "Dell XPS 13", Price = 7500.00m },
            new() { Id = 2, Name = "Mouse", Description = "Logitech MX Master 3", Price = 450.00m },
            new() { Id = 3, Name = "Monitor", Description = "Dell 27\" UltraSharp", Price = 2200.00m },
            new() { Id = 4, Name = "Teclado", Description = "Keychron K6", Price = 800.00m }
        };
        
        return View(products);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}