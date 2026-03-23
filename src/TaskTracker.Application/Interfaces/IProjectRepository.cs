using TaskTracker.Domain.Entities;

namespace TaskTracker.Application.Interfaces;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> GetAllAsync();
    Task<Project?> GetByIdAsync(int id);
    Task<Project?> GetByNameAsync(string name);
    Task<Project>CreateAsync(Project project);
    Task<bool>UpdateAsync(Project project);
    Task<bool>DeleteAsync(int id);
}