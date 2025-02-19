using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        
        return View("EnterMovies", new Movie());
    }
    
    [HttpPost]
    public IActionResult EnterMovies(Movie response)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(response); // add record to database
            _context.SaveChanges();
            
            return View("Confirmation", response); 
        }
        else
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            
            return View(response);
        }
        
    }
    
    public IActionResult ListOfMovies()
    {
        // linq
        var movies = _context.Movies
            .Include(x => x.Category);

        return View(movies); 
    }
    
    [HttpGet]
    public IActionResult Edit(int movieid)
    {
        var recordToEdit = _context.Movies
            .Single(x => x.MovieId == movieid);
        
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();  
        
        return View("EnterMovies", recordToEdit);
    }

    [HttpPost]
    public IActionResult Edit(Movie updatedInfo)
    {
        _context.Movies.Update(updatedInfo);
        _context.SaveChanges();
        
        return RedirectToAction("ListOfMovies");
    }

    [HttpGet]
    public IActionResult Delete(int movieid)
    {
        var recordToDelete = _context.Movies
            .Single(x => x.MovieId == movieid);

        return View(recordToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Movie movie)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();
        
        return RedirectToAction("ListOfMovies");
    }
}