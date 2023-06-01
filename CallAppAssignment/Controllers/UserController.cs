using Application._User;
using Application._User.Request;
using CallAppAssignment.Infrastructure.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CallAppAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private readonly IOptions<JWTConfiguration> _options;

        public UserController(IUserService userService, IOptions<JWTConfiguration> options)
        {
            _userService = userService;
            _options = options;
        }
        [Route("LogIn")]
        [HttpPost]
        public async Task<string> Login(UserLoginModel model, CancellationToken cancellationToken)
        {
            var result = await _userService.Login(model,cancellationToken);
            return JWTHelper.GenerateSecurityToken(result, _options);
        }
        [Route("Register")]
        [HttpPost]
        public async Task Register(CancellationToken cancellationToken, UserRegisterModel model)
        {
            await _userService.Register(model,cancellationToken);
        }

    }
}
