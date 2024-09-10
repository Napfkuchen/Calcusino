using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Mozilla;

namespace Calcusino.src.Frontend.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public IActionResult OnPost()
        {
            if (Username == "admin" && Password == "password")
            {
                return RedirectToPage("/Index"); // Successfull Login
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page(); // Error on Login
        }

        public IActionResult OnPostRegister()
        {
            return RedirectToPage("/Register"); // Forwarding to Registration page
        }
    }
}