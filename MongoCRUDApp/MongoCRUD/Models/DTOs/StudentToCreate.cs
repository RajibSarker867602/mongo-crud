using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoCRUD.Models.DTOs
{
    public class StudentToCreate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
