using System;

namespace TaskApi.Domain.Entities
{
    public class TaskItem
    {
        public Guid Id { get; set; }          // УН
        public string Title { get; set; }     // Имя задачи
        public string Description { get; set; } // Её имя
        public DateTime CreatedAt { get; set; } // Дата задачи
        public DateTime? DueAt { get; set; }    // Дедлайн
        public int Priority { get; set; }       // Приоритет 1-5
        public bool IsCompleted { get; set; }   // Выполнена или нет
    }
}

