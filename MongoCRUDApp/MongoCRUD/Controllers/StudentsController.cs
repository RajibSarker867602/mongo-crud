using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoCRUD.Data;
using MongoCRUD.Models;
using MongoCRUD.Models.DTOs;
using MongoCRUD.Models.Entities;
using MongoCRUD.Repositories;
using System.Security.Cryptography.X509Certificates;

namespace MongoCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _studentRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _studentRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(StudentToCreate student)
        {
            if (student is null) return BadRequest("Invalid input request.");

            await _studentRepository.CreateAsync(new Student()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                Address = student.Address,
            });
            return Ok(student);
        }

        [HttpPut]
        public async Task<IActionResult> Put(string id, [FromBody] StudentToCreate student)
        {
            if (student is null) return BadRequest("Invalid input request.");

            var existingStudent = await _studentRepository.GetByIdAsync(id);
            if (existingStudent is null) return BadRequest($"Student could not found by id: {id}");

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.Email = student.Email;
            existingStudent.Address = student.Address;
            return Ok(await _studentRepository.UpdateAsync(id, existingStudent));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id is null) return BadRequest("Invalid input request.");

            return Ok(await _studentRepository.DeleteAsync(id));
        }
    }
}
