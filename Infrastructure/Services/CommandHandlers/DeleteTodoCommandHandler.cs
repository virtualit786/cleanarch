using System;
using System.Threading;
using System.Threading.Tasks;
using Application.TodoLists.Commands;
using AutoMapper;
using Core;
using MediatR;

namespace Infrastructure.Services.CommandHandlers
{
    public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand, DeleteTodoCommandResult>
    {
        private readonly IMapper _mapper = null;
        private readonly ITodoRepository _todoRepository = null;

        public DeleteTodoCommandHandler(IMapper mapper, ITodoRepository taskRepository)
        {
            _mapper = mapper;
            _todoRepository = taskRepository;
        }

        public async Task<DeleteTodoCommandResult> Handle(DeleteTodoCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _todoRepository.Delete(command.Id);
                return new DeleteTodoCommandResult()
                {
                    IsSuccess = result
                };
            }
            catch (ArgumentException)
            {

                throw;
            }
        }
    }
}
