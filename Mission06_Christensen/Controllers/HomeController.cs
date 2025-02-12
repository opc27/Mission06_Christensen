using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

using Mission06_Christensen.Models;

namespace Mission06_Christensen.Controllers;

public class HomeController : Controller
{
    private EnterMoviesContext _context;
    
    public HomeController(EnterMoviesContext temp) // constructor
    {
        _context = temp;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnow()
    {
        return View();
    }

    [HttpGet]
    public IActionResult EnterMovies()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult EnterMovies(Movie response)
    {
        _context.Movies.Add(response); // add record to database
        _context.SaveChanges();
        
        return View("Confirmation", response); 
    }
}