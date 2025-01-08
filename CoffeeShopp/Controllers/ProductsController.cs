using CoffeeShopp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopp.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult Shop()
        {
            return View(productRepository.GetAllProducts());
        }
        // need detail metjhod with oid
        public IActionResult Details(int id)
        {
            var product = (productRepository.GetProductDetail(id));
            {
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
        }
    }
}
