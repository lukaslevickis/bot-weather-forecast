using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.DAL.Collections;
using MongoDB.Bson;

namespace Backend.DAL.Repositories
{
    public interface IMongoRepository
    {
        User GetUserProfileByIdAsync(string userId);
    }
}
