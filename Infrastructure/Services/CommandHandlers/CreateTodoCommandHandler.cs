using System;
using System.Threading;
using System.Threading.Tasks;
using Application.TodoLists.Commands;
using AutoMapper;
using Core;
using Domain.TodoAggregate;
using MediatR;

namespace Infrastructure.Services.CommandHandlers
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, CreateTodoCommandResult>
    {
        private readonly ITodoRepository _todoRepository = null;
        private readonly IMapper _mapper = null;

        public CreateTodoCommandHandler(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        public async Task<CreateTodoCommandResult> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = _mapper.Map<Todo>(request);
            var entity = await _todoRepository.Add(todo);
            //await _todoRepository.SaveChanges();
            //return _mapper.Map<TodoDto>(entity);
            return new CreateTodoCommandResult()
            {
                Payload = _mapper.Map<TodoDto>(entity)
            };
        }

    }
}
