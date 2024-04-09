using System.ComponentModel.DataAnnotations;

namespace TaskApp.Models.DTO
{
    public class MyTaskDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string TaskName { get; set; }
        [Required]
        public string TaskDescription { get; set; }
    }
}
