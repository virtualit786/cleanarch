using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.TodoAggregate;

namespace Core
{
    public interface ITodoRepository
    {
        Task<Todo> Add(Todo todo);
        Task<Todo> Update(Todo todo);
        Task<bool> Delete(Guid id);
        Task<Todo> Get(Guid id);
        Task<List<Todo>> Search(string term);
        Task<bool> SaveChanges();
    }
}
