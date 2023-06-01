using Infrastructure._User;
using Infrastructure._UserProfile;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            User = new UserRepository(db);
            Profile = new ProfileRepository(db);
        }
        private ApplicationDbContext _db;
        public IUserRepository User { get; }

        public IProfileRepository Profile { get; }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
