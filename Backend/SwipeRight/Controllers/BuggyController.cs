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
    public class BuggyController : ControllerBase
    {
        private readonly Logic _logic;
        public BuggyController(Logic logic)
        {
            _logic = logic;
        }
        
        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            AppUser user = _logic.GetUserByIdNonAsync(-1);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            AppUser user = _logic.GetUserByIdNonAsync(-1);
            var exc = user.ToString();
            // should throw exception
            return exc;
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
                return BadRequest("This was a bad request");
        }

    }
}
