using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Service;

namespace SwipeRight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Logic _logic;
        public UsersController(Logic logic)
        {
            _logic = logic;
        }

        // api/users
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<AppUser>> GetUsers()
        {
            return await _logic.GetUsers();
        }

        // api/users/1
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUserById(int id)
        {
            return await _logic.GetUserById(id);
        }
    }
}
