using DataBase;
using Microsoft.AspNetCore.Identity;
using Models;
using Models.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public interface Interface
    {
        public Task<IdentityResult> signup(SignUpModel signUp);
        public Task<SignInResult> SignInAsync(SignInModel signIn);
        public Task signout();
        public Task AddPhotoAsync(string filename, string id);
        public Task SignInInfoUpdateAsync(string id, SignUpModel signUp);
        public Task AddressInfoUpdateAsync(string id, SignUpModel signUp);
        public Task ContactInfoUpdateAsync(string id, SignUpModel signUp);
        public Task BasicInfoUpdateAsync(string id, SignUpModel signUp);
        public Task<int> Add_News_Event(news_events news_Events);

    }
}
