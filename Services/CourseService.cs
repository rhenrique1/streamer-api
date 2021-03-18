using Microsoft.EntityFrameworkCore;
using SS_API.Data;
using SS_API.Model;
using SS_API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SS_API.Services
{
    public class CourseService : ICourseService
    {
        private readonly StreamerContext _context;

        public CourseService(StreamerContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> FindCourseById(int courseId)
        {
            return await _context.Courses.FirstOrDefaultAsync(x => x.Id == courseId);
        }
    }
}
