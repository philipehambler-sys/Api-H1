using Uniaraxa.Domain.Entities;
using Uniaraxa.Domain.Interfaces;

namespace Uniaraxa.Service.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public void AddTeacher(Teacher teacher)
        {
            _teacherRepository.AddTeacher(teacher);
        }

        public bool UpdateTeacher(Teacher teacher)
        {
            if (_teacherRepository.GetTeacherById(teacher.Id) is null)
                return false;

            _teacherRepository.UpdateTeacher(teacher);
            return true;
        }

        public bool DeleteTeacher(int id)
        {
            if (_teacherRepository.GetTeacherById(id) is null)
                return false;

            _teacherRepository.DeleteTeacher(id);
            return true;
        }

        public List<Teacher> GetAllTeachers()
        {
            return _teacherRepository.GetAllTeachers();
        }

        public Teacher? GetTeacherById(int id)
        {
            return _teacherRepository.GetTeacherById(id);
        }
    }
}
