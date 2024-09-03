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
                // Erfolgreiches Login - Hier könntest du entweder eine Nachricht anzeigen oder zu einer vorhandenen Seite weiterleiten
                return Page(); // Bleibt auf der Login-Seite
            }

            // Fehlgeschlagenes Login
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }
    }
}