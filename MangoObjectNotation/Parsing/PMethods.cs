using System;
using System.Collections.Generic;
using System.Text;

namespace MangoObjectNotation.Parsing
{
    static class PMethods
    {
        public static string[] Tear(string text)
        {
            //Tear string into string[] where each member is one character of string
            //"dog" -> "d","o","g"

            int length = text.Length;
            string[] chars = new string[length];

            for(int i = 0; i < length; i++)
            {
                chars[i] = text.Substring(i, 1);
            }

            return chars;
        }
    }
}
