using Uniaraxa.Domain.Entities;

namespace Uniaraxa.Service.Services
{
    public interface IStudentService
    {
        void AddStudent(Student student);
        bool UpdateStudent(Student student);
        void DeleteStudent(int id);
        List<Student> GetAllStudents();
        Student? GetStudentById(int id);
    }
}
