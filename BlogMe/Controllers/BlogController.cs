using BlogMe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;

namespace BlogMe.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogContext _context;

        public BlogController(BlogContext context)
        {
            _context = context;
        }

        // Index - Display All Posts
        public IActionResult Index()
        {
            var posts = _context.BlogPosts.OrderByDescending(p => p.CreatedAt).ToList();
            return View(posts);
        }
        // AllBlogs - Display All Posts
        public IActionResult AllBlogs()
        {
            var blogs = _context.BlogPosts.OrderByDescending(b => b.CreatedAt).ToList();
            return View(blogs); // Pass the list of blogs to the view
        }


        // Create - GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Create - POST
        [HttpPost]
        public IActionResult Create(BlogPost post)
        {
            if (ModelState.IsValid)
            {
                _context.BlogPosts.Add(post);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // Details - Display Single Post
        public IActionResult Details(int id)
        {
            var post = _context.BlogPosts.FirstOrDefault(b => b.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // Edit - GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var blogPost = _context.BlogPosts.FirstOrDefault(b => b.Id == id);
            if (blogPost == null)
            {
                return NotFound();
            }
            return View(blogPost);
        }

        // Edit - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,Content,ImageUrl")] BlogPost blogPost, IFormFile UploadedImage)
        {
            if (id != blogPost.Id)
            {
                return NotFound();  // Ensure the Id matches
            }

            if (ModelState.IsValid) // Check if the model is valid
            {
                try
                {
                    // Handle image upload if a new image is provided
                    if (UploadedImage != null && UploadedImage.Length > 0)
                    {
                        // Generate file path
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", UploadedImage.FileName);

                        // Save the new image
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            UploadedImage.CopyTo(stream);
                        }

                        // Update the ImageUrl property with the new file path
                        blogPost.ImageUrl = "/images/" + UploadedImage.FileName;
                    }

                    _context.Update(blogPost); // Update the blogPost in the database
                    _context.SaveChanges(); // Save changes to the database
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.BlogPosts.Any(e => e.Id == blogPost.Id))
                    {
                        return NotFound(); // Handle concurrency exception
                    }
                    else
                    {
                        throw; // Re-throw the exception if there's an issue
                    }
                }

                // Redirect to the details page after saving changes
                return RedirectToAction("Details", new { id = blogPost.Id });
            }
            return View(blogPost); // If model is invalid, return the current view with errors
        }

        // Delete - GET
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var post = _context.BlogPosts.FirstOrDefault(b => b.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // Delete - POST
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var post = _context.BlogPosts.FirstOrDefault(b => b.Id == id);
            if (post != null)
            {
                _context.BlogPosts.Remove(post);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
