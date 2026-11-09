using Uniaraxa.Domain.Entities;
using Uniaraxa.Domain.Interfaces;

namespace Uniaraxa.Infra.Repositories
{
    // Armazenamento em memória (lista estática) enquanto não há banco de dados.
    public class StudentRepository : IStudentRepository
    {
        private static readonly List<Student> _students = new();
        private static readonly object _lock = new();
        private static int _nextId = 1;

        public void AddStudent(Student student)
        {
            lock (_lock)
            {
                student.Id = _nextId++;
                _students.Add(student);
            }
        }

        public void UpdateStudent(Student student)
        {
            lock (_lock)
            {
                var existing = _students.FirstOrDefault(s => s.Id == student.Id);
                if (existing is null) return;

                existing.Name = student.Name;
                existing.Email = student.Email;
            }
        }

        public void DeleteStudent(int id)
        {
            lock (_lock)
            {
                _students.RemoveAll(s => s.Id == id);
            }
        }

        public List<Student> GetAllStudents()
        {
            lock (_lock)
            {
                return new List<Student>(_students);
            }
        }

        public Student? GetStudentById(int id)
        {
            lock (_lock)
            {
                return _students.FirstOrDefault(s => s.Id == id);
            }
        }
    }
}
