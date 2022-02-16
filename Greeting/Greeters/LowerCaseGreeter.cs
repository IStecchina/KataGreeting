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
                foreach (string name in namesLC[..^1])
                {
                    sbLowercaseNames.Append($", {name}");
                }
                //Last name handling
                sbLowercaseNames.Append(GreetLastLowerCaseName(namesLC[^1], namesLC.Length));
            }
            return sbLowercaseNames.ToString();
        }

        public static Task<string> GreetTask(string[] namesLC)
        {
            return Task<string>.Factory.StartNew(() =>
            {
                var sbAsync = new StringBuilder();
                if (namesLC.Length > 0)
                {
                    sbAsync.Append("Hello");
                    foreach (string name in namesLC[..^1])
                    {
                        sbAsync.Append($", {name}");
                    }
                    //Last name handling
                    sbAsync.Append(GreetLastLowerCaseName(namesLC[^1], namesLC.Length));
                }
                return sbAsync.ToString();
            }
            );
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
