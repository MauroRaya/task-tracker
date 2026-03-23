using Microsoft.AspNetCore.Mvc;
using TaskTracker.API.DTOs;
using TaskTracker.Application.Services;
using TaskTracker.Domain.Entities;

namespace TaskTracker.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectController(ProjectService projectService) : ControllerBase
{
    private readonly ProjectService _projectService = projectService;

    [HttpGet]
    public async Task<IActionResult> GetAllProjects()
    {
        var projects = await _projectService.GetAllAsync();
        return Ok(projects);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProjectById([FromRoute] int id)
    {
        var project = await _projectService.GetByIdAsync(id);
        return Ok(project);
    }

    [HttpGet("{name:alpha}")]
    public async Task<IActionResult> GetProjectByName([FromRoute] string name)
    {
        var project = await _projectService.GetByNameAsync(name);
        return Ok(project);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProject([FromBody] CreateProjectDTO dto)
    {
        var project = new Project
        {
            Name = dto.Name,
            Description = dto.Description,
        };

        var projectDb = await _projectService.CreateAsync(project);

        return CreatedAtAction(
            nameof(GetProjectById),
            new { id = projectDb.Id },
            projectDb
        );
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateProject(
        [FromRoute] int id,
        [FromBody] UpdateProjectDTO dto)
    {
        var project = new Project
        {
            Id = id,
            Name = dto.Name,
            Description = dto.Description,
        };

        var success = await _projectService.UpdateAsync(project);

        return success
            ? Ok("Projeto alterado com sucesso")
            : NotFound("Projeto não encontrado");
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProject([FromRoute] int id)
    {
        var success = await _projectService.DeleteAsync(id);

        return success
            ? Ok("Projeto deletado com sucesso")
            : NotFound("Projeto não encontrado");
    }
}