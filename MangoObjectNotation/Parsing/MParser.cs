using System;
using System.Collections.Generic;
using System.Text;

namespace MangoObjectNotation.Parsing
{
    public class MParser
    {
        private MTemp[] Temps;
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

        private MTemp[] TempParse(string rawText)
        {
            splitText = PMethods.Tear(rawText);
            //Split the string into temporary mango objects

            for (int i = 0; i < splitText.Length; i++)
            {
                //Test for opening square bracket, signifies start of object
                if (splitText[i] == "[")
                {
                    //declare new temp
                    MTemp temp = new MTemp(splitText, i);

                    int nameEnd;
                    int bodyStart;
                    int bodyTextEnd;
                    int bodyEnd;
                    for (nameEnd = (i + 1); nameEnd < splitText.Length; nameEnd++)
                    {
                        if (splitText[nameEnd] == "]")
                        {
                            temp.setNameEnd(nameEnd);
                            break;
                        }
                        //object name has no end, throw exception
                        else if (nameEnd == (splitText.Length - 1))
                            throw new IncompleteMangoDefException();
                    }
                    for (bodyStart = (nameEnd + 1); bodyStart < splitText.Length; bodyStart++)
                    {
                        if (splitText[bodyStart] == "{")
                        {
                            temp.setBodyStart(bodyStart);
                            break;
                        }
                        else if (bodyStart == (splitText.Length - 1))
                            throw new IncompleteMangoDefException();
                    }
                    for (bodyTextEnd = (bodyStart + 1); bodyTextEnd < splitText.Length; bodyTextEnd++)
                    {
                        if ((splitText[bodyTextEnd] == "}") || (splitText[bodyTextEnd] == "["))
                        {
                            temp.setBodyTextEnd(bodyTextEnd);
                            if (splitText[bodyTextEnd] == "}")
                                temp.setBodyEnd(bodyTextEnd);
                            break;
                        }
                        else if (bodyStart == (splitText.Length - 1))
                            throw new IncompleteMangoDefException();
                    }
                    //implement find body end

                }
            }
            return null;
        }

        private class MTemp
        {
            public string Name { get; set; }
            public string Body { get; set; }

            private int startName;
            private int endName;
            private int startBody;
            private int endBodyText;
            private int endBody;

            private string[] splitText;

            public MTemp(string[] splitText, int nameStart)
            {
                this.splitText = splitText;
                setNameStart(nameStart);
            }

            public void setNameStart(int i) => startName = i;
            public void setNameEnd(int i) => endName = i;
            public void setBodyStart(int i) => startBody = i;
            public void setBodyEnd(int i) => endBody = i;
            public void setBodyTextEnd(int i) => endBodyText = i;

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
