using System.Diagnostics;
using BlueBud.Data;
using Microsoft.AspNetCore.Mvc;
using BlueBud.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace BlueBud.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext dbContext;
    
    
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    

    [Authorize]
    public IActionResult Index()
    {
        
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer("Server=(local);Database=BlueBuddy;User ID=sa;Password=Aa123456;MultipleActiveResultSets=true;Trust Server Certificate = true")
            .Options;


        
        using (var dbContext = new ApplicationDbContext(options))
        {
            List<ChargerLocations> top5Charger =
                dbContext.ChargerLocation.Where(p => p.OccupationStatus == 0 ).Take(4).ToList();
            return View(top5Charger);
        }
        
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    [Authorize]
    public IActionResult Account()
    {
        return View();
    }

   

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    

    

}
