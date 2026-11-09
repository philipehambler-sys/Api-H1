using Uniaraxa.Domain.Entities;

namespace Uniaraxa.Domain.Interfaces
{
    public interface ITeacherRepository
    {
        void AddTeacher(Teacher teacher);
        void UpdateTeacher(Teacher teacher);
        void DeleteTeacher(int id);
        List<Teacher> GetAllTeachers();
        Teacher? GetTeacherById(int id);
    }
}
