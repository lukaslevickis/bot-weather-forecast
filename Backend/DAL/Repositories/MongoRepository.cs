﻿using System.Linq;
using System.Threading.Tasks;
using Backend.DAL.Collections;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Backend.DAL.Repositories
{
    public class MongoRepository : IMongoRepository
    {
        private readonly IMongoCollection<UserProfile> _userProfileCollection;

        public MongoRepository(IMongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _userProfileCollection = database.GetCollection<UserProfile>("UserProfile");
        }

        public async Task<User> GetUserProfileByIdAsync(string userId)
        {
            var userProfileCollection = await _userProfileCollection.Find(new BsonDocument()).ToListAsync();

            foreach (var userProfile in userProfileCollection)
            {
                var user = userProfile.Users
                    .FirstOrDefault(u => u.Id == userId);

                if (user != null)
                {
                    return user;
                }
            }

            return null;
        }
    }
}
