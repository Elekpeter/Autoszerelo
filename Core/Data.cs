using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Data
    {
        public string UserName { get; set; }
        public string Type { get; set; }
        public string LicensePlate { get; set; }
        public string Problem  { get; set; }
        public DateTime Date { get; private set; }

        public Data()
        {
            Date = DateTime.Now;
        }

        public Data(string userName, string type, string licensePlate, string problem)
        {
            UserName = userName;
            Type = type;
            LicensePlate = licensePlate;
            Problem = problem;
            Date = DateTime.Now;
        }
    }
}
