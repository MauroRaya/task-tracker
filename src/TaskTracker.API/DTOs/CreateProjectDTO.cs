using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskTracker.API.DTOs;

public class CreateProjectDTO
{
    [JsonPropertyName("name")]
    [Required(ErrorMessage = "Field name is required")]
    public required string Name { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string? Description { get; set; }
}