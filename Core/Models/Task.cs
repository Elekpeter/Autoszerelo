using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Type { get; set; }
        public string LicensePlate { get; set; }
        public string Problem { get; set; }
        public DateTime Date { get; private set; }
        public string Status { get; set; }

        public Task()
        {
            Date = DateTime.Now;
            Status = WorkStatus.FelvettMunka;
        }

        public Task(string userName, string type, string licensePlate, string problem)
        {
            UserName = userName;
            Type = type;
            LicensePlate = licensePlate;
            Problem = problem;
            Date = DateTime.Now;
            Status = WorkStatus.FelvettMunka;
        }
    }
}
