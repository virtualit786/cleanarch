using System;
using MediatR;

namespace Application.TodoLists.Commands
{
    public class DeleteTodoCommandResult
    {
        public bool IsSuccess { get; set; }

    }
}
