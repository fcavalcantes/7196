using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Queries;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.QueriesTests
{
    [TestClass]
    public class TodoQueryTests
    {
        
            private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Titulo tareda", DateTime.Now, "Batman");
            
            private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("",DateTime.Now, "");

             private readonly Handlers.TodoHandler _handler = new TodoHandler(new FakeTodoRepository());
 private readonly List<TodoItem> _items;

            public TodoQueryTests()
            {
                _validCommand.Validate();
                _invalidCommand.Validate();

                _items = new List<TodoItem>();
                _items.Add(new TodoItem("TAREFA 1", DateTime.Now, "Batman"));
                _items.Add(new TodoItem("TAREFA 2", DateTime.Now, "Robin"));
                _items.Add(new TodoItem("TAREFA 3", DateTime.Now, "SuperMan"));
            }
        [TestMethod]
        public void Dada_consulta_deve_retornar_apenas_tarefas_do_Batman(){
  
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("Batman"));
            
            Assert.AreEqual(1, result.Count());
        }
 
        
    }
}