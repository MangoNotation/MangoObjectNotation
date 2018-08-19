using System;
using MangoObjectNotation.Parsing;
using System.IO;

namespace MangoObjectNotation
{
    public class MangoDocument : MangoRoot
    {
        public MangoDocument(string fileLocation)
        {
            string fileText = "";
            using(StreamReader sr = File.OpenText(fileLocation))
            {
                string s = "";
                while((s = sr.ReadLine()) != null)
                {
                    fileText += s;
                }
                children = Parser.Parse(fileText);
            }
        }
    }
}
