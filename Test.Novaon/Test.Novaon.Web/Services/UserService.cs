using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Novaon.Web.Entities;
using Test.Novaon.Web.Interfaces;
using Test.Novaon.Web.Models;

namespace Test.Novaon.Web.Services
{
    public class UserService : IUserSevice
    {
        private readonly IRepository<User, string> _userRepository;
        private readonly IAppLogger<IUserSevice> _logger;
        public UserService(
            IRepository<User, string> userRepository,
            IAppLogger<IUserSevice> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
        public async Task<IResponse> SignUp(UserModel model)
        {
            IResponse response = null;
            try
            {
                if (model == null)
                {
                    response.HasError = true;
                    response.Result = null;
                    response.Errors.Add(new IdentityError { Code = "BussinessError000", Description = "The model not found." });
                } else
                {
                    // Check emailExist
                    var emailExist = _userRepository.Table.Any(u => u.Email == model.Email);
                    if (emailExist)
                    {
                        response.HasError = true;
                        response.Result = null;
                        response.Errors.Add(new IdentityError { Code = "BussinessError001", Description = $"The Email {model.Email} is already in use." });
                    } else
                    {
                        // insert
                        User user = new User();
                        user.Email = model.Email;
                        user.Id = Guid.NewGuid().ToString("N");
                        user.PasswordHash = Helpers.Encryptor.MD5Hash(model.Password);
                        var userSaved = await _userRepository.AddAsync(user);
                        response.Result.data = true;
                        response.HasError = false;
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Error when sign In", ex);
            }
            return await Task.FromResult(response);
        }

        public async Task<IResponse> SignIn(UserSignInModel model)
        {
            IResponse response = null;
            try
            {

            }
            catch (Exception ex)
            {
                _logger.LogWarning("Error when sign In", ex);
            }
            return await Task.FromResult(response);
        }

        public bool VerifyEmail(string Email)
        {
            return _userRepository.Table.Any(u => u.Email == Email);
        }
    }
}
