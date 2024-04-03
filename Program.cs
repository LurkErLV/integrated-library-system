using System;
using System.Collections.Generic;
using System.Linq;

namespace integrated_library_system
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Library> libraries = new List<Library>(){new Library("Library", 300)};
            List<User> allUsers = new List<User>();

            allUsers.Add(new User("Admin", "Admin", "ad123min", Role.Administrator));
            allUsers.Add(new User("Employee", "Employee", "bib1io", Role.Employee));
            allUsers.Add(new User("User", "User", "u5er", Role.User));
            
            while (true)
            {
                Console.Write("Username: ");
                string username = Console.ReadLine();
                User foundUser = allUsers.Find(user => user.name == username);

                if (foundUser == null)
                {
                    Console.WriteLine("User not found!");
                    continue;
                }

                Console.Write("Password: ");
                string password = Console.ReadLine();

                if (!foundUser.comparePassword(password))
                {
                    Console.WriteLine("Incorrect password!");
                }
                else
                {
                    while (true)
                    {
                        bool exit = false;

                        for (int i = 0; i < libraries.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {libraries[i].title}");
                        }

                        Console.Write("Choose library: ");
                        int choosed = Convert.ToInt32(Console.ReadLine());
                        if (choosed < 0 || choosed > libraries.Count)
                        {
                            Console.WriteLine("Invalid library!");
                            continue;
                        }

                        Library library = libraries[choosed-1];
                        
                            while (!exit)
                            {
                                if (foundUser.role == Role.Administrator)
                                {
                                    Console.WriteLine("1 - Change library title");
                                    Console.WriteLine("2 - Change library capacity");
                                    Console.WriteLine("3 - Display all books");
                                    Console.WriteLine("4 - Display info about library");
                                    Console.WriteLine("5 - Create new library");
                                    Console.WriteLine("6 - Display all libraries");
                                    Console.WriteLine("7 - Add new book");
                                    Console.WriteLine("8 - Delete library");
                                    Console.WriteLine("9 - Delete book");
                                    Console.WriteLine("10 - Exit");

                                    switch (Convert.ToInt32(Console.ReadLine()))
                                    {
                                        case 1:
                                        {
                                            Console.Write("Enter new library title: ");
                                            string newTitle = Console.ReadLine();
                                            library.ChangeTitle(foundUser, newTitle);
                                            break;
                                        }

                                        case 2:
                                        {
                                            Console.Write("Enter new library capacity: ");
                                            int newCapacity = Convert.ToInt32(Console.ReadLine());
                                            library.ChangeCapacity(foundUser, newCapacity);
                                            break;
                                        }

                                        case 3:
                                        {
                                            if (library.allBooks.Count <= 0)
                                            {
                                                Console.WriteLine("Library doesn't have books!");
                                                break;
                                            }

                                            foreach (Book book in library.allBooks)
                                            {
                                                Console.WriteLine("----------------------");
                                                Console.WriteLine($"Book title: {book.title}");
                                                Console.WriteLine($"Book author: {book.author}");
                                                Console.WriteLine($"Pages count: {book.pagesCount}");
                                                Console.WriteLine($"Is available: {book.available}");
                                                Console.WriteLine($"Keeper id: {book.getKeeperId(foundUser)}");
                                                Console.WriteLine("----------------------");
                                            }

                                            break;
                                        }

                                        case 4:
                                        {
                                            Console.WriteLine($"Library title: {library.title}");
                                            Console.WriteLine($"Library capacity: {library.capacity}");
                                            break;
                                        }

                                        case 5:
                                        {
                                            Console.Write("Enter library title: ");
                                            string title = Console.ReadLine();
                                            Console.Write("Enter library capacity: ");
                                            int capacity = Convert.ToInt32(Console.ReadLine());
                                            
                                            libraries.Add(new Library(title, capacity));
                                            break;
                                        }

                                        case 6:
                                        {
                                            foreach (Library loopLibrary in libraries)
                                            {
                                                Console.WriteLine("----------------");
                                                Console.WriteLine($"Title: {loopLibrary.title}");
                                                Console.WriteLine($"Capacity: {loopLibrary.capacity}");
                                                Console.WriteLine("----------------");
                                            }
                                            break;
                                        }

                                        case 7:
                                        {
                                            Console.Write("Enter book title: ");
                                            string title = Console.ReadLine();
                                            Console.Write("Enter pages count: ");
                                            int pagesCount = Convert.ToInt32(Console.ReadLine());
                                            Console.Write("Enter book author: ");
                                            string author = Console.ReadLine();
                                            
                                            library.allBooks.Add(new Book(title, pagesCount, author, true));
                                            break;
                                        }

                                        case 8:
                                        {
                                            for (int i = 0; i < libraries.Count; i++)
                                            {
                                                Console.WriteLine($"{i + 1} - {libraries[i].title}");
                                            }
                                            
                                            Console.Write("Choose which library you want to delete: ");
                                            int index = Convert.ToInt32(Console.ReadLine());
                                            
                                            if (index < 0 || index > libraries.Count)
                                            {
                                                Console.WriteLine("Invalid library!");
                                                break;
                                            }
                                            
                                            libraries.RemoveAt(index - 1);
                                            
                                            for (int i = 0; i < libraries.Count; i++)
                                            {
                                                Console.WriteLine($"{i + 1} - {libraries[i].title}");
                                            }

                                            while (true)
                                            {
                                                Console.Write("Choose library: ");
                                                int newChoosed = Convert.ToInt32(Console.ReadLine());
                                                if (newChoosed < 0 || newChoosed > libraries.Count)
                                                {
                                                    Console.WriteLine("Invalid library!");
                                                    continue;
                                                }

                                                library = libraries[newChoosed - 1];
                                                break;
                                            }
                                            break;
                                        }

                                        case 9:
                                        {
                                            for (int i = 0; i < library.allBooks.Count; i++)
                                            {
                                                Console.WriteLine($"{i + 1} - Title: {library.allBooks[i].title} | Author: {library.allBooks[i].author}");
                                            }
                                            Console.WriteLine("Choose book which you want to delete: ");
                                            int index = Convert.ToInt32(Console.ReadLine());

                                            if (index < 0 || index > library.allBooks.Count)
                                            {
                                                Console.WriteLine("Wrong number!");
                                                break;
                                            }
                                            
                                            library.allBooks.RemoveAt(index);
                                            break;
                                        }

                                        case 10:
                                        {
                                            Console.WriteLine("Bye!");
                                            exit = true;
                                            break;
                                        }
                                        
                                        default: break;
                                    }
                                }
                                else if (foundUser.role == Role.Employee)
                                {
                                    Console.WriteLine("1 - Change library title");
                                    Console.WriteLine("2 - Change library capacity");
                                    Console.WriteLine("3 - Display all books");
                                    Console.WriteLine("4 - Display info about library");
                                    Console.WriteLine("5 - Add new book");
                                    Console.WriteLine("6 - Delete book");
                                    Console.WriteLine("7 - Exit");

                                    switch (Convert.ToInt32(Console.ReadLine()))
                                    {
                                        case 1:
                                        {
                                            Console.Write("Enter new library title: ");
                                            string newTitle = Console.ReadLine();
                                            library.ChangeTitle(foundUser, newTitle);
                                            break;
                                        }

                                        case 2:
                                        {
                                            Console.Write("Enter new library capacity: ");
                                            int newCapacity = Convert.ToInt32(Console.ReadLine());
                                            library.ChangeCapacity(foundUser, newCapacity);
                                            break;
                                        }

                                        case 3:
                                        {
                                            if (library.allBooks.Count <= 0)
                                            {
                                                Console.WriteLine("Library doesn't have books!");
                                                break;
                                            }

                                            foreach (Book book in library.allBooks)
                                            {
                                                Console.WriteLine("----------------------");
                                                Console.WriteLine($"Book title: {book.title}");
                                                Console.WriteLine($"Book author: {book.author}");
                                                Console.WriteLine($"Pages count: {book.pagesCount}");
                                                Console.WriteLine($"Is available: {book.available}");
                                                Console.WriteLine($"Keeper id: {book.getKeeperId(foundUser)}");
                                                Console.WriteLine("----------------------");
                                            }

                                            break;
                                        }

                                        case 4:
                                        {
                                            Console.WriteLine($"Library title: {library.title}");
                                            Console.WriteLine($"Library capacity: {library.capacity}");
                                            break;
                                        }

                                        case 5:
                                        {
                                            Console.Write("Enter book title: ");
                                            string title = Console.ReadLine();
                                            Console.Write("Enter pages count: ");
                                            int pagesCount = Convert.ToInt32(Console.ReadLine());
                                            Console.Write("Enter book author: ");
                                            string author = Console.ReadLine();
                                            
                                            library.allBooks.Add(new Book(title, pagesCount, author, true));
                                            break;
                                        }

                                        case 6:
                                        {
                                            for (int i = 0; i < library.allBooks.Count; i++)
                                            {
                                                Console.WriteLine($"{i + 1} - Title: {library.allBooks[i].title} | Author: {library.allBooks[i].author}");
                                            }
                                            Console.WriteLine("Choose book which you want to delete: ");
                                            int index = Convert.ToInt32(Console.ReadLine());

                                            if (index < 0 || index > library.allBooks.Count)
                                            {
                                                Console.WriteLine("Wrong number!");
                                                break;
                                            }
                                            
                                            library.allBooks.RemoveAt(index);
                                            break;
                                        }

                                        case 7:
                                        {
                                            Console.WriteLine("Bye!");
                                            exit = true;
                                            break;
                                        }
                                        
                                        default: break;
                                    }
                                }
                                else if (foundUser.role == Role.User)
                                {
                                    Console.WriteLine("1 - Display all books");
                                    Console.WriteLine("2 - Display info about library");
                                    Console.WriteLine("3 - Reserve book");
                                    Console.WriteLine("4 - Exit");

                                    switch (Convert.ToInt32(Console.ReadLine()))
                                    {

                                        case 1:
                                        {
                                            if (library.allBooks.Count <= 0)
                                            {
                                                Console.WriteLine("Library doesn't have books!");
                                                break;
                                            }

                                            foreach (Book book in library.allBooks)
                                            {
                                                Console.WriteLine("----------------------");
                                                Console.WriteLine($"Book title: {book.title}");
                                                Console.WriteLine($"Book author: {book.author}");
                                                Console.WriteLine($"Pages count: {book.pagesCount}");
                                                Console.WriteLine($"Is available: {book.available}");
                                                Console.WriteLine($"Keeper id: {book.getKeeperId(foundUser)}");
                                                Console.WriteLine("----------------------");
                                            }

                                            break;
                                        }
                                        
                                        case 2:
                                        {
                                            Console.WriteLine($"Library title: {library.title}");
                                            Console.WriteLine($"Library capacity: {library.capacity}");
                                            break;
                                        }

                                        case 3:
                                        {
                                            for (int i = 0; i < library.allBooks.FindAll(book => book.available == true).Count(); i++)
                                            {
                                                Console.WriteLine($"{i + 1} - Title: {library.allBooks.FindAll(book => book.available == true)[i].title} | Author: {library.allBooks.FindAll(book => book.available == true)[i].author}");
                                            }
                                            
                                            Console.Write("Choose book: ");
                                            int index = Convert.ToInt32(Console.ReadLine());
                                            
                                            library.allBooks.FindAll(book => book.available == true)[index].ReserveBook(foundUser);
                                            break;
                                        }

                                        case 4:
                                        {
                                            Console.WriteLine("Bye!");
                                            exit = true;
                                            break;
                                        }
                                        
                                        default: break;
                                    }
                                }
                            }
                    }

                    break;
                }
            }

        }
    }
}