using System;
using System.Collections.Generic;
using System.Linq;
using TaskApi.Contracts;
using TaskApi.Domain.Entities;
using TaskApi.Repositories;

namespace TaskApi.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<TaskDto> GetAll()
        {
            return _repository.GetAll().Select(MapToDto);
        }

        public TaskDto GetById(Guid id)
        {
            var task = _repository.GetById(id);
            return task == null ? null : MapToDto(task);
        }

        public TaskDto Create(CreateTaskDto dto)
        {
            var task = new TaskItem
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow,
                DueAt = dto.DueAt,
                Priority = dto.Priority,
                IsCompleted = dto.IsCompleted
            };

            if (task.DueAt.HasValue && task.DueAt < task.CreatedAt)
                throw new ArgumentException("DueAt не может быть раньше CreatedAt");

            _repository.Create(task);
            return MapToDto(task);
        }

        public TaskDto Update(Guid id, UpdateTaskDto dto)
        {
            var existing = _repository.GetById(id);
            if (existing == null) return null;

            existing.Title = dto.Title;
            existing.Description = dto.Description;
            existing.DueAt = dto.DueAt;
            existing.Priority = dto.Priority;
            existing.IsCompleted = dto.IsCompleted;

            if (existing.DueAt.HasValue && existing.DueAt < existing.CreatedAt)
                throw new ArgumentException("DueAt не может быть раньше CreatedAt");

            _repository.Update(existing);
            return MapToDto(existing);
        }

        public bool Delete(Guid id)
        {
            var existing = _repository.GetById(id);
            if (existing == null) return false;

            _repository.Delete(id);
            return true;
        }

        private static TaskDto MapToDto(TaskItem task)
        {
            return new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                CreatedAt = task.CreatedAt,
                DueAt = task.DueAt,
                Priority = task.Priority,
                IsCompleted = task.IsCompleted
            };
        }
    }
}
