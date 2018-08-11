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
            try{
                if (!(child.Parent == this))
                    child.SetParent(this);
            }
            catch(NullReferenceException){
                //child.Parent is null, set parent to this
                child.SetParent(this);
            }
            MangoObject[] children_ = new MangoObject[children.Length + 1];
            children.CopyTo(children_, children.Length);
            children_[children.Length] = child;
            children = children_;
        }

        public void RemoveChild(int index)
        {
            MangoObject[] children_ = new MangoObject[children.Length - 1];
            bool removed = false;

            for(int i = 0; i < children.Length; i++)
            {
                if (i != index && !removed)
                    children_[i] = children[i];
                else if (i == index && !removed)
                    removed = true;
                else
                    children_[i - 1] = children[i];
            }

            children = children_;
        }

        public void RemoveChild(MangoObject child)
        {
            //removes first instance of a child
            MangoObject[] children_ = new MangoObject[children.Length - 1];
            bool removed = false;

            for (int i = 0; i < children.Length; i++)
            {
                if (Children[i] != child && !removed)
                    children_[i] = children[i];
                else if (Children[i] == child && !removed)
                    removed = true;
                else
                    children_[i - 1] = children[i];
            }

            children = children_;
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
