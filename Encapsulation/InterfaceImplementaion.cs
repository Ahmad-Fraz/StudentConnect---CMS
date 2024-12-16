
using DataBase;
using Microsoft.AspNetCore.Identity;
using Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices;
using Models.Dashboard;

namespace Encapsulation
{
    public class InterfaceImplementaion : Interface
    {
        private readonly DBase dBase;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public InterfaceImplementaion(DBase dBase, SignInManager<ApplicationUser> _signInManager, UserManager<ApplicationUser> _userManager)
        {
            this.dBase = dBase;
            signInManager = _signInManager;
            userManager = _userManager;
        }

        public async Task<SignInResult> SignInAsync(SignInModel signIn)
        {
            var result = await signInManager.PasswordSignInAsync(signIn.Email, signIn.password, signIn.keepMeSignedIn, false);
            return result;
        }

        public async Task<IdentityResult> signup(SignUpModel signUp)
        {
            
            var user = new ApplicationUser()
            {
                UserName = signUp.Email,
                Email = signUp.Email,
                PhoneNumber = signUp.PhoneNo,
                Degree = signUp.Degree,
                Member_Type = signUp.Joinas,
                FullName = signUp.Name,
                DOB = signUp.DOB,
                Gender = signUp.Gender,
                City_Name = signUp.City_Name,
                Home_Address = signUp.Home_Address,
                Profile_Photo_Path = signUp.Profile_Photo_Path
            };
            
            var result = await userManager.CreateAsync(user, signUp.password);
            return result;
        }

        public async Task signout()
        {
            await signInManager.SignOutAsync();
        }


        public async Task AddPhotoAsync(string filename, string id)
        {

            ApplicationUser? user = await userManager.FindByIdAsync(id);
            user.Profile_Photo_Path = filename;
            await userManager.UpdateAsync(user);

        }

        // Update Basic Info || Home
        public async Task BasicInfoUpdateAsync(string id, SignUpModel signUp)
        {

            ApplicationUser? user = await userManager.FindByIdAsync(id);
            user.FullName = signUp.Name;
            user.Gender = signUp.Gender;
            await userManager.UpdateAsync(user);

        }

        // Update Contact Info || Home
        public async Task ContactInfoUpdateAsync(string id, SignUpModel signUp)
        {

            ApplicationUser? user = await userManager.FindByIdAsync(id);
            user.Email = signUp.Email;
            user.PhoneNumber = signUp.PhoneNo;
            await userManager.UpdateAsync(user);

        }
        // Update Address Info || Home
        public async Task AddressInfoUpdateAsync(string id, SignUpModel signUp)
        {

            ApplicationUser? user = await userManager.FindByIdAsync(id);
            user.Home_Address = signUp.Home_Address;
            user.City_Name = signUp.City_Name;
            await userManager.UpdateAsync(user);

        }

        // Update Basic Info || Home
        public async Task SignInInfoUpdateAsync(string id, SignUpModel signUp)
        {

            ApplicationUser? user = await userManager.FindByIdAsync(id);
            user.Two_step_Verification_Phone = signUp.Two_step_Verification_Phone;
            user.Recovery_Email = signUp.Recovery_Email;
            await userManager.UpdateAsync(user);

        }       

        public async Task<int> Add_News_Event(news_events news_Events)
        {
            _ = dBase.News_Events.AddAsync(news_Events);
            var result = await dBase.SaveChangesAsync();
            return result;
        }

    }
}
