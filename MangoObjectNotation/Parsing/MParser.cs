using System;
using System.Collections.Generic;
using System.Text;

namespace MangoObjectNotation.Parsing
{
    public class MParser
    {
        private MTemp[] Temps;
        private string[] splitText;
        protected MangoSkeleton BaseParent = new MangoRoot();


        public MParser()
        {
            
        }

        public MangoObject[] Parse(string rawText)
        {
            Temps = TempParse(rawText);
            MangoObject[] objects = new MangoObject[Temps.Length];
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i] = Temps[i].ToMangoObject();
            }
            Sort(objects);
            return BaseParent.Children;
        }

        private MTemp[] TempParse(string rawText)
        {
            splitText = PMethods.Tear(rawText);
            List < MTemp >  temps = new List<MTemp>();
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
                            {
                                temp.setBodyEnd(bodyTextEnd);
                                temps.Add(temp);
                            }

                            break;
                        }
                        else if (bodyStart == (splitText.Length - 1))
                            throw new IncompleteMangoDefException();
                    }
                    //implement find body end
                    if(!temp.Imp())
                    {
                        int offset = 0;
                        for (bodyEnd = bodyTextEnd + 1; bodyEnd < splitText.Length; bodyEnd++)
                        {
                            if (splitText[bodyEnd] == "[")
                                offset++;
                            if (splitText[bodyEnd] == "}")
                                bodyEnd--;
                            if (offset == -1){
                                temp.setBodyEnd(bodyEnd);
                                temps.Add(temp);
                                break;
                            }
                            if (bodyEnd == splitText.Length - 1)
                                throw new IncompleteMangoDefException();
                        }
                    }
                }
            }
            return temps.ToArray();
        }

        private void Sort(MangoObject[] objects)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                MangoObject current = objects[i];
                MangoObject parent_ = null;
                int pRange; //parent range
                int rRange; //rival parent range
                for (int c = 0; c < objects.Length; c++)
                {
                    if (!(current == objects[c]))
                    {
                        try
                        {
                            pRange = parent_.ObjectEnd - parent_.ObjectStart;
                            rRange = objects[c].ObjectEnd - objects[c].ObjectStart;
                            if (!(parent_ == null))
                            {
                                if (parent_.ObjectStart > objects[c].ObjectStart && parent_.ObjectEnd < objects[c].ObjectEnd && rRange < pRange)
                                {
                                    parent_ = objects[c];
                                }
                            }
                            else
                                throw new NullReferenceException();

                        }
                        catch (NullReferenceException)
                        {
                            //parent is null
                            if (parent_.ObjectStart > objects[c].ObjectStart && parent_.ObjectEnd < objects[c].ObjectEnd)
                                parent_ = objects[c];
                        }
                    }
                    if (current.Parent == null)
                        current.SetParent(BaseParent);
                    else
                        current.SetParent(parent_);
                }
            }
        }

        public void Reset()
        {
            BaseParent = null;
            BaseParent = new MangoRoot();
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
                return new MangoObject(buildString(startName +1, endName-1), buildString(startBody+1, endBodyText-1), startName, endBody);
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

            public bool Imp() //short for implemented
            {
                return (endBodyText > 0 && endBodyText == endBody);
            }
        }

    }
}
