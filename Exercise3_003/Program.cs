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
            if (rollNo == last.rollNumber) /* if the node is present at the end*/
                return true;
            else
                return(false); /*return false if the node is not found*/
        }
        public bool listEmpty()
        {
            if (last == null)
                return true;
            else
                return false;
        }
        public void transverse() /*transverse all the nodes of the list*/
    
    }

    
}