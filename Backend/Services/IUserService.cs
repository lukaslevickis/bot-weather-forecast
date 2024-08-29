using System.Threading.Tasks;
using Backend.DAL.Collections;

namespace Backend.Services
{
    public interface IUserService
    {
        Task<User> GetUserProfileAsync(string userId);
    }
}
