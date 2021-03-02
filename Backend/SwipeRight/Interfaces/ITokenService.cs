using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Models;

namespace SwipeRight.Interfaces
{
    public interface ITokenService
    {
            public string CreateToken(AppUser user);
    }
}
