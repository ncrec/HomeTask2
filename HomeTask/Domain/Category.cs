using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTask.Domain
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [MaxLength(100)]
        public string CategoryName { get; set; }
        public ICollection<TodoCategory> TodoCategories { get; set; }
    }
}
