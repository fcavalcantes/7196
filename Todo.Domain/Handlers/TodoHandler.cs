using System.Collections.Generic;
using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler : Notifiable, 
    IHandler<CreateTodoCommand>, 
    IHandler<UpdateTodoCommand>,
    IHandler<MarkTodoAsDoneCommand>,
    IHandler<MarkTodoAsUndoneCommand>
    {
        private readonly ITodoRepository _todoRepository;

        public TodoHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            command.Validate();

            if(command.Valid)
            {
                return new GenericCommandResult(false, "Operação inválida", command.Notifications);
            }

            var todoItem = new TodoItem(command.Title, command.Date.Date, command.User);
            
            _todoRepository.Create(todoItem);

            return new GenericCommandResult(true, "Tarefa Salva", todoItem);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {            
            command.Validate();

            if(command.Valid)
            {
                return new GenericCommandResult(false, "Operação inválida", command.Notifications);
            }

            var todoItem = _todoRepository.GetById(command.Id, command.User);

            todoItem.UpdateTitle(command.Title);
            
            _todoRepository.Update(todoItem);

            return new GenericCommandResult(true, "Tarefa Salva", todoItem);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            command.Validate();

            if(command.Valid)
            {
                return new GenericCommandResult(false, "Operação inválida", command.Notifications);
            }

            var todoItem = _todoRepository.GetById(command.Id, command.User);

            todoItem.MarkAsDone();
            
            _todoRepository.Update(todoItem);

            return new GenericCommandResult(true, "Tarefa Salva", todoItem);
        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            command.Validate();

            if(command.Valid)
            {
                return new GenericCommandResult(false, "Operação inválida", command.Notifications);
            }

            var todoItem = _todoRepository.GetById(command.Id, command.User);

            todoItem.MarkAsUndone();
            
            _todoRepository.Update(todoItem);

            return new GenericCommandResult(true, "Tarefa Salva", todoItem);
        }
    }
}