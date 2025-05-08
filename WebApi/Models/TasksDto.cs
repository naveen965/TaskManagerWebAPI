using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class TasksDto
    {
        [Required]
        public string? Title { get; set; } = "";

        [MaxLength(500)]
        public string Description { get; set; } = "";

        [Required]
        public int Priority { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
