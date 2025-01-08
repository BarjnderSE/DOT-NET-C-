// Controllers/UserController.cs
using Microsoft.AspNetCore.Mvc;
using EBookStore.Models;

public class UserController : Controller
{
    private readonly StoreDbContext _db;

    public UserController(StoreDbContext db)
    {
        _db = db; // DI injects the DbContext here
    }

    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var user = _db.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
        if (user != null)
        {
            HttpContext.Session.SetInt32("UserId", user.Id);
            return RedirectToAction("Index", "Book");
        }

        ViewBag.Message = "Invalid login.";
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }

    public IActionResult Register() => View();

    [HttpPost]
    public IActionResult Register(User user)
    {
        _db.Users.Add(user);
        _db.SaveChanges();
        return RedirectToAction("Login");
    }
}
