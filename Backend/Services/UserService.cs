using System.Threading.Tasks;
using Backend.DAL.Repositories;
using Backend.DAL.Collections;

namespace Backend.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoRepository _repository;

        public UserService(IMongoRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> GetUserProfileAsync(string userId)
        {
            return await _repository.GetUserProfileByIdAsync(userId);
        }
    }
}
