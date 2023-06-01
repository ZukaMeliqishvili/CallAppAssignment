using Application.Profile;
using Application.Profile.Request;
using Application.Profile.Response;
using Infrastructure._UserProfile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CallAppAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }
        protected virtual int GetUserId()
        {
            return int.Parse(HttpContext.User.Claims.FirstOrDefault(i => i.Type == "UserId").Value);
        }
        [HttpGet]
        public async Task<List<ProfileResponseModel>> GetAllProfiles(CancellationToken cancellationToken)
        {
            return await _profileService.GetAllAsync(cancellationToken);
        }
        [HttpGet("{id}")]
        public async Task<ProfileResponseModel> GetProfile(CancellationToken cancellationToken,int id)
        {
            return await _profileService.GetAsync(cancellationToken,id);
        }
        [HttpPost]
        public async Task CreateProfile(CancellationToken cancellationToken, ProfileRequestModel model)
        {
            await _profileService.CreateAsync(cancellationToken, model, GetUserId());
        }
        [HttpDelete("{id}")]
        public async Task DeleteProfile(CancellationToken cancellationToken, int id)
        {
            await _profileService.DeleteAsync(cancellationToken,id,GetUserId());
        }
        [HttpPut]
        public async Task UpdateProfile(CancellationToken cancellationToken,ProfileUpdateRequestModel model)
        {
            await _profileService.UpdateAsync(cancellationToken, model, GetUserId());
        }
    }
}
