using ShoppingListServer.Models;
using ShoppingListServer.Models.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ShoppingListServer.Services.Interfaces;
using ShoppingListServer.Models.Authentication.Exceptions;

namespace ChatAppServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginCredentials loginCredentials)
        {
            try
            {
                var token = await _authenticationService.Login(loginCredentials);

                return Ok(token);
            }
            catch (WrongEmailOrPasswordException error)
            {
                return Unauthorized(error.Message);
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCredentials registerCredentials)
        {
            try
            {
                var token = await _authenticationService.Register(registerCredentials);

                return Ok(token);
            }
            catch (Exception error) when (error is UserAlreadyExistsException)
            {
                return Conflict(error.Message);
            }
            catch (Exception error) when (error is UnexpectedException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }
    }
}
