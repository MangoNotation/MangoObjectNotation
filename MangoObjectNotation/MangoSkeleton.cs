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
            if(!(child.Parent == this))
                child.SetParent(this);
            MangoObject[] new_list = new MangoObject[children.Length + 1];
            children.CopyTo(new_list, children.Length);
            new_list[children.Length] = child;
            children = new_list;
        }

        public void RemoveChild(int index)
        {
            MangoObject[] new_list = new MangoObject[children.Length - 2];
            bool removed = false;

            for(int i = 0; i < children.Length; i++)
            {
                if (i != index && !removed)
                    new_list[i] = children[i];
                else if (i == index && !removed)
                    removed = true;
                else
                    new_list[i - 1] = children[i];
            }

            children = new_list;
        }

        public void RemoveChild(MangoObject child)
        {

        }

        public bool HasChild(MangoObject child)
        {
            for (int i = 0; i < Children.Length; i++)
                if (Children[i] == child)
                    return true;
            return false;
        }
    }
}
