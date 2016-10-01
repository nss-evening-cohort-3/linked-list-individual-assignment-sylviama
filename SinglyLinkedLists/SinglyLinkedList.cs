using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        public SinglyLinkedListNode firstNode { get; set; }
        //public List<SinglyLinkedListNode> list;
        //public object[] objectList;

        public SinglyLinkedList()
        {
            firstNode = null;//sylvia's
            // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        }

        public SinglyLinkedList(string value)//Not valid
        {
            //firstNode = new SinglyLinkedListNode();
            firstNode.Value = value;
        }

        public SinglyLinkedList(string value1, string value2, string value3)
        {
            firstNode = new SinglyLinkedListNode();
            firstNode.Value = value1;
            firstNode.Next.Value = value2;
            firstNode.Next.Next.Value = value3;
        }

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
            //this.firstNode=values;//sylvia's
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]//get is valid, set is not valid
        {
            get
            {
                SinglyLinkedListNode currentNode = firstNode;
                for(int j=0; j<i;j++)
                {
                    currentNode = currentNode.Next;
                }
                return currentNode.Value;
            }//sylvia's
            set {
                SinglyLinkedListNode currentNode = firstNode;
                for (int j = 0; j < i; j++)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Value = value;

                //if (this[i] == value)//here value is not a string value, but a node?
                //{
                //    throw new ArgumentException();
                //}

                //this[i] = value;
            }//sylvia's
        }

        public void AddAfter(string existingValue, string value)
        {
            throw new NotImplementedException();

            //LastNode().Next = LastNode();

        }

        //public SinglyLinkedListNode LastNode()
        //{
        //    //Sylvia's
        //    SinglyLinkedListNode currentNode = firstNode;
        //    while(currentNode !=null)
        //    {
        //        currentNode = currentNode.Next;
        //    }
        //    return currentNode;
        //}

        public void AddFirst(string value)//Not Valid
        {
            //throw new NotImplementedException();
            SinglyLinkedListNode toAdd = new SinglyLinkedListNode();
            toAdd.Value = value;
            toAdd.Next = firstNode;
            //firstNode = toAdd;
        }

        public void AddLast(string value)//Valid
        {
            if (firstNode == null)
            {
                firstNode = new SinglyLinkedListNode(value);
            }
            else
            {
                LastNode().Next = new SinglyLinkedListNode(value);
            }
        }
        

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()//Valid!!
        {
            SinglyLinkedListNode currentNode = firstNode;
            int counter = 0;
            if(currentNode==null)
            {
                return 0;
            }else
            {
                while(currentNode !=null)
                {
                    currentNode = currentNode.Next;
                    counter++;
                }
                return counter;
            }
        }

        public string ElementAt(int index)//Valid!
        {
            SinglyLinkedListNode currentNode = firstNode;
            //Solution 1:
            //for (int i = 0; i < index; i++ ){
            //    if (currentNode.IsLast())
            //    {
            //        throw new ArgumentOutOfRangeException();
            //    }
            //    currentNode = currentNode.Next;
            //}

            //Solution 2:
            //for (int i = 0; i < index; i++ ){
            //    currentNode = (currentNode == null) ? null : currentNode.Next;
            //}

            //Solution 3:
            while (index > 0 && currentNode != null)
            {
                index--;
                currentNode = currentNode.Next;
            }

            if (currentNode == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            return currentNode.Value;
        }

        public string First()//Valid!
        {
            if (firstNode == null)
            {
                return null;
            }
            else
            {
               return firstNode.Value;
            }
        }

        public int IndexOf(string value)//valid!
        {
            int counter = -1;
            int finder = 0;
            SinglyLinkedListNode currentNode = firstNode;

            if (currentNode == null)
            {
                return -1;
            }
            else
            {
                while (currentNode != null)
                {
                    if (currentNode.Value == value)
                    {
                        finder++;
                        counter++;
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.Next;
                        counter++;
                    }
                }
                if (finder == 0)
                {
                    return -1;
                }
                else
                {
                    return counter;
                }
            }
        }

        public bool IsSorted()//Valid!
        {
            //throw new NotImplementedException();
            SinglyLinkedListNode currentNode = firstNode;
            SinglyLinkedListNode countNode = currentNode;
            
            if (currentNode == null)
            {
                return true;
            }
            else
            {
                for(int i=0; currentNode.Next !=null; i++)
                {
                    for (int j = i; currentNode.Next != null; j++)
                    {
                        if (countNode.Value[0] > currentNode.Next.Value[0])
                        {
                            return false;
                        }
                        else
                        {
                            currentNode = currentNode.Next;
                        }
                    }
                    countNode = countNode.Next;
                    currentNode = countNode;
                }
                return true;
            }

        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...

        public string Last()//Valid!
        {
            var lastNode = LastNode();
            return (lastNode == null) ? null : lastNode.Value;
        }

        public SinglyLinkedListNode LastNode()//Valid!
        {
            if (firstNode == null)
            {
                return null;
            }
            SinglyLinkedListNode lastNode = firstNode;
            while (!lastNode.IsLast())
            {
                lastNode = lastNode.Next;
            }
            return lastNode;
        }

        public void Remove(string value)//Not Valid
        {
            //throw new NotImplementedException();
            SinglyLinkedListNode currentNode = firstNode;

            while(currentNode !=null)
            {
                if(currentNode.Value==value)
                {
                    currentNode = currentNode.Next;
                    break;
                }else
                {
                    currentNode = currentNode.Next;
                }
            }
        }

        public void Sort()//not sure, test depends on ToArray
        {
            //throw new NotImplementedException();
            SinglyLinkedList tempList = new SinglyLinkedList();
            string tempMinString=null;
            for (int j = 0; tempList[j] != null; j++)
            {
                for (int i = j+1; tempList[i] !=null; i++)
                {
                    if (tempList[j][0] > tempList[i][0])
                    {
                        tempMinString = tempList[i];
                        tempList[i] = tempList[j];
                        tempList[j] = tempMinString;
                    }
                } 
            }
        }

        public string[] ToArray()//Not Valid
        {
            SinglyLinkedListNode currentNode = firstNode;
            string[] arr = new string[] { };

            if (currentNode == null)
            {
                return arr;
            } else
            {
                for (int i = 0; currentNode.Next!= null; i++)
                {
                    arr[i] = currentNode.Value;
                    currentNode = currentNode.Next;
                }
                return arr;
            }
        }

        public override string ToString()//??sylvia
        {
            SinglyLinkedListNode currentNode = firstNode;
            string result = "{ }";

            if (currentNode==null)
            {
                return result;
            }
            
            for(int i=0; currentNode !=null; i++)
            {
                result = result + ", "+ currentNode.Value;

            }
            return result;
        }
    }
}
