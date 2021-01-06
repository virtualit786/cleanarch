using System;
using System.Threading;
using System.Threading.Tasks;
using Application.TodoLists.Queries;
using AutoMapper;
using Core;
using Domain.TodoAggregate;
using MediatR;

namespace Infrastructure.Services.QueryHandlers
{
    public class GetTodoByIdQueryHandler : IRequestHandler<GetTodoByIdQuery, TodoDto>
    {
        private readonly ITodoRepository _todoRepository = null;
        private readonly IMapper _mapper = null;
        public GetTodoByIdQueryHandler(IMapper mapper, ITodoRepository todoRepository)
        {
            _mapper = mapper;
            _todoRepository = todoRepository;
        }

        public async Task<TodoDto> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return _mapper.Map<TodoDto>(await _todoRepository.Get(Guid.Parse(request.Id)));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
