using Microsoft.AspNetCore.Mvc;
using EBookStore.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;

public class BookController : Controller
{
    private readonly StoreDbContext _db;

    public BookController(StoreDbContext db)
    {
        _db = db;
    }

    // Index action to list all books
    public IActionResult Index()
    {
        var books = _db.Books.ToList();
        return View(books);
    }

    // Create GET action to display the form
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // Create POST action to handle form submission and image upload
    [HttpPost]
    public IActionResult Create(Book book, IFormFile Image)
    {
        // Check if the image is uploaded and valid
        if (Image != null && Image.Length > 0)
        {
            if (Image.Length > 5 * 1024 * 1024)  // Limit to 5 MB
            {
                ModelState.AddModelError("Image", "The image file is too large. Max size is 5MB.");
                return View();
            }

            // Define file path to save the image
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

            // Save the image to the file system
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                Image.CopyTo(stream);
            }

            // Save the file path in the database
            book.ImagePath = "/images/" + fileName;
        }
        else
        {
            // If image is not uploaded, show error
            ModelState.AddModelError("Image", "Please upload an image.");
            return View();
        }

        // Check if the user is logged in and has a valid session
        var userId = HttpContext.Session.GetInt32("UserId");
        if (userId.HasValue)
        {
            book.SellerId = userId.Value;
        }
        else
        {
            // Redirect to login page if user is not authenticated
            return RedirectToAction("Login", "Account");
        }

        // Check if the model is valid before saving to the database
        if (ModelState.IsValid)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // If model is invalid, return to the form with errors
        return View();
    }

    // Details action to display the details of a book
    public IActionResult Details(int id)
    {
        var book = _db.Books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            // Return a "Not Found" result if the book does not exist
            return NotFound();
        }
        return View(book);
    }
}
