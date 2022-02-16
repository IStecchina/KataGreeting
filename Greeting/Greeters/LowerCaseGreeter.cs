using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting.Greeters
{
    public class LowerCaseGreeter
    {
        private readonly StringBuilder sbLowercaseNames = new StringBuilder();

        public string Greet(string[] namesLC)
        {
            sbLowercaseNames.Clear();
            if (namesLC.Length > 0)
            {
                sbLowercaseNames.Append("Hello");
                for (int i = 0; i < namesLC.Length - 1; i++)
                {
                    sbLowercaseNames.Append($", {namesLC[i]}");
                }
                //Last name handling
                sbLowercaseNames.Append(GreetLastLowerCaseName(namesLC[^1], namesLC.Length));
            }
            return sbLowercaseNames.ToString();
        }

        //The last lowercase name is handled differently depending on how many other lowercase names there are
        private static string GreetLastLowerCaseName(string lastName, int numLowercaseNames)
        {
            return numLowercaseNames switch
            {
                0 => throw new Exception("Good job, you broke it."),
                1 => $", {lastName}.",      //Hello, 1
                2 => $" and {lastName}.",   //Hello, 1 and 2
                _ => $", and {lastName}.",  //Hello, 1, 2, and 3
            };
        }

    }
}
