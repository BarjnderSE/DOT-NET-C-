using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Portfolio.Pages.Model
{
    public class ProjectsModel : PageModel
    {
        public List<Project> ProjectList { get; set; }

        public void OnGet()
        {
            ProjectList = new List<Project>
            {
                new Project { Title = "E-commerce App", Description = "Built with .NET Core MVC and SQL Server.", Link = "https://github.com/your-repo/ecommerce" },
                new Project { Title = "Portfolio Website", Description = "Dynamic portfolio built using Razor Pages.", Link = "https://your-portfolio-link" },
                new Project { Title = "Coffee Analysis Dashboard", Description = "Data analysis using Python and Power BI.", Link = "https://github.com/your-repo/coffee-analysis" }
            };
        }

        public class Project
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string Link { get; set; }
        }
    }
}
