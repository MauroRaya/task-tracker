using Microsoft.EntityFrameworkCore;
using TaskTracker.Application.Interfaces;
using TaskTracker.Domain.Entities;
using TaskTracker.Infrastructure.Database;

namespace TaskTracker.Infrastructure.Repositories;

public class ProjectRepository(AppDbContext dbContext) : IProjectRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        return await _dbContext.Projects
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Project?> GetByIdAsync(int id)
    {
        return await _dbContext.Projects.FindAsync(id);
    }

    public async Task<Project?> GetByNameAsync(string name)
    {
        return await _dbContext.Projects
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Name == name);
    }

    public async Task<Project> CreateAsync(Project project)
    {
        await _dbContext.AddAsync(project);
        await _dbContext.SaveChangesAsync();
        return project;
    }

    public async Task<bool> UpdateAsync(Project project)
    {
        var existing = await _dbContext.Projects.FindAsync(project.Id);
        if (existing is null) return false;

        existing.Name = project.Name;
        existing.Description = project.Description;

        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _dbContext.Projects.FindAsync(id);
        if (existing is null) return false;

        _dbContext.Projects.Remove(existing);
        return await _dbContext.SaveChangesAsync() > 0;
    }
}