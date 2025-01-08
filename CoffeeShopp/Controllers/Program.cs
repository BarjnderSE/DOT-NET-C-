using CoffeeShopp.Data;
using CoffeeShopp.Models.Interfaces;
using CoffeeShopp.Models.Services;
using Microsoft.EntityFrameworkCore;


        var builder = WebApplication.CreateBuilder(args);

        // Register services
        builder.Services.AddRazorPages();
        builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register DbContext with dependency injection
builder.Services.AddDbContext<CoffeeShopDbContext>(options =>
    options.UseSqlServer(connectionString));


// Register the IProductRepository implementation
builder.Services.AddScoped<IProductRepository, ProductRepository>();

        var app = builder.Build(); // Build the app after registering services

        // Configure the HTTP request pipeline
        if (app.Environment.IsDevelopment())
       
        {
            app.UseExceptionHandler("/Home/Error"); // Redirect to error page in production
            app.UseHsts(); // Add HTTP Strict Transport Security (HSTS) in production
        }

        app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS
        app.UseStaticFiles(); // Enable serving static files

        app.UseRouting(); // Enable routing

        app.UseAuthentication(); // Enable authentication
        app.UseAuthorization(); // Enable authorization

        app.MapRazorPages(); // Map Razor pages

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"); // Map default controller route

        app.Run(); // Run the application
 