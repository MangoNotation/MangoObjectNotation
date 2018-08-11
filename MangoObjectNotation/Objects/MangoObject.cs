using System;
using System.Collections.Generic;
using System.Text;

namespace MangoObjectNotation
{
    public class MangoObject : MangoSkeleton
    {
        public MangoSkeleton Parent { get { return parent; } }
        private MangoSkeleton parent;

        public int ObjectStart { get; set; } //finds location in parsed string where object starts
        public int ObjectEnd { get; set; } //finds location in parsed string that object ends
        
        public MangoObject()
        {
            parent = null;
            children = new MangoObject[0];
        }

        public MangoObject(string Name, string Body, MangoSkeleton parent)
        {
            this.Name = Name;
            this.Body = Body;
            this.children = new MangoObject[0];
            SetParent(parent);
        }

        public MangoObject(string Name, string Body)
        {
            this.Name = Name;
            this.Body = Body;
            children = new MangoObject[0];
            parent = null;
        }

        public MangoObject(string Name, string Body, int Start, int End)
        {
            //ideal for making from parsed string;
            this.Name = Name;
            this.Body = Body;
            children = new MangoObject[0];
            parent = null;
            ObjectStart = Start;
            ObjectEnd = End;
        }

        public void SetParent(MangoSkeleton parent)// stops AddChild() and ClearParent() from looping forever
        {
            ClearParent();
            this.parent = parent;
            if(!(parent.HasChild(this)))
                parent.AddChild(this);
        }

        public void ClearParent()
        {
            parent.RemoveChild(this);
            parent = null;
        }
    }
}
