using System;
using System.Collections.Generic;
using System.Text;
using MangoObjectNotation.Parsing;

namespace MangoObjectNotation
{
    public class MangoRoot : MangoSkeleton
    {
        public MangoRoot(string rawText)
        {
            children = Parser.Parse(rawText);
        }

        private MParser Parser = new MParser();
    }
}
