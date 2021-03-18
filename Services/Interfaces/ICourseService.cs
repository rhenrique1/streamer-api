using SS_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SS_API.Services.Interfaces
{
    public interface ICourseService
    {
        Task<List<Course>> GetCourses();
        Task<Course> FindCourseById(int courseId);
    }
}
