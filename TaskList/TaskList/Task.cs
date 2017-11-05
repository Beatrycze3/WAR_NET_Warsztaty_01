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

        public string Export()
        {
            string text = $"{Description};{StartTime};";

            if(IsDaily)
            {
                text += "null;t;";
            }
            else
            {
                text += $"{EndTime};n;";
            }

            if(IsImportant)
            {
                text += "t";
            }
            else
            {
                text += "n";
            }
            return text;
        }



    }
}
