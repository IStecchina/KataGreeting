using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greeting.Greeters;

namespace Greeting
{
    public class GreetingOrchestrator : IGreeting
    {
        public string Greet(params string[] names)
        {
            string[] parsedNames = NamesParser.Parse(names);
            return new BaseGreeter().GreetWithTasks(parsedNames);
        }
    }
}
