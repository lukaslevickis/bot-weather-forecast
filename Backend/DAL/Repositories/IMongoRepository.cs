using System.Threading.Tasks;
using Backend.DAL.Collections;

namespace Backend.DAL.Repositories
{
    public interface IMongoRepository
    {
        Task<User> GetUserProfileByIdAsync(string userId);
    }
}
