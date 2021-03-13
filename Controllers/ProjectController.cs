using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SS_API.Model;
using SS_API.Services.Interfaces;

namespace SS_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [Route("{projectId}")]
        public async Task<IActionResult> GetById(int projectId)
        {
            try
            {
                var project = await _projectService.FindProjectById(projectId);
                if(project != null)
                {
                    return Ok(project);
                }
                return NotFound();
            } 
            catch(Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }

        [HttpGet]
        [Route("course/{courseId}")]
        public async Task<IActionResult> GetByCourse(int courseId)
        {
            try
            {
                var projects = await _projectService.FindProjectByCourse(courseId);
                if(projects.Count > 0)
                {
                    return Ok(projects);
                }
                return NotFound();
            }
            catch(Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Project project)
        {
            try
            {
                var isUpdated = await _projectService.UpdateProject(project);
                return Ok(isUpdated);
            }
            catch(Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }

        [HttpDelete]
        [Route("{projectId}")]
        public async Task<IActionResult> Delete(int projectId)
        {
            try
            {
                var deleted = await _projectService.DeleteProject(projectId);
                if(deleted)
                {
                    return Ok(true);
                }
                return NotFound(false);
            }
            catch(Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Project project)
        {
            try
            {
                var newProject = await _projectService.CreateProject(project);
                return Ok(newProject.Id);
            }
            catch(Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }
    }
}