using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting.Greeters
{
    public class BaseGreeter
    {
        private readonly LowerCaseGreeter greeterLC;
        private readonly UpperCaseGreeter greeterUC;

        public BaseGreeter()
        {
            greeterLC = new LowerCaseGreeter();
            greeterUC = new UpperCaseGreeter();
        }

        public string GreetWithTasks(string[] parsedNames)
        {
            //Default greeting when there are no valid names in the input
            if (parsedNames.Length == 0) return "Hello, my friend.";

            //Lowercase and uppercase names require separate handling
            string[] namesLC = parsedNames.Where(n => !IsNameUppercase(n)).ToArray();
            string[] namesUC = parsedNames.Where(n => IsNameUppercase(n)).ToArray();

            var taskLowerCase = LowerCaseGreeter.GreetTask(namesLC);
            var taskUpperCase = UpperCaseGreeter.GreetTask(namesUC, namesLC.Length > 0);

            Task.WaitAll(taskLowerCase, taskUpperCase);
            return $"{taskLowerCase.Result}{taskUpperCase.Result}";
        }

        public string GreetWithoutTasks(string[] parsedNames)
        {
            //Default greeting when there are no valid names in the input
            if (parsedNames.Length == 0) return "Hello, my friend.";

            //Lowercase and uppercase names require separate handling
            string[] namesLC = parsedNames.Where(n => !IsNameUppercase(n)).ToArray();
            string[] namesUC = parsedNames.Where(n => IsNameUppercase(n)).ToArray();

            string greetingsLowerCase = greeterLC.Greet(namesLC);
            string greetingsUpperCase = greeterUC.Greet(namesUC, namesLC.Length > 0);

            return $"{greetingsLowerCase}{greetingsUpperCase}";
        }

        private static bool IsNameUppercase(string name) => name.All(c => char.IsUpper(c));
    }
}
