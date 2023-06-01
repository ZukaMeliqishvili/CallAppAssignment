using Application._User;
using Application._User.Request;
using Domain;
using Infrastructure;
using Mapster;
using System.Security.Cryptography;
using System.Text;

namespace Application._User
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Login(UserLoginModel model, CancellationToken cancellationToken)
        {
            //var users = await _unitOfWork.User.GetAllAsync(cancellationToken);
            //var user = users.SingleOrDefault(x => x.UserName == model.UserName);
            var user = await _unitOfWork.User.GetByUserNameAsync( model.UserName);
            if (user == null)
            {
                throw new Exception("user by given username does not exists");
            }
            if (user.Password !=  HashPassword(model.Password))
            {
                throw new Exception("wrong password");
            }
            return user.Id;
        }

        public async Task Register(UserRegisterModel model ,CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Password))
            {
                throw new Exception("Please enter valid user credentials");
            }
            if (await _unitOfWork.User.Exists(cancellationToken,x=>x.UserName==model.UserName))
            {
                throw new Exception("given username is already used");
            }
            if(await _unitOfWork.User.Exists(cancellationToken,x=>x.Email==model.Email))
            {
                throw new Exception("given email address is already used");
            }
            model.Password = HashPassword(model.Password);
            User entity = model.Adapt<User>();
            await _unitOfWork.User.CreateAsync(cancellationToken, entity);
            await _unitOfWork.SaveAsync();
        }

        private string HashPassword(string password)
        {
            string key = "$1*0&";
            password += key;
            string hashed = String.Empty;

            using (SHA256 sha256 = SHA256.Create())
            {

                byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));


                foreach (byte b in hashValue)
                {
                    hashed += $"{b:X2}";
                }
            }

            return hashed;
        }
    }
}
