using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Portfolio.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public ContactForm Form { get; set; }

        public string SuccessMessage { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                SuccessMessage = "Thank you for reaching out! I will get back to you soon.";
                // Here you can add code to save data or send an email.
            }
        }

        public class ContactForm
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Message { get; set; }
        }
    }
}
