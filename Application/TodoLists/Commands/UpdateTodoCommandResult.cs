using Domain.TodoAggregate;

namespace Application.TodoLists.Commands
{
    public class UpdateTodoCommandResult
    {
        public TodoDto Payload { get; set; }
    }
}