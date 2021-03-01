using System;
using System.Collections.Generic;
using System.Text;

namespace Repo
{
    public class Repository
    {

        private readonly SwipeRightDbContext _context;

        public Repository(SwipeRightDbContext context)
        {
            _context = context;
        }

    }
}
