using ChatApp.Entities;
using ChatApp.Models;
using ChatApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService { get; set; }

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model, ipAddress());

            if (response == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            setTokenCookie(response.RefreshToken);

            return Ok(response);
        }

        [Authorize]
        [HttpGet("get")]
        public IActionResult Get()
        {
            return Content(User.Identity.Name);
        }



        //Методы помощники
        private void setTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };

            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }

        private string ipAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                return Request.Headers["X-Forwarded-For"];
            }
            else
            {
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            }
        }


    }
}
