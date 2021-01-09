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
    public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, UpdateTodoCommandResult>
    {
        private readonly ITodoRepository _todoRepository = null;
        private readonly IMapper _mapper = null;

        public UpdateTodoCommandHandler(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        public async Task<UpdateTodoCommandResult> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var todo = _mapper.Map<Todo>(request);
                var entity = await _todoRepository.Update(todo);
                await _todoRepository.SaveChanges();
                if (entity != null)
                {
                    return new UpdateTodoCommandResult()
                    {
                        Payload = _mapper.Map<TodoDto>(entity)
                    };
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }
    }
}
