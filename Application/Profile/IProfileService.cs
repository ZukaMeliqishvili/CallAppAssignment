using Application.Profile.Request;
using Application.Profile.Response;
using Domain;

namespace Application.Profile
{
    public interface IProfileService
    {
        Task<List<ProfileResponseModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<ProfileResponseModel> GetAsync(CancellationToken cancellationToken, int id);
        Task CreateAsync(CancellationToken cancellationToken, ProfileRequestModel model,int userId);
        Task UpdateAsync(CancellationToken cancellationToken, ProfileUpdateRequestModel model,int userId);
        Task DeleteAsync(CancellationToken cancellationToken, int id, int userId);
    }
}
