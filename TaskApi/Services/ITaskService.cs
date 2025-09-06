using System;
using System.Collections.Generic;
using TaskApi.Contracts;

namespace TaskApi.Services
{
    public interface ITaskService
    {
        IEnumerable<TaskDto> GetAll();
        TaskDto GetById(Guid id);
        TaskDto Create(CreateTaskDto dto);
        TaskDto Update(Guid id, UpdateTaskDto dto);
        bool Delete(Guid id);
    }
}
