using System;
using Domain.TodoAggregate;

namespace Application.TodoLists.Commands
{
    public class CreateTodoCommandResult
    {
        public TodoDto Payload { get; set; }
    }
}
