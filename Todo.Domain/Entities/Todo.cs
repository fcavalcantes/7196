using System;

namespace Todo.Domain.Entities
{
    public  class TodoItem:Entity
    {
       

        public TodoItem(string title, DateTime date, string user)
        {
            Title = title;
            Date = date;
            Done = false;
            User = user;
        }

        public string Title { get; private set; }
        public DateTime Date { get; private set; }
        public bool Done { get; private set; }        
        public string User { get; private set; }

        public void MarkAsDone()
        {
            Done =  false;
        }

        public void UpdateTitle(string title)
        {
            Title = title;
        }
        public void MarkAsUndone()
        {
            Done =  true;
        }

    }
}
