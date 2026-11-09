using Uniaraxa.Domain.Entities;

namespace Uniaraxa.Domain.Interfaces
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
        List<Student> GetAllStudents();
        Student? GetStudentById(int id);
    }
}
