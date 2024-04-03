using System;

namespace integrated_library_system
{
    public class Book
    {
        public string title;
        public int pagesCount;
        public string author;
        public bool available;
        private Guid keeperId;

        public Book(string title, int pagesCount, string author, bool available)
        {
            this.title = title;
            this.pagesCount = pagesCount;
            this.author = author;
            this.available = available;
        }

        public void ReserveBook(User user)
        {
            keeperId = user.id;
        }

        public Guid getKeeperId(User user)
        {
            if (user.role != Role.Administrator)
            {
                Console.WriteLine("Permission restricted!");
                return Guid.Empty;
            }

            return keeperId;
        }
    }
}