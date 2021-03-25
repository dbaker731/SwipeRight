using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Model.DTOs;
using Model.Models;
using Repo;

namespace Service
{
    public class Logic
    {
        private readonly Repository _repo;
        private readonly Mapper _mapper;

        public Logic(Repository repo, Mapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // Account controller
        public async Task<AppUser> RegisterUser(RegisterDto registerDto)
        {
            using var hmac = new HMACSHA512();
            AppUser user = new AppUser()
            {
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };
            return await _repo.RegisterUser(user);
        }

        public async Task<AppUser> LoginUser(LoginDto loginDto)
        {
            AppUser user = await _repo.LoginUser(loginDto.Username);
            return user;
        }

        public AppUser CheckPassword(AppUser user, LoginDto loginDto)
        {
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    return null;
                }
            }
            return user;
        }

        public async Task<bool> UserExists(string username)
        {
            return await _repo.UserExists(username);
        }

        // User controller
        public async Task<IEnumerable<AppUser>> GetUsers()
        {
            return await _repo.GetUsers();
        }

        public async Task<AppUser> GetUserById(int id)
        {
            return await _repo.GetUserById(id);
        }

        public AppUser GetUserByIdNonAsync(int id)
        {
            return _repo.GetUserByIdNonAsync(id);
        }


    }
}
