using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList
{
    public class Task
    {
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool IsDaily { get; set; }
        public bool IsImportant { get; set; }

        


    }
}
