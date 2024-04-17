
using MongoDB.Bson;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;

namespace MongoCRUD.Repositories.Base
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        protected Repository(IMongoCollection<T> collection)
        {
            _collection = collection;
        }
        public async Task<T> CreateAsync(T entity)
        {
            if (entity is null) return null;

            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", new ObjectId(id)));
            return result.IsAcknowledged;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _collection.Find(Builders<T>.Filter.Eq("_id", new ObjectId(id))).FirstOrDefaultAsync();
        }

        public async Task<T> UpdateAsync(string id, T entity)
        {
            var result = await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", new ObjectId(id)), entity);
            if (result.IsAcknowledged) return entity;
            
            return null;
        }
    }
}
