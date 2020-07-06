using System;
using System.Collections.Generic;

namespace HomeTask.Contracts.V1.Requests
{
    public class CreateTodoRequest
    {
        public DateTime? DateTime { get; set; }

        public int Importance { get; set; }
        public int Status { get; set; }
        public string Note { get; set; }
    }
}