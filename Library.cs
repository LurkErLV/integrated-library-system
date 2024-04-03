using System;
using System.Collections.Generic;

namespace integrated_library_system
{
    public class Library
    {
        public string title;
        public int capacity;
        public List<Book> allBooks = new List<Book>();

        public Library(string title, int capacity)
        {
            this.title = title;
            this.capacity = capacity;
        }

        public void ChangeTitle(User user, string newTitle)
        {
            if (user.role != Role.Administrator)
            {
                Console.WriteLine("Permission restricted!");
                return;
            }
            else
            {
                title = newTitle;
            }
        }
        
        public void ChangeCapacity(User user, int newCapacity)
        {
            if (user.role != Role.Administrator)
            {
                Console.WriteLine("Permission restricted!");
                return;
            }
            else
            {
                capacity = newCapacity;
            }
        }
    }
}