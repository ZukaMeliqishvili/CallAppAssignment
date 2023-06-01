using Application._User.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application._User
{
    public interface IUserService
    {
        public Task<int> Login(UserLoginModel model,CancellationToken cancellationToken);
        public Task Register(UserRegisterModel model, CancellationToken cancellationToken);
    }
}
