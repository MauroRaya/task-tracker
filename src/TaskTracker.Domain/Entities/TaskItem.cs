namespace TaskTracker.Domain.Entities;

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Project Project { get; set; } = new();
    public ICollection<User> Users { get; set; } = new List<User>();
}