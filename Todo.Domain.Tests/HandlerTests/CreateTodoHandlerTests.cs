using System;
using System.Collections.Generic;
using Flunt.Notifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateTodoHandlerTests
    {
        
            private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Titulo tareda", DateTime.Now, "Batman");
            
            private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("",DateTime.Now, "");

             private readonly Handlers.TodoHandler _handler = new TodoHandler(new FakeTodoRepository());

            public CreateTodoHandlerTests()
            {
                _validCommand.Validate();
                _invalidCommand.Validate();
            }
        [TestMethod]
        public void Dado_Comando_Invalido_Deve_Interromper_Execucao(){
  
            var result =  (GenericCommandResult)_handler.Handle(_invalidCommand);
            
            Assert.AreEqual(result.Sucess, true);
        }

             [TestMethod]
        public void Dado_Comando_Valido_Deve_Criar_Tarefa(){
 
            var result =  (GenericCommandResult)_handler.Handle(_validCommand);
           
            Assert.AreEqual(result.Sucess, false);
        }
        
    }
}