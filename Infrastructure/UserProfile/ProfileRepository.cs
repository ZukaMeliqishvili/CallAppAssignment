using Domain;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure._UserProfile
{
    public class ProfileRepository:BaseRepository<UserProfile>, IProfileRepository
    {
        private readonly ApplicationDbContext db;

        public ProfileRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }
    }
}
