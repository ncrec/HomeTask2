using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace HomeTask.Domain
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }
        public DateTime? DateTime { get; set; }
        public int Importance { get; set; }
        [Required]
        public int Status { get; set; }
        [MaxLength(100)]
        public string Note { get; set; }
        public ICollection<TodoCategory> TodoCategories { get; set; }
    }
}