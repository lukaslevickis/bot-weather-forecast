using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.DAL.Collections;
using MongoDB.Bson;

namespace Backend.Services
{
    public interface IUserService
    {
        User GetUserProfileAsync(string userId);
    }
}
