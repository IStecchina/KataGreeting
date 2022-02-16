using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting
{
    public static class NamesParser
    {
        public static string[] Parse(string[] names)
        {
            if (names is null) return Array.Empty<string>();

            var result = new List<string>();
            //Don't add empty names
            void TryAdd(string s)
            {
                if(s.Trim().Length > 0)
                {
                    result.Add(s.Trim());
                }
            }

            foreach (var entry in names)
            {
                if (entry is null)
                {
                    //Skip null entries
                }
                //Multiple names separated by commas
                else if (entry.Contains(",") && !IsDoubleQuoted(entry))
                {
                    var temp = entry.Split(",");
                    foreach (var i in temp)
                    {
                        TryAdd(i);
                    }
                }
                //Double-quoted entries
                else if (IsDoubleQuoted(entry))
                {
                    TryAdd(entry[1..^1]);
                }
                //Entries without commas or double quotes
                else
                {
                    TryAdd(entry);
                }
            }
            return result.ToArray();
        }

        // [""] is a valid double quote, ["] is not
        private static bool IsDoubleQuoted(string s) => s.StartsWith('"') && s.EndsWith('"') && s.Length >= 2;
    }
}
