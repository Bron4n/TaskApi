using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using TaskApi.Domain.Entities;

namespace TaskApi.Repositories
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        private readonly ConcurrentDictionary<Guid, TaskItem> _tasks = new();

        public InMemoryTaskRepository()
        {
            var defaultTask = new TaskItem
            {
                Id = Guid.NewGuid(),
                Title = "Пример задачи",
                Description = "Это тестовая задача из памяти",
                CreatedAt = DateTime.UtcNow,
                DueAt = DateTime.UtcNow.AddDays(7),
                Priority = 3,
                IsCompleted = false
            };

            _tasks.TryAdd(defaultTask.Id, defaultTask);
        }

        public IEnumerable<TaskItem> GetAll()
        {
            return _tasks.Values.ToList();
        }

        public TaskItem GetById(Guid id)
        {
            _tasks.TryGetValue(id, out var task);
            return task;
        }

        public void Create(TaskItem task)
        {
            _tasks.TryAdd(task.Id, task);
        }

        public void Update(TaskItem task)
        {
            _tasks[task.Id] = task;
        }

        public void Delete(Guid id)
        {
            _tasks.TryRemove(id, out _);
        }
    }
}
