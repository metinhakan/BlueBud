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
    public bool isAuthenticated;
    private readonly ApplicationDbContext dbContext;
    
    
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    

    [Authorize]
    public IActionResult Index()
    {
        
        if (User.Identity.IsAuthenticated)
        {
             isAuthenticated = true;
        }

        else
        {
            isAuthenticated = false;
        }

        ViewBag.IsAut = isAuthenticated;
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer("Server=(local);Database=FinalProjectDB1;User ID=sa;Password=Aa123456;MultipleActiveResultSets=true;Trust Server Certificate = true")
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
    

    public IActionResult Account()
    {
        return View();
    }

   

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    [Authorize]
    public IActionResult Reservations()
    {
        if (User.Identity.IsAuthenticated)
        {
            isAuthenticated = true;
        }

        else
        {
            isAuthenticated = false;
        }

        ViewBag.IsAut = isAuthenticated;
        
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer("Server=(local);Database=FinalProjectDB1;User ID=sa;Password=Aa123456;MultipleActiveResultSets=true;Trust Server Certificate = true")
            .Options;


        
        using (var dbContext = new ApplicationDbContext(options))
        {
            List<ChargerLocations> reservedChargers =
                dbContext.ChargerLocation.Where(p => p.OccupationStatus == 1 ).Take(4).ToList();
            return View(reservedChargers);
        }
        
    }
    

}
