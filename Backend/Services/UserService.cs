using System.Threading.Tasks;
using Backend.DAL.Repositories;
using Backend.DAL.Collections;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Backend.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoRepository _repository;

        public UserService(IMongoRepository repository)
        {
            _repository = repository;
        }

        public User GetUserProfileAsync(string userId)
        {
            return _repository.GetUserProfileByIdAsync(userId);
        }
    }
}
