using Application.Profile.Request;
using FluentValidation;

namespace CallAppAssignment.Infrastructure.FluentValidations
{
    public class ProfileRequestModelValidation:AbstractValidator<ProfileRequestModel>
    {
        public ProfileRequestModelValidation()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(x=>x.LastName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(80);
            RuleFor(x => x.PersonalNumber)
                .NotNull()
                .NotEmpty()
                .Matches(@"^\d{11}$")
                .WithMessage("Invalid private number");
        }
    }
}
