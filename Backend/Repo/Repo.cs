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

        public async Task<AppUser> RegisterUser(AppUser newUser)
        {
            users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<AppUser> LoginUser(string username)
        {
            return await users.SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<bool> UserExists(string username)
        {
            return await users.AnyAsync(user => user.UserName == username.ToLower());
        }

    }
}
