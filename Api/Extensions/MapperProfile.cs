using System;
using Application.TodoLists.Commands;
using Domain.TodoAggregate;

namespace Api.Extensions
{
    public class MapperProfile : AutoMapper.Profile
    {
        public MapperProfile()
        {
            CreateMap<Todo, TodoDto>()
              .ForMember(x => x.Id, v => v.MapFrom(z => z.Id.ToString()));
            CreateMap<TodoDto, Todo>()
              .ForMember(x => x.Id, v => v.MapFrom(z => Guid.Parse(z.Id)));

            CreateMap<CreateTodoCommand, Todo>();
            CreateMap<Todo, CreateTodoCommand>();

            CreateMap<UpdateTodoCommand, Todo>();
            CreateMap<Todo, UpdateTodoCommand>();

        }
    }
}