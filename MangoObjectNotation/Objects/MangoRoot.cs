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
            this.children = Parser.Parse(rawText);
            Parser.Reset();
            Name = "MangoRoot";
            Body = "";
        }

        public MangoRoot()
        {
            Name = "MangoRoot";
            Body = "";
        }

        public void Parse(string rawText)
        {
            this.children = Parser.Parse(rawText);
            Parser.Reset();
        }

        protected readonly MParser Parser = new MParser();
    }
}
