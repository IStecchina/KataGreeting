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
                if (s.Trim().Length > 0)
                {
                    result.Add(s.Trim());
                }
            }

            foreach (var entry in names)
            {
                //Skip null entries
                if (entry is null)
                {
                    continue;
                }
                //Double-quoted entries
                if (IsDoubleQuoted(entry))
                {
                    TryAdd(entry[1..^1]);
                }
                //Multiple names separated by commas
                else if (entry.Contains(","))
                {
                    var temp = entry.Split(",");
                    foreach (var i in temp)
                    {
                        TryAdd(i);
                    }
                }
                //Entries without commas or double quotes
                else
                {
                    TryAdd(entry);
                }
            }
            return result.ToArray();
        }

        // [""] is a valid double quote, ["] is not, ["a,b",c] is not
        private static bool IsDoubleQuoted(string s) => s.StartsWith('"') && s.EndsWith('"') && s.Length >= 2;
    }
}
