using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList
{
    public class Task
    {
        public string description;
        public DateTime startTime;
        public DateTime? endTime;
        public bool isDaily;
        public bool isImportant;


        public Task(string tekst, DateTime beggining)
        {
            description = tekst;
            startTime = beggining;
        }


    }
}
