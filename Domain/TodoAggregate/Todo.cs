using System;
namespace Domain.TodoAggregate
{
    public class Todo : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}
