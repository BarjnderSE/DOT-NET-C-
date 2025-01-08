using CoffeeShopp.Models.Interfaces;
using CoffeeShopp.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopp.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository productRepository;
        public HomeController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult Index()
        {
            return View(productRepository.GetTrendingProducts());
        }
    }
}
