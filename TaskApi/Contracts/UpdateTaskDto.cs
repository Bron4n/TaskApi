using System;
using System.ComponentModel.DataAnnotations;

namespace TaskApi.Contracts
{
    public class UpdateTaskDto
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public DateTime? DueAt { get; set; }

        [Range(1, 5)]
        public int Priority { get; set; }

        public bool IsCompleted { get; set; }
    }
}
