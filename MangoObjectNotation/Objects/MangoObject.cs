using System;
using System.Collections.Generic;
using System.Text;

namespace MangoObjectNotation
{
    public class MangoObject : MangoSkeleton
    {
        public MangoSkeleton Parent { get { return parent; } }
        private MangoSkeleton parent;

        public string RootID { get; set; } //sets id number for object (within given root)
        
        public MangoObject()
        {
            parent = null;
            children = new MangoObject[0];
        }

        public MangoObject(string Name, string Body, MangoObject Parent)
        {
            this.Name = Name;
            this.Body = Body;
            this.parent = Parent;
        }

        public void setParent()
        {

        }

        public MangoObject(string rawText)
        {

        }
    }
}
