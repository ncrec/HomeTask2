using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTask.Domain
{
    public class TodoCategory
    {
        public int TodoItemId { get; set; }
        public TodoItem TodoItem { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
