using Encapsulation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
namespace StudentConnect.Pages.Areas.Account
{
    public class SignUpModel : PageModel
    {
        private readonly Interface _interface;
        private readonly IWebHostEnvironment webHostEnvironment;

        [BindProperty]
        public Models.SignUpModel signUp { get; set; }

        public string[] types { get; set; } = new string[] { "Student", "Faculty Member" };


        [BindProperty]
        public string type { get; set; } = "Student";


        public SignUpModel(Interface _interface,IWebHostEnvironment webHostEnvironment)
        {
            this._interface = _interface;
            this.webHostEnvironment = webHostEnvironment;
        }


        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {

            signUp.Joinas = type;

            bool Modelvalid = false;

            if (signUp.Joinas == null || signUp.Email == null || signUp.Degree == null || signUp.confirm_password == null || signUp.password == null || signUp.PhoneNo == null || signUp.Name == null || signUp.DOB == null)
            {
                Modelvalid = false;
            }

            else
            {
                Modelvalid= true;
            }

            if (Modelvalid)
            {
                var photoname = AddFile(signUp);

                signUp.Profile_Photo_Path = photoname;

                var result = _interface.signup(signUp);

                if (result.Result.Succeeded)
                {
                    ModelState.Clear();
                    TempData["UserCreated"] = "successfully";
                    return RedirectToPage("SignIn");
                }
                else
                {
                    foreach (var errors in result.Result.Errors)
                    {
                        ModelState.AddModelError("", "Error : " + errors.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "SignUp request was not successfull");
            }
            return Page();
        }

        private string AddFile(Models.SignUpModel signUpModel)
        {
            string filename = null;
            if (signUpModel.Profile_pic != null)
            {

                string folder = "Profile_Pics/";
                filename = (Guid.NewGuid().ToString()) + " " + signUpModel.Profile_pic.FileName;
                string path = folder + filename;

                string serverPath = Path.Combine(webHostEnvironment.WebRootPath, path);

                signUpModel.Profile_pic.CopyTo(new FileStream(serverPath, FileMode.Create));
            }
            return filename;
        }

    }
}