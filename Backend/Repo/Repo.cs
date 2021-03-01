using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace Repo
{
    public class Repository
    {

        private readonly SwipeRightDbContext _context;
        DbSet<AppUser> users;

        public Repository(SwipeRightDbContext context)
        {
            _context = context;
            users = _context.Users;
        }

        public async Task<IEnumerable<AppUser>> GetUsers()
        {
            return await users.ToListAsync();  
        }

        public async Task<AppUser> GetUserById(int id)
        {
            return await users.FirstOrDefaultAsync(users => users.Id == id);
        }

    }
}
