using Domain;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure._User
{
    public class UserRepository:BaseRepository<User>,IUserRepository
    {
        private readonly ApplicationDbContext db;

        public UserRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
           return await db.Users.Where(i => i.UserName == userName).FirstOrDefaultAsync();
        }
    }
}
