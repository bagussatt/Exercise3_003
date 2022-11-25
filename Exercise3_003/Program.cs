using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

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
        public void addNote()
        {
            int nim;
            string nm;
            Console.WriteLine("\nEnter the roll number of the student:  ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of the student:  ");
            nm = Console.ReadLine();
            Node newNode = new Node();
            newNode.rollNumber = nim;
            newNode.name = nm;

            //check if the list empty
            if (last == null || nim <= last.rollNumber)
            {
                if ((last != null) && (nim == last.rollNumber))
                {
                    Console.WriteLine("\nDuplicate number not allowed");
                    return;
                }
                newNode.next = last.next;
                last.next = newNode;
                return;
            }
            Node current;
            for (current = last;
                current != null && nim >= current.rollNumber;
                )
            {

                if (nim == current.rollNumber)
                {
                    Console.WriteLine("Duplicate roll numbers not allowed");
                    return;
                }
            }
            /*on the execution of the above for loop, prev and
            * current will point to those nodes
            * between which the new node is to be inserted*/
            newNode.next = current;

            //if the node is to be inserted at the end of the list
            if (current == null)
            {
                newNode.next = null;
                return;
            }
            last.next = newNode;

        }
        public bool listEmpty()
        {
            if (last == null)
                return true;
            else
                return false;
        }
        public void transverse() /*transverse all the nodes of the list*/
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecords in the list are:\n");
                Node currentNode;
                currentNode = last.next;
                while (currentNode != last)
                {
                    Console.Write(currentNode.rollNumber + "      " + 
                        currentNode.name + "\n");
                    currentNode = currentNode.next;
                }
                Console.Write(last.rollNumber + "      " + last.name + "\n");
            }
            
        }
        public void firstnode()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
                Console.WriteLine("\nThe first record in the list is: \n\n" +
                    last.next.rollNumber + "       " + last.next.name);

        }
            public void insertbeginning()
          {
            Node temp = new Node();
            temp.next = last.next;
            last.next = temp;
          }
        static void Main(string[] args)
        {
            CircularList obj = new CircularList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. view all record in the list");
                    Console.WriteLine("2. Search for a record in the list");
                    Console.WriteLine("3. display the first record");
                    Console.WriteLine("4. insert number");
                    Console.WriteLine("5. exit");
                    Console.Write("\n Enter your choice (1-5):  ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.transverse();

                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\n Enter the roll number of the student whose record is to be searched: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nrecord found");
                                    Console.WriteLine("\nRoll Number: " + curr.rollNumber);
                                    Console.WriteLine("\nName :  " + curr.name);
                                }
                            }
                            break ;
                        case '3':
                            {
                                obj.firstnode();
                            }
                            break;
                        case '4':
                            {
                                obj.addNote();
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("invalid option");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    
    }

    
}