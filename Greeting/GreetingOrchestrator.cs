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
        private readonly LowerCaseGreeter greeterLC;
        private readonly UpperCaseGreeter greeterUC;

        public GreetingOrchestrator()
        {
            greeterLC = new LowerCaseGreeter();
            greeterUC = new UpperCaseGreeter();
        }

        public string Greet(params string[] names)
        {
            var parsedNames = NamesParser.Parse(names);

            //Default greeting when there are no valid names in the input
            if (parsedNames.Length == 0) return "Hello, my friend.";

            //Lowercase and uppercase names require separate handling
            string[] namesLC = parsedNames.Where(n => !IsNameUppercase(n)).ToArray();
            string[] namesUC = parsedNames.Where(n => IsNameUppercase(n)).ToArray();

            string greetingsLowerCase = greeterLC.Greet(namesLC);
            string greetingsUpperCase = greeterUC.Greet(namesUC, namesLC.Length > 0);

            return greetingsLowerCase + greetingsUpperCase;
        }

        private static bool IsNameUppercase(string name) => name.All(c => char.IsUpper(c));
    }
}
