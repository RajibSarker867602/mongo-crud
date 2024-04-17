using MongoCRUD.Data;
using MongoCRUD.Models.Entities;
using MongoCRUD.Repositories.Base;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoCRUD.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly MongoDbContext _db;

        public StudentRepository(MongoDbContext db) : base(db.Students)
        {
            _db = db;
        }

        //private readonly MongoDbContext _db;

        //public StudentRepository(MongoDbContext _db)
        //{
        //    this._db = _db;
        //}
        //public async Task<Student> CreateAsync(Student student)
        //{
        //    await _db.Students.InsertOneAsync(student);
        //    return student;
        //}

        //public async Task<bool> DeleteAsync(string id)
        //{
        //    if (id is null) throw new ArgumentNullException(nameof(id));

        //    var result = await _db.Students.DeleteOneAsync(c=> c.Id == id);
        //    return result.IsAcknowledged;
        //}

        //public async Task<bool> DeleteByEmailAsync(string Email)
        //{
        //    if (string.IsNullOrEmpty(Email)) throw new ArgumentNullException(nameof(Email));

        //    var studentToDelete = await _db.Students.Find<Student>(c => c.Email == Email).FirstOrDefaultAsync();
        //    if (studentToDelete is null) return false;

        //    return await DeleteAsync(studentToDelete.Id);
        //}

        //public async Task<IEnumerable<Student>> GetAllAsync()
        //{
        //    return await _db.Students.Find(new BsonDocument()).ToListAsync();
        //}

        //public async Task<Student> GetByEmailAsync(string email)
        //{
        //    return await _db.Students.Find(c => c.Email == email).FirstOrDefaultAsync();
        //}

        //public async Task<Student> GetByIdAsync(string id)
        //{
        //    return await _db.Students.Find(c => c.Id == id).FirstOrDefaultAsync();
        //}

        //public async Task<Student> UpdateAsync(Student student)
        //{
        //    if (student is null) throw new ArgumentNullException(nameof(student));

        //    var result = await _db.Students.ReplaceOneAsync<Student>(c => c.Id == student.Id, student);
        //    if (result.IsModifiedCountAvailable) return student;

        //    return null;
        //}
    }
}
