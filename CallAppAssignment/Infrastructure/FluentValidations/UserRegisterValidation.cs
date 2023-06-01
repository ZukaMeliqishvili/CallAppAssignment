using Application._User.Request;
using FluentValidation;

namespace CallAppAssignment.Infrastructure.FluentValidations
{
    public class UserRegisterValidation:AbstractValidator<UserRegisterModel>
    {
        public UserRegisterValidation()
        {
            RuleFor(x => x.UserName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(30)
                .Matches("^[A-Za-z0-9]*$")
                .WithErrorCode("Invalid username");
            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(30)
                .WithMessage("password must contain minimum 8 characters");
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(25)
                .Matches("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\\.[a-zA-Z0-9-]+)*$")
                .WithMessage("Invalid email address");
        }
    }
}
