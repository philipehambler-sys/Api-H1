using Microsoft.AspNetCore.Mvc;
using Uniaraxa.Domain.Entities;
using Uniaraxa.Service.Services;

namespace Uniaraxa.API.Controllers
{
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        [Route("api/teacher")]
        public IActionResult GetAllTeachers()
        {
            return Ok(_teacherService.GetAllTeachers());
        }

        [HttpGet]
        [Route("api/teacher/{id}")]
        public IActionResult GetTeacherById(int id)
        {
            var teacher = _teacherService.GetTeacherById(id);
            if (teacher is null)
            {
                return NotFound("Teacher not found.");
            }
            return Ok(teacher);
        }

        [HttpPost]
        [Route("api/teacher")]
        public IActionResult AddTeacher([FromBody] Teacher teacher)
        {
            _teacherService.AddTeacher(teacher);
            return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.Id }, teacher);
        }

        [HttpPut]
        [Route("api/teacher/{id}")]
        public IActionResult UpdateTeacher(int id, [FromBody] Teacher teacher)
        {
            teacher.Id = id;
            if (!_teacherService.UpdateTeacher(teacher))
            {
                return NotFound("Teacher not found.");
            }
            return Ok(teacher);
        }

        [HttpDelete]
        [Route("api/teacher/{id}")]
        public IActionResult DeleteTeacher(int id)
        {
            if (!_teacherService.DeleteTeacher(id))
            {
                return NotFound("Teacher not found.");
            }
            return NoContent();
        }
    }
}
