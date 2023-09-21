using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
    public static class Settings
    {
        public static  string numElevators = ConfigurationManager.AppSettings["numElevators"];
        public static string maxCapacity = ConfigurationManager.AppSettings["maxCapacity"];

    }
}
