using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http; 
using Microsoft.AspNetCore.Mvc;
using QuizApi.Context;
using QuizApi.Dto;
using QuizApi.Models;
using System.Net;

namespace QuizApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAuthenticationService _authenticationService;
        public AuthController(AppDbContext context, IAuthenticationService authenticationService)
        {
            _context = context;
            _authenticationService = authenticationService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            if(userDto != null) 
            {
                var IsExists = _context.Users.Where(u=>u.username == userDto.Username || u.email == userDto.Email).Any();
                if(IsExists)
                {
                    return BadRequest("The user already exist");
                }
                if (userDto.Email.Contains(""))
                {
                    userDto.isAdmin = true;
                }
                

                return Ok(new { Message = "Registration successful" });
            }
            return BadRequest("something wrong");
        }
        //[HttpPost("login")]
        //public async Task<IActionResult> Login(UserDto userDto)
        //{
        //    // Validate userDto and handle login
        //    // ...

        //    // If login is successful, generate JWT token
        //    var token = await _authenticationService.GetTokenAsync(userDto.Username);
        //    return Ok(new { Token = token });
        //}
    }
}
