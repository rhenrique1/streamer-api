using Microsoft.AspNetCore.Mvc;
using SS_API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SS_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        [Route("{courseId}")]
        public async Task<IActionResult> GetById(int courseId)
        {
            try
            {
                var course = await _courseService.FindCourseById(courseId);
                if (course != null)
                {
                    return Ok(course);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var courses = await _courseService.GetCourses();
                if (courses.Count > 0)
                {
                    return Ok(courses);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }
    }
}
