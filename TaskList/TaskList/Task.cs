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

        public Task Import (string text)
        {
            Task importedTask = new Task();
            string[] temp = text.Split(';');

            importedTask.Description = temp[0];
            importedTask.StartTime = Convert.ToDateTime(temp[1]);
            
            if(temp[2]=="null")
            {
                importedTask.EndTime = null;
                importedTask.IsDaily = true;
            }
            else
            {
                importedTask.EndTime = Convert.ToDateTime(temp[2]);
                importedTask.IsDaily = false;
            }

            if (temp[4] == "t")
            {
                importedTask.IsImportant = true;
            }
            else
            {
                importedTask.IsImportant = false;
            }

            return importedTask;
        }



    }
}
