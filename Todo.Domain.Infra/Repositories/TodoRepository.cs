using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;
        public TodoRepository(TodoContext context)
        {
            _context = context;
        }
        public void Create(TodoItem todoItem)
        {
            _context.Todos.Add(todoItem);
            _context.SaveChanges();
        }
        public IEnumerable<TodoItem> GetAll(string email)
        {
            return _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetAll(email))
            .OrderBy(t => t.Date);
        }
        public IEnumerable<TodoItem> GetAllDone(string email)
        {
            return _context.Todos
        .AsNoTracking()
        .Where(TodoQueries.GetAllDone(email))
        .OrderBy(t => t.Date);
        }

        public IEnumerable<TodoItem> GetAllUndone(string email)
        {
            return _context.Todos
        .AsNoTracking()
        .Where(TodoQueries.GetAllUndone(email))
        .OrderBy(t => t.Date);
        }

        public TodoItem GetById(Guid id, string user)
        {
            return _context.Todos
        .AsNoTracking().
        FirstOrDefault(x => x.Id == id && x.User == user);
        }

        public IEnumerable<TodoItem> GetByPeriod(string email, DateTime date, bool done)
        {
                  return _context.Todos
        .AsNoTracking()
        .Where(TodoQueries.GetAllByPeriod(email, date, done))
        .OrderBy(t => t.Date);
        }

        public void Update(TodoItem todoItem)
        {
            _context.Entry(todoItem).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }

}