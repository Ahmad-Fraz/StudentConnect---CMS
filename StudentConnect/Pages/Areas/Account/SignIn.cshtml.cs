using Encapsulation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudentConnect.Areas.Account
{
    public class SignInModel : PageModel
    {
        private readonly Interface _interface;

        [BindProperty]
        public Models.SignInModel? signIns { get; set; }

        public SignInModel()
        {

        }

        [ActivatorUtilitiesConstructor]
        public SignInModel(Interface _interface)
        {
            this._interface = _interface;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            var modelValid = false;
            if (signIns.Email != null && signIns.password != null) { modelValid = true; }

            if (modelValid)
            {
                var result = _interface.SignInAsync(signIns);
                if (result.Result.Succeeded)
                {
                    string signin_notification = "true";
                    return RedirectToPage("/Dashboard", new { Shared = "" , signin_notification});
                }
                else
                {
                    ModelState.AddModelError("", "SignIn not succeeded .\n Wrong Credentials");
                }
            }
            return Page();
        }
    }
}