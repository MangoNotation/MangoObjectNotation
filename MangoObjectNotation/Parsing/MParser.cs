using System;
using System.Collections.Generic;
using System.Text;

namespace MangoObjectNotation.Parsing
{
    public class MParser
    {
        protected MTemp[] Temps;
        private string[] splitText;
        protected MangoSkeleton BaseParent { get; set; }

        public MParser(MangoSkeleton skeleton)
        {
            BaseParent = skeleton;
        }

        public MParser()
        {
            
        }

        public MangoObject[] Parse(string rawText)
        {
            Temps = TempParse(rawText);
            return null;
        }

        protected MTemp[] TempParse(string rawText)
        {
            splitText = PMethods.Tear(rawText);
            //Split the string into temporary mango objects
            return null;
        }

        protected class MTemp
        {
            public string Name { get; set; }
            public string Body { get; set; }

            private int startName;
            private int endName;
            private int startBody;
            private int endBody;

            private string[] splitText;

            public MTemp(string[] splitText)
            {
                this.splitText = splitText;
            }

            public void setNameStart(int i) => startName = i;
            public void setNameEnd(int i) => endName = i;
            public void setBodyStart(int i) => startBody = i;
            public void setBodyEnd(int i) => endBody = i;

            public MangoObject ToMangoObject()
            {
                return null;
            }

            private string buildString(int start, int end)
            {
                string toReturn = "";
                for(int i = start; i < end; i++)
                {
                    toReturn += splitText[i];
                }
                return toReturn;
            }
        }

    }
}
