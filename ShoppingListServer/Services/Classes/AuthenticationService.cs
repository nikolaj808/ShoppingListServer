using Microsoft.AspNetCore.Identity;
using ShoppingListServer.Models.Authentication;
using ShoppingListServer.Models.Authentication.Exceptions;
using ShoppingListServer.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace ShoppingListServer.Services.Classes
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtService _jwtService;

        public AuthenticationService(UserManager<User> userManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<string> Login(LoginCredentials loginCredentials)
        {
            var user = await _userManager.FindByEmailAsync(loginCredentials.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, loginCredentials.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var token = _jwtService.GenerateJwtToken(user, userRoles);

                return token;
            }

            throw new WrongEmailOrPasswordException("Wrong email or password");
        }

        public async Task<string> Register(RegisterCredentials registerCredentials)
        {
            var userExists = await _userManager.FindByEmailAsync(registerCredentials.Email);

            if (userExists != null)
            {
                throw new UserAlreadyExistsException("User already exists");
            }

            User user = new User()
            {
                UserName = registerCredentials.Username,
                Email = registerCredentials.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var result = await _userManager.CreateAsync(user, registerCredentials.Password);

            if (!result.Succeeded)
            {
                throw new UnexpectedException("Unexpected user registration fail");
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            var token = _jwtService.GenerateJwtToken(user, userRoles);

            return token;
        }
    }
}
