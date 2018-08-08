using System;
using MangoObjectNotation.Parsing;

namespace MangoObjectNotation
{
    public abstract class MangoSkeleton
    {
        public string Name { get; set; }
        public string Body { get; set; }
        public MangoObject[] Children
        {
            get
            {
                return children;
            }
        }
        protected MangoObject[] children;

        public void AddChild(MangoObject child)
        {

        }

        public void RemoveChild(int index)
        {

        }
        public void RemoveChild(MangoObject child)
        {

        }
    }
}
