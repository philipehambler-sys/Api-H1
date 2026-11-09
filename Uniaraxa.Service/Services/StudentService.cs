using Uniaraxa.Domain.Entities;
using Uniaraxa.Domain.Interfaces;

namespace Uniaraxa.Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void AddStudent(Student student)
        {
            _studentRepository.AddStudent(student);
        }

        public bool UpdateStudent(Student student)
        {
            if (_studentRepository.GetStudentById(student.Id) is null)
                return false;

            _studentRepository.UpdateStudent(student);
            return true;
        }

        public void DeleteStudent(int id)
        {
            _studentRepository.DeleteStudent(id);
        }

        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetAllStudents();
        }

        public Student? GetStudentById(int id)
        {
            return _studentRepository.GetStudentById(id);
        }
    }
}
