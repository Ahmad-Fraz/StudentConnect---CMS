using Encapsulation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentConnect.Pages.Areas.Account;   
namespace StudentConnect.Pages.Areas.Profiles
{
    public class SignOutModel : PageModel
    {
        public SignOutModel(Interface _interface)
        {
            Interface = _interface;
        }

        public Interface Interface { get; }

        public async Task<IActionResult> OnGet()
        {
            await Interface.signout();
            string signout_notification = "true";
            return RedirectToPage("/Dashboard", new { signout_notification });

        }

    }
}
