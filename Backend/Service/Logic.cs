using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<AppUser>> GetUsers()
        {
            return await _repo.GetUsers();
        }

        public async Task<AppUser> GetUserById(int id)
        {
            return await _repo.GetUserById(id);
        }
    }
}
