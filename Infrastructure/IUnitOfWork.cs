using Infrastructure._User;
using Infrastructure._UserProfile;

namespace Infrastructure
{
    public interface IUnitOfWork:IDisposable
    {
        public IUserRepository User { get; }
        public IProfileRepository Profile { get; }
        Task SaveAsync();
    }
}
