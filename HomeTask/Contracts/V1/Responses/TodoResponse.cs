using System;
using System.Collections.Generic;

namespace HomeTask.Contracts.V1.Responses
{
    public class TodoResponse
    {
        public int Id { get; set; }
        
        public DateTime? DateTime { get; set; }

        public int Importance { get; set; }
        public int Status { get; set; }
        public string Note { get; set; }

    }
}