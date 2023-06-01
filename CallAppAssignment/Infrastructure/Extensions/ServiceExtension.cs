using Application._User;
using Application.JsonPlaceholder;
using Application.Profile;
using Infrastructure;

namespace CallAppAssignment.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IJsonPlaceholderService, JsonPlaceholderService>();
        }
    }
}
