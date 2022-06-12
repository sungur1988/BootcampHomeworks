using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MessageLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine( "Log to text");
        }
    }
    public class DbLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Log to db");
        }
    }
    public class LogManager
    {
        Type[] assembly = Assembly.GetExecutingAssembly().GetTypes();
        List<ILogger> loggers = new List<ILogger> ();
    }

}
