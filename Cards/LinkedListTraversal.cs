using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public static class LinkedListTraversal
    {
        public static int FindFromLast(LinkedList<int> list, int index)
        {
            LinkedListNode<int> node1 = list.First;
            LinkedListNode<int> node2 = list.First;

            for (var i = 0; i < index; i++)
            {
                if (node2 == null)
                {
                    return node1.Value;
                }
                node2 = node2.Next;
            }

            while (node2 != null)
            {
                node1 = node1.Next;
                node2 = node2.Next;
            }

            return node1.Value;
        }

        //I realize that I could have also just used LinkedList<Object> to solve both
        //I felt like that was a bit of a copout, but I don't really get the 'solve for string' addition
        public static string FindFromLast(LinkedList<string> list, int index)
        {
            LinkedListNode<string> node1 = list.First;
            LinkedListNode<string> node2 = list.First;

            for (var i = 0; i < index; i++)
            {
                if (node2 == null)
                {
                    return node1.Value;
                }
                node2 = node2.Next;
            }

            while (node2 != null)
            {
                node1 = node1.Next;
                node2 = node2.Next;
            }

            return node1.Value;
        }
    }
}
