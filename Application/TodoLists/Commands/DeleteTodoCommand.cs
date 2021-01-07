using System;
using MediatR;

namespace Application.TodoLists.Commands
{
    public class DeleteTodoCommand: IRequest<DeleteTodoCommandResult>
    {
        public DeleteTodoCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }

    }
}
