using System;
using System.Collections.Generic;


namespace Exercise3_003
{
    class Node
    {
        //membuat node untuk circular
        public int rollNumber;
        public string name;
        public Node next;
    }
    class CircularList
    {
        Node last;
        public CircularList()
        {
            last = null;
        }
        public bool search(int rollNo, ref Node previous, ref Node current)
        //Searches for the specified node
        {
            for (previous = current = last.next; current != last; previous = current, current = current.next)
            {
                if (rollNo == current.rollNumber)
                    return true; /*return true if the node is found*/
            }
        }
    
    }

    
}