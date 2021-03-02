using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Model.Models;
using Service;
using SwipeRight.Interfaces;

namespace SwipeRight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly Logic _logic;
        private readonly ITokenService _token;

        public AccountController(Logic logic, ITokenService token)
        {
            _logic = logic;
            _token = token;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if(await _logic.UserExists(registerDto.Username))
            {
                return BadRequest("Username is taken");
            }

            AppUser newUser = await _logic.RegisterUser(registerDto);

            return new UserDto
            {
                Username = newUser.UserName,
                Token = _token.CreateToken(newUser)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            AppUser loginUser = await _logic.LoginUser(loginDto);

            if (loginUser == null)
            {
                return Unauthorized("Invalid username");
            }

            AppUser user = _logic.CheckPassword(loginUser, loginDto);

            if (user == null)
            {
                return Unauthorized("Invalid password");
            }

            return new UserDto
            {
                Username = user.UserName,
                Token = _token.CreateToken(user)
            };
        }


    }
}
