using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class MarkTodoAsUndoneCommand : Notifiable, ICommand
    {
        public MarkTodoAsUndoneCommand(Guid id, string user)
        {
            Id = id;
            User = user;
        }

        public Guid Id { get; set; }
        public string User { get; set; }
        public void Validate()
        {
            AddNotifications(
        new Contract().IsNullOrEmpty(User, "User", "O User deve ser informado")
        .HasLen(Id.ToString(), 36, "Id", "O Id deve ter no minímo 36 caracteres.")
        );
        }
    }
}