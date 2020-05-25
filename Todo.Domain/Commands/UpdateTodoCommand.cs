using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class UpdateTodoCommand : Notifiable, ICommand
    {
        public UpdateTodoCommand(Guid id, string user, string title)
        {
            Id = id;
            User = user;
            Title = title;
        }

        public Guid Id { get; set; }
        public string User { get; set; }
        public string Title { get; set; }
        public void Validate()
        {
         AddNotifications(
            new Contract().Requires().IsNullOrEmpty(Title, "Title", "O Título deve ser informado")
            .IsNullOrEmpty(User, "User", "O User deve ser informado")
            .HasMinLen(Title, 3, "Title", "O Título deve ter no minímo 3 caracteres.")
            );
        }
    }
}