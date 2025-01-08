using CoffeeShopp.Data;
using CoffeeShopp.Models.Interfaces;

namespace CoffeeShopp.Models.Services
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private CoffeeShopDbContext dbcontext;

        public ShoppingCartRepository(CoffeeShopDbContext dbContext)
        {
            dbcontext = dbContext;
        }
        public List<ShoppingCartItem>? ShoppingCartItems { get; set; }

        public string ShoppingCartId { get; set; }
        public static ShoppingCartRepository GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            CoffeeShopDbContext context = services.GetService<CoffeeShopDbContext>() ?? throw new Exception("Error initializing coffeeshopdbcontext");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCartRepository(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Product product)
        {
            var shoppingCartItem = dbcontext.ShoppingCartItems.SingleOrDefault(s => s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Qty = 1
                };

                dbcontext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Qty++;
            }
        }




        public void ClearCart()
        {
            throw new NotImplementedException();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            throw new NotImplementedException();
        }

        public decimal GetShoppingCartTotal(string userId)
        {
            throw new NotImplementedException();
        }

        public void RemoveFromCart(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
