using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace Calcusino.src.Frontend.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public IActionResult OnPost()
        {
            if (Username == "test" && Password == "password")
            {
                // Erfolgreiches Login
                return RedirectToPage("/Index");
            }

            // Fehlgeschlagenes Login
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }
    }
}