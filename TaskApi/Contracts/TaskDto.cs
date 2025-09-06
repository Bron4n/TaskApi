using System;

namespace TaskApi.Contracts
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DueAt { get; set; }
        public int Priority { get; set; }
        public bool IsCompleted { get; set; }
    }
}
