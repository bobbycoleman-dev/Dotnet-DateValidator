using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DateValidator.Models;

namespace DateValidator.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public static Form NewDate = new();

    [HttpGet("")]
    public IActionResult Index()
    {
        
        return View();
    }

    [HttpPost("process")]
    public IActionResult Process(Form newForm)
    {
        NewDate = newForm;
        
        
        if(ModelState.IsValid){
            return RedirectToAction("Result");
        }
        return View("Index");
    }

    [HttpGet("results")]
    public IActionResult Result()
    {
        return View(NewDate);
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
