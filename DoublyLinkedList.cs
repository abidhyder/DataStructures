// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        LinkedList list = new LinkedList();
        
        // Adding nodes to the linked list
        list.AddNext(1);
        list.AddNext(2);
        list.AddNext(3);
        
        // Printing the current list
        list.PrintList();
        
        // Removing a node (value 1)
        list.Remove(1);
        
        // Printing the list after removal
        list.PrintList();
    }
}

// Class representing a doubly linked list
public class LinkedList
{
    Node head; // Head node of the linked list
    
    // Method to remove a node with a given value
    public void Remove(int data)
    {
        // If the head node contains the data to be removed
        if (head.Data == data)
        {
            if (head.Next != null)
            {
                head = head.Next; // Move head to next node
                head.Prev = null; // Remove backward link
                return;
            }
            head = null; // If there was only one node, set head to null
            return;
        }
        
        Node current = head;
        
        // Traverse the list to find the node to remove
        while (current.Next != null)
        {
            if (current.Next.Data == data)
            {
                current.Next = current.Next.Next; // Skip the node to be removed
                
                if (current.Next != null) // If the next node exists, update its Prev pointer
                {
                    current.Next.Prev = current;
                }
                return;
            }
            current = current.Next; // Move to next node
        }
        
        // If the node to remove is the last node (tail node)
        if (current.Data == data && current.Prev != null)
        {
            current.Prev.Next = null; // Remove reference to current node
        }
    }
    
    // Method to add a node at the end of the list
    public void AddNext(int data)
    {
        Node node = new Node(data);
        
        // If the list is empty, set the new node as head
        if (head == null)
        {
            head = node;
            return;
        }
        
        Node current = head;
        Node prev = head;
        
        // Traverse to the end of the list
        while (current.Next != null)
        {
            prev = current;
            current = current.Next;
        }
        
        // Add new node at the end
        current.Next = node;
        current.Prev = prev;
    }
    
    // Method to print the linked list
    public void PrintList()
    {
        Node current = head;
        
        // Traverse the list and print each node's data
        while (current != null)
        {
            Console.Write(current.Data + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }
}

// Class representing a node in the doubly linked list
public class Node
{
    public int Data; // Data of the node
    public Node Next; // Reference to the next node
    public Node Prev; // Reference to the previous node
    
    // Constructor to initialize node with data
    public Node(int data)
    {
        Data = data;
    }
}
