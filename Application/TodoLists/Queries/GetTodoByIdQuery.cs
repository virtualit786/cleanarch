using System;
using Domain.TodoAggregate;
using MediatR;

namespace Application.TodoLists.Queries
{
    public class GetTodoByIdQuery : IRequest<TodoDto>
    {
        public GetTodoByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
