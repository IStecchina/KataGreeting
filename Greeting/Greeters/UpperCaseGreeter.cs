﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting.Greeters
{
    public class UpperCaseGreeter
    {
        private readonly StringBuilder sbUppercaseNames = new StringBuilder();

        public string Greet(string[] namesUC, bool isFirstGreeter)
        {
            sbUppercaseNames.Clear();
            if (namesUC.Length > 0)
            {
                //If there were no lowercase names, first greeting is different
                if (isFirstGreeter)
                {
                    sbUppercaseNames.Append(GreetUpperCaseName(namesUC[0], false));
                }
                else
                {
                    sbUppercaseNames.Append(GreetUpperCaseName(namesUC[0], true));
                }
                foreach (string name in namesUC[1..])
                {
                    sbUppercaseNames.Append(GreetUpperCaseName(name, false));
                }
            }
            return sbUppercaseNames.ToString();
        }

        public static Task<string> GreetTask(string[] namesUC, bool isFirstGreeter)
        {
            return Task<string>.Factory.StartNew(() =>
            {
                var sbAsync = new StringBuilder();
                if (namesUC.Length > 0)
                {
                    //If there were no lowercase names, first greeting is different
                    if (isFirstGreeter)
                    {
                        sbAsync.Append(GreetUpperCaseName(namesUC[0], false));
                    }
                    else
                    {
                        sbAsync.Append(GreetUpperCaseName(namesUC[0], true));
                    }
                    foreach (string name in namesUC[1..])
                    {
                        sbAsync.Append(GreetUpperCaseName(name, false));
                    }
                }
                return sbAsync.ToString();
            }
            );
        }

        //Uppercase names require special handling when they're the first greeting
        private static string GreetUpperCaseName(string name, bool isFirstGreeting) => isFirstGreeting ? $"HELLO {name}!" : $" AND HELLO {name}!";

    }
}
