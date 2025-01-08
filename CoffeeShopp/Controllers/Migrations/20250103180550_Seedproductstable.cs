using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeeShopp.Migrations
{
    /// <inheritdoc />
    public partial class Seedproductstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Detail", "ImageUrl", "IsTrendingProduct", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "A rich and intense shot of coffee that delivers bold flavor and instant energy.", "https://plus.unsplash.com/premium_photo-1669687924558-386bff1a0469?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8ZXNwcmVzc298ZW58MHx8MHx8fDA%3D", true, "Espresso", 20m },
                    { 2, "Smooth espresso with steamed milk and a hint of vanilla for a creamy delight.", "https://images.unsplash.com/photo-1489866492941-15d60bdaa7e0?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8ZXNwcmVzc298ZW58MHx8MHx8fDA%3D", false, "Vanilla Latte", 27m },
                    { 3, "A layered espresso drink with sweet caramel drizzle and a creamy foam finish.", "https://images.unsplash.com/photo-1530878092547-647df23b3056?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8ZXNwcmVzc298ZW58MHx8MHx8fDA%3D", true, "Caramel Macchiato", 30m },
                    { 4, "Classic cappuccino with a sweet, nutty hazelnut twist.", "https://images.unsplash.com/photo-1603145733146-ae562a55031e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTJ8fGVzcHJlc3NvfGVufDB8fDB8fHww", false, "Hazelnut Cappuccino", 22m },
                    { 5, "Earthy matcha green tea blended with creamy steamed milk for a unique flavor.", "https://images.unsplash.com/photo-1576618148400-71c0c252f3c9", true, "Matcha Latte", 28m },
                    { 6, "Rich espresso paired with almond milk and a touch of honey for a naturally sweetened drink.", "https://plus.unsplash.com/premium_photo-1723741247155-38ea929d6998?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTd8fGVzcHJlc3NvfGVufDB8fDB8fHww", false, "Honey Almond Flat White", 25m },
                    { 7, "A spicy-sweet blend of black tea and spices with steamed milk for a comforting beverage.", "https://images.unsplash.com/photo-1523063308874-cecc260a3171?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTh8fGVzcHJlc3NvfGVufDB8fDB8fHww", true, "Chai Tea Latte", 18m },
                    { 8, "Freshly brewed coffee chilled and served over ice, perfect for hot days.", "https://images.unsplash.com/photo-1508088405209-fbd63b6a4f50?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTZ8fGVzcHJlc3NvfGVufDB8fDB8fHww", false, "Iced Coffee", 15m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
