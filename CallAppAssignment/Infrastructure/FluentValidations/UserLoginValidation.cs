using Application._User.Request;
using FluentValidation;

namespace CallAppAssignment.Infrastructure.FluentValidations
{
    public class UserLoginValidation:AbstractValidator<UserLoginModel>
    {
        public UserLoginValidation()
        {
            RuleFor(x => x.UserName)
               .NotNull()
               .NotEmpty()
               .MinimumLength(4)
               .MaximumLength(30)
               .Matches("^[A-Za-z0-9]*$")
               .WithErrorCode("Invalid username");
        }
    }
}
