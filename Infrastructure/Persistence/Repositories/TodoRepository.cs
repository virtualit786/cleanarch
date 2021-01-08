using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using Domain.TodoAggregate;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        List<Todo> todos = null;
        private readonly EfContext _efContext = null;

        public TodoRepository(EfContext efContext)
        {
            todos = new List<Todo>();
            _efContext = efContext;
        }

        public async Task<Todo> Add(Todo todo)
        {
            //await Task.Delay(100);
            //todos.Add(todo);
            //return todo;
            var entity = await _efContext.Todos.AddAsync(todo);
            return entity.Entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            //await Task.Delay(100);
            //return true;
            var todo = await Get(id);
            if (todo != null)
            {
                _efContext.Todos.Remove(todo);
                return true;
            }
            throw new ArgumentException($"{id} not found Or invalid Id!");
        }

        public async Task<Todo> Get(Guid id)
        {
            //await Task.Delay(100);
            //if (todos.Count > 0)
            //{
            //    return todos[0];
            //}
            //else
            //{
            //    return new Todo { Title = "task title 1", Id = id, Description = "Description of title 1", CreatedOn = new DateTime(), IsDone = false, ModifiedOn = new DateTime() };
            //}
            return await _efContext.Todos.FirstOrDefaultAsync(t => t.Id.Equals(id));
        }

        public Task<List<Todo>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChanges()
        {
            var result = await _efContext.SaveChangesAsync();
            return result > 0;
        }


        public Task<List<Todo>> Search(string term)
        {
            throw new NotImplementedException();
        }

        public async Task<Todo> Update(Todo todo)
        {
            await Task.Delay(100);
            //return todo;
            var entity = _efContext.Todos.Update(todo);
            return entity.Entity;
        }


    }
}
