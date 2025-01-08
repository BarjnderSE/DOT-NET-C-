using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Portfolio.Pages.Model
{
   
    public class AboutModel : PageModel
    {
        public string Bio { get; set; }
        
        public void OnGet()
        {
            Bio = "Hello! I am a software engineer specializing in .NET and Razor Pages development. I have experience in building web applications, APIs, and dynamic dashboards.";
        }
    }
}