using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Stretch Goals: Using Generics, which would include implementing GetType() http://msdn.microsoft.com/en-us/library/system.object.gettype(v=vs.110).aspx
namespace SinglyLinkedLists
{
    public class SinglyLinkedListNode : IComparable
    {
        // Used by the visualizer.  Do not change.
        public static List<SinglyLinkedListNode> allNodes = new List<SinglyLinkedListNode>();

        // READ: http://msdn.microsoft.com/en-us/library/aa287786(v=vs.71).aspx
        private SinglyLinkedListNode next;
        public SinglyLinkedListNode Next
        {
            get { return this.next; }
            set { this.Next = value; }
            //    if (this == value)
            //    {
            //        throw new ArgumentException();
            //    }
                
            //    this.next = value;
            //}
        }

        private string stringvalue;
        public string Value
        {
            get { return this.stringvalue; }//or return value?
            set { this.Value = stringvalue; }
        }

        public static bool operator <(SinglyLinkedListNode node1, SinglyLinkedListNode node2)
        {
            // This implementation is provided for your convenience.
            return node1.CompareTo(node2) < 0;
        }

        public static bool operator >(SinglyLinkedListNode node1, SinglyLinkedListNode node2)
        {
            // This implementation is provided for your convenience.
            return node1.CompareTo(node2) > 0;
        }

        public SinglyLinkedListNode()
        {

        }

        public SinglyLinkedListNode(string value)
        {
            this.stringvalue = value;

            // Used by the visualizer:
            allNodes.Add(this);
        }

        // READ: http://msdn.microsoft.com/en-us/library/system.icomparable.compareto.aspx
        public int CompareTo(Object obj)
        {
            SinglyLinkedListNode node = obj as SinglyLinkedListNode;
            return node == null ? 1 : this.Value.CompareTo(node.Value);
        }

        public override bool Equals(object obj)
        {
            return this.CompareTo(obj) == 0;
        }

        public bool IsLast()
        {
            return next == null;
        }

        public override string ToString()
        {
            return Value;//?? or return this.Value?
        }
    }
}
