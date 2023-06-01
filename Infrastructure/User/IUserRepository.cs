using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure._User
{
    public interface IUserRepository:IBaseRepository<User>
    {
        Task<User> GetByUserNameAsync(string userName);
    }
}
