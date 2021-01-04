using System;
using MediatR;

namespace Application.TodoLists.Commands
{
    public class DeleteTodoCommand: IRequest<bool>
    {
        public DeleteTodoCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }

    }
}
