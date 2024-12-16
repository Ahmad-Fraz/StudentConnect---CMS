using DataBase;
using Encapsulation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using System.Security.Claims;

namespace StudentConnect.Areas.Profiles
{
    public class ProfileModel : PageModel
    {
        private readonly Interface @interface;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly HttpContextAccessor httpContext;

        public ProfileModel(Interface _interface,IWebHostEnvironment webHostEnvironment,UserManager<ApplicationUser> userManager, HttpContextAccessor httpContext)
        {
            @interface = _interface;
            this.webHostEnvironment = webHostEnvironment;
            this.userManager = userManager;
            this.httpContext = httpContext;
        }


        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost(SignUpModel signUp) 
        {

            var userId = GetId();

            if(signUp.Profile_pic != null || signUp.Profile_Photo_Path != null)
            {
                var photoName = AddFile(signUp);
                await @interface.AddPhotoAsync(photoName,userId);
            }
            if(signUp.Name != null &&  signUp.Gender != null)
            {
                await @interface.BasicInfoUpdateAsync(userId, signUp);
            }
            else if(signUp.Email !=null && signUp.PhoneNo !=null)
            {
                await @interface.ContactInfoUpdateAsync(userId, signUp);
            }
            else if(signUp.Home_Address != null && signUp.City_Name != null){
                await @interface.AddressInfoUpdateAsync(userId, signUp);
            }
            else if(signUp.Two_step_Verification_Phone != null && signUp.Recovery_Email != null)
            {
                await @interface.SignInInfoUpdateAsync(userId, signUp);
            }
            else
            {
                ModelState.AddModelError("", "No Update function can be runned from Profile");
            }

            return Page();

        }

        private string AddFile(SignUpModel signUpModel)
        {
            string filename = null;
            if (signUpModel.Profile_pic!= null)
            {

                string folder = "Profile_Pics/";
                filename = (Guid.NewGuid().ToString()) + " " + signUpModel.Profile_pic.FileName;
                string path = folder + filename;

                string serverPath = Path.Combine(webHostEnvironment.WebRootPath, path);

                signUpModel.Profile_pic.CopyTo(new FileStream(serverPath, FileMode.Create));
            }
            return filename;
        }

        public string GetId()
        {
            return httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

    }
}