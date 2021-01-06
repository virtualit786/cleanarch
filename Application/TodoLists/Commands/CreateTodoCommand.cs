using System;
using Domain.TodoAggregate;
using MediatR;

namespace Application.TodoLists.Commands
{
    public class CreateTodoCommand : IRequest<CreateTodoCommandResult>
    {
        public CreateTodoCommand(string title, string description, bool isDone)
        {
            Title = title;
            Description = description;
            IsDone = isDone;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }

}
