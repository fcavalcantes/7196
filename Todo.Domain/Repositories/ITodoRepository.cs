using System;
using System.Collections.Generic;
using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface ITodoRepository
    {
        void Create(TodoItem todoItem);
        void Update(TodoItem todoItem);
        TodoItem GetById(Guid id, string user);

        IEnumerable<TodoItem> GetAll(string email);
        IEnumerable<TodoItem> GetAllDone(string email);
        IEnumerable<TodoItem> GetAllUndone(string email);
        IEnumerable<TodoItem> GetByPeriod(string email, DateTime date, bool done);
    }
}