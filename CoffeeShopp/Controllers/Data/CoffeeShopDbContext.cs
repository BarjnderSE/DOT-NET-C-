using CoffeeShopp.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopp.Data
{
    public class CoffeeShopDbContext:DbContext
    {
        public CoffeeShopDbContext(DbContextOptions<CoffeeShopDbContext> options):base(options)
        {
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Espresso",
                    Detail = "A rich and intense shot of coffee that delivers bold flavor and instant energy.",
                    Price = 20,
                    IsTrendingProduct = true,
                    ImageUrl = "https://plus.unsplash.com/premium_photo-1669687924558-386bff1a0469?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8ZXNwcmVzc298ZW58MHx8MHx8fDA%3D"
                },
                new Product
                {
                    Id = 2,
                    Name = "Vanilla Latte",
                    Detail = "Smooth espresso with steamed milk and a hint of vanilla for a creamy delight.",
                    Price = 27,
                    IsTrendingProduct = false,
                    ImageUrl = "https://images.unsplash.com/photo-1489866492941-15d60bdaa7e0?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8ZXNwcmVzc298ZW58MHx8MHx8fDA%3D"
                },
                new Product
                {
                    Id = 3,
                    Name = "Caramel Macchiato",
                    Detail = "A layered espresso drink with sweet caramel drizzle and a creamy foam finish.",
                    Price = 30,
                    IsTrendingProduct = true,
                    ImageUrl = "https://images.unsplash.com/photo-1530878092547-647df23b3056?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8ZXNwcmVzc298ZW58MHx8MHx8fDA%3D"
                },
                new Product
                {
                    Id = 4,
                    Name = "Hazelnut Cappuccino",
                    Detail = "Classic cappuccino with a sweet, nutty hazelnut twist.",
                    Price = 22,
                    IsTrendingProduct = false,
                    ImageUrl = "https://images.unsplash.com/photo-1603145733146-ae562a55031e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTJ8fGVzcHJlc3NvfGVufDB8fDB8fHww"
                },
                new Product
                {
                    Id = 5,
                    Name = "Matcha Latte",
                    Detail = "Earthy matcha green tea blended with creamy steamed milk for a unique flavor.",
                    Price = 28,
                    IsTrendingProduct = true,
                    ImageUrl = "https://images.unsplash.com/photo-1576618148400-71c0c252f3c9"
                },
                new Product
                {
                    Id = 6,
                    Name = "Honey Almond Flat White",
                    Detail = "Rich espresso paired with almond milk and a touch of honey for a naturally sweetened drink.",
                    Price = 25,
                    IsTrendingProduct = false,
                    ImageUrl = "https://plus.unsplash.com/premium_photo-1723741247155-38ea929d6998?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTd8fGVzcHJlc3NvfGVufDB8fDB8fHww"
                },
                new Product
                {
                    Id = 7,
                    Name = "Chai Tea Latte",
                    Detail = "A spicy-sweet blend of black tea and spices with steamed milk for a comforting beverage.",
                    Price = 18,
                    IsTrendingProduct = true,
                    ImageUrl = "https://images.unsplash.com/photo-1523063308874-cecc260a3171?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTh8fGVzcHJlc3NvfGVufDB8fDB8fHww"
                },
                new Product
                {
                    Id = 8,
                    Name = "Iced Coffee",
                    Detail = "Freshly brewed coffee chilled and served over ice, perfect for hot days.",
                    Price = 15,
                    IsTrendingProduct = false,
                    ImageUrl = "https://images.unsplash.com/photo-1508088405209-fbd63b6a4f50?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTZ8fGVzcHJlc3NvfGVufDB8fDB8fHww"
                }
            );
        }
    }
}