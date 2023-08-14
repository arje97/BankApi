using Core.Application.Interfaces;
using Core.Application.RequestsHelper.DTOs;
using Core.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.BankApi.Services;

namespace Presentation.BankApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService userService;
       

        public AuthController(UserService userService)
        {
            this.userService = userService; 
        }
        [HttpPost("logIn")]
        public async Task<IActionResult> LogIn([FromForm] LoginDTO loginDTO)
        {
            var user = await userService.unit.UserRepository.ValidateUser(loginDTO.UserName, loginDTO.Password);

            var token = JwtValidationExtensions.GenerateJwtToken(
                user.Id.ToString(),
                 user.UserName,
                user.FirstName,
                user.LastName
                );

            Response.Headers.Add("AccessToken", token);
            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            await userService.RegisterUser(userDTO);
            return Ok();
        }

    }
}
