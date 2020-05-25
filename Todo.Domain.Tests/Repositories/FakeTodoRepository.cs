using System;
using System.Collections.Generic;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;


namespace Todo.Domain.Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public FakeTodoRepository()
        {
            
        }
        public void Create(TodoItem todoItem)
        {
        }

        public IEnumerable<TodoItem> GetAll(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllDone(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllUndone(string email)
        {
            throw new NotImplementedException();
        }

        public TodoItem GetById(Guid id, string user)
        {
            return new TodoItem("", DateTime.Now, "");
        }

        public IEnumerable<TodoItem> GetByPeriod(string email, DateTime date, bool done)
        {
            throw new NotImplementedException();
        }

        public void Update(TodoItem todoItem)
        {
        }
    }
}