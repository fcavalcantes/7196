using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateTodoCommandTests
    {
        
            private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Titulo tareda", DateTime.Now, "Batman");
            
            private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("",DateTime.Now, "");

            public CreateTodoCommandTests()
            {
                _validCommand.Validate();
                _invalidCommand.Validate();
            }
        [TestMethod]
        public void Dado_Comando_Invalido(){
 
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

             [TestMethod]
        public void Dado_Comando_Valido(){
 
            Assert.AreEqual(_validCommand.Valid, true);
        }
        
    }
}