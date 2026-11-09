using Uniaraxa.Domain.Entities;
using Uniaraxa.Domain.Interfaces;

namespace Uniaraxa.Infra.Repositories
{
    // Armazenamento em memória (lista estática) enquanto não há banco de dados.
    // Ao conectar um banco, só esta classe precisa mudar.
    public class TeacherRepository : ITeacherRepository
    {
        private static readonly List<Teacher> _teachers = new();
        private static readonly object _lock = new();
        private static int _nextId = 1;

        public void AddTeacher(Teacher teacher)
        {
            lock (_lock)
            {
                teacher.Id = _nextId++;
                _teachers.Add(teacher);
            }
        }

        public void UpdateTeacher(Teacher teacher)
        {
            lock (_lock)
            {
                var existing = _teachers.FirstOrDefault(t => t.Id == teacher.Id);
                if (existing is null) return;

                existing.Name = teacher.Name;
                existing.Email = teacher.Email;
                existing.UrlLattes = teacher.UrlLattes;
                existing.DataAdmissao = teacher.DataAdmissao;
            }
        }

        public void DeleteTeacher(int id)
        {
            lock (_lock)
            {
                _teachers.RemoveAll(t => t.Id == id);
            }
        }

        public List<Teacher> GetAllTeachers()
        {
            lock (_lock)
            {
                return new List<Teacher>(_teachers);
            }
        }

        public Teacher? GetTeacherById(int id)
        {
            lock (_lock)
            {
                return _teachers.FirstOrDefault(t => t.Id == id);
            }
        }
    }
}
