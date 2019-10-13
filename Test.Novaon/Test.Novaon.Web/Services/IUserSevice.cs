using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Novaon.Web.Interfaces;
using Test.Novaon.Web.Models;

namespace Test.Novaon.Web.Services
{
    public interface IUserSevice
    {
        bool VerifyEmail(string Email);
        Task<IResponse> SignUp(UserModel model);
        Task<IResponse> SignIn(UserSignInModel model);
    }
}
