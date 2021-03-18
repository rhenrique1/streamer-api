using SS_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SS_API.Services.Interfaces
{
    public interface IProjectService
    {
        Task<Project> FindProjectById(int projectId);
        Task<List<Project>> FindProjectByCourse(int courseId);
        Task<bool> UpdateProject(Project project);
        Task<bool> DeleteProject(int projectId);
        Task<Project> CreateProject(Project project);
    }
}
