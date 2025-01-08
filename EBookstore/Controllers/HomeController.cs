using Microsoft.AspNetCore.Mvc;
using EBookStore.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class HomeController : Controller
{
    private readonly StoreDbContext _db;

    public HomeController(StoreDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var books = _db.Books.ToList(); // Fetch books from the database
        return View(books);
    }
    // Static action to show the gallery with images only

        public IActionResult Gallery()
        {
            return View(); // Return the static gallery view
        }
    }


