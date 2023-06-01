using Application.Profile.Request;
using Application.Profile.Response;
using Domain;
using Infrastructure;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profile
{
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProfileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CancellationToken cancellationToken, ProfileRequestModel model, int userId)
        {
            if(model == null)
            {
                throw new Exception("something went wrong");
            }
            if(await _unitOfWork.Profile.Exists(cancellationToken,i=>i.UserId==userId))
            {
                throw new Exception("user already has a profile");
            }
           
            var profile = model.Adapt<UserProfile>();
            profile.UserId = userId;
            await _unitOfWork.Profile.CreateAsync(cancellationToken, profile);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id, int userId)
        {
            var profile = await _unitOfWork.Profile.GetByIdAsync(cancellationToken, id);
            if(profile == null)
            {
                throw new Exception("Profile does not exists");
            }
            if(profile.UserId != userId) 
            {
                throw new Exception("can not delete another users profile");
            }
            await _unitOfWork.Profile.DeleteAsync(cancellationToken, id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<ProfileResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var profiles = await _unitOfWork.Profile.GetAllAsync(cancellationToken);
            return profiles.Adapt<List<ProfileResponseModel>>();
        }

        public async Task<ProfileResponseModel> GetAsync(CancellationToken cancellationToken, int id)
        {
            var profile = await _unitOfWork.Profile.GetByIdAsync(cancellationToken,id);
            if(profile == null)
            {
                throw new Exception("No profile found by the given id");
            }
            return profile.Adapt<ProfileResponseModel>();
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, ProfileUpdateRequestModel model, int userId)
        {
            var profile = await _unitOfWork.Profile.GetByIdAsync(cancellationToken, model.Id);
            if(profile == null)
            {
                throw new Exception("No profile found by the given id");
            }
            if(profile.UserId!=userId)
            {
                throw new Exception("Can not update profile of other users");
            }
            profile.FirstName=model.FirstName;
            profile.LastName = model.LastName;
            profile.PersonalNumber = model.PersonalNumber;
            _unitOfWork.Profile.Update(profile);
            await _unitOfWork.SaveAsync();

        }
    }
}
