using TaskTracker.Application.Interfaces;
using TaskTracker.Domain.Entities;

namespace TaskTracker.Application.Services;

public class ProjectService(IProjectRepository projectRepository)
{
    private readonly IProjectRepository _projectRepository = projectRepository;

    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        return await _projectRepository.GetAllAsync();
    }

    public async Task<Project?> GetByIdAsync(int id)
    {
        return await _projectRepository.GetByIdAsync(id);
    }

    public async Task<Project?> GetByNameAsync(string name)
    {
        return await _projectRepository.GetByNameAsync(name);
    }

    public async Task<Project> CreateAsync(Project project)
    {
        return await _projectRepository.CreateAsync(project);
    }

    public async Task<bool> UpdateAsync(Project project)
    {
        return await _projectRepository.UpdateAsync(project);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _projectRepository.DeleteAsync(id);
    }
}