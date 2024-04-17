using Microsoft.Extensions.Options;
using MongoCRUD.Models;
using MongoCRUD.Models.Entities;
using MongoDB.Driver;

namespace MongoCRUD.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;
        public MongoDbContext(IOptions<MongoDbConfigurations> configurations)
        {
            var client = new MongoClient(configurations.Value.ConnectionString);
            _database = client.GetDatabase(configurations.Value.DatabaseName);
        }

        // collections
        public IMongoCollection<Student> Students => _database.GetCollection<Student>("students");
    }
}
