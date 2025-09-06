using System;
using System.Collections.Generic;
using TaskApi.Domain.Entities;

namespace TaskApi.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<TaskItem> GetAll();
        TaskItem GetById(Guid id);
        void Create(TaskItem task);
        void Update(TaskItem task);
        void Delete(Guid id);
    }
}
