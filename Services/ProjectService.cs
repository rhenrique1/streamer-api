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
    public class ProjectService : IProjectService
    {
        private readonly StreamerContext _context;

        public ProjectService(StreamerContext context)
        {
            _context = context;
        }
        public async Task<Project> FindProjectById(int projectId)
        {
            return await _context.Projects.Include(x => x.Course).FirstOrDefaultAsync(x => x.Id == projectId);
        }
        public async Task<List<Project>> FindProjectByCourse(int courseId)
        {
            return await _context.Projects.Where(x => x.CourseId == courseId).Include(x => x.Course).ToListAsync();
        }
        public async Task<bool> UpdateProject(Project project)
        {
            var currentProject = await this.FindProjectById(project.Id);
            
            if(currentProject == null)
            {
                return false;
            }

            _context.Entry(currentProject).CurrentValues.SetValues(project);

            return (await _context.SaveChangesAsync() > 0);
        }
        public async Task<bool> DeleteProject(int projectId)
        {
            var project = await this.FindProjectById(projectId);

            if(project == null)
            {
                return false;
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<Project> CreateProject(Project project)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == project.CourseId);

            project.Course = course;
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            return await this.FindProjectById(project.Id);
        }
    }
}
