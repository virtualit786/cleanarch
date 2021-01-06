using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using Domain.TodoAggregate;

namespace Infrastructure.Persistence.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        List<Todo> todos = null;

        public TodoRepository()
        {
            todos = new List<Todo>();
        }

        public async Task<Todo> Add(Todo todo)
        {
            await Task.Delay(100);
            todos.Add(todo);
            return todo;
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Todo> Get(Guid id)
        {
            await Task.Delay(100);
            if (todos.Count > 0)
            {
                return todos[0];
            }
            else
            {
                return new Todo { Title = "task title 1", Id = id, Description = "Description of title 1", CreatedOn = new DateTime(), IsDone = false, ModifiedOn = new DateTime() };
            }
        }

        public Task<List<Todo>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<List<Todo>> Search(string term)
        {
            throw new NotImplementedException();
        }

        public Task<Todo> Update(Todo todo)
        {
            throw new NotImplementedException();
        }
    }
}
