namespace CoffeeShopp.Models.Interfaces
{
    public interface IShoppingCartRepository
    {
        void AddToCart(Product product);
        void RemoveFromCart(Product product);

        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        
        decimal GetShoppingCartTotal(string userId);

        public List<ShoppingCartItem>? ShoppingCartItems { get; set;}
    }
}
