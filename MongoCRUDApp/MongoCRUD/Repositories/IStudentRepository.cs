using MongoCRUD.Models.Entities;
using MongoCRUD.Repositories.Base;

namespace MongoCRUD.Repositories
{
    public interface IStudentRepository: IRepository<Student>
    {
        //Task<IEnumerable<Student>> GetAllAsync();
        //Task<Student> GetByIdAsync(string id);
        //Task<Student> GetByEmailAsync(string email);
        //Task<Student> CreateAsync(Student student);
        //Task<Student> UpdateAsync(Student student);
        //Task<bool> DeleteAsync(string id);
        //Task<bool> DeleteByEmailAsync(string Email);
    }
}
