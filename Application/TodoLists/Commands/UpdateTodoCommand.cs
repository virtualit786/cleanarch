using System;
using Domain.TodoAggregate;
using MediatR;

namespace Application.TodoLists.Commands
{
    public class UpdateTodoCommand : IRequest<TodoDto>
    {
        public UpdateTodoCommand(string id, string title, string description, bool isDone)
        {
            Id = id;
            Title = title;
            Description = description;
            IsDone = isDone;
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}