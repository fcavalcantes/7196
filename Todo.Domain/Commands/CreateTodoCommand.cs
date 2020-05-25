

using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class CreateTodoCommand: Notifiable, ICommand
    {
        public CreateTodoCommand(string title, DateTime date, string user)
        {
            Title = title;
            Date = date;
            User = user;
        }

        public string Title { get;  set; }
        public DateTime Date { get;  set; }
        public string User { get;  set; }

        public void Validate()
        {
            AddNotifications(
            new Contract().Requires().IsNotNullOrEmpty(Title, "Title", "O Título deve ser informado")
            .IsNotNullOrEmpty(User, "User", "O User deve ser informado")
            .HasMinLen(Title, 3, "Title", "O Título deve ter no minímo 3 caracteres.")
            );
        }
    }
}