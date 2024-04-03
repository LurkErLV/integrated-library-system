using System;
using System.Collections.Generic;

namespace integrated_library_system
{
    public class User
    {
        public Guid id = Guid.NewGuid();
        public string name;
        private string surname;
        private string password;
        public List<Book> takedBooks = new List<Book>();
        public Role role;
        
        public User(string name, string surname, string password, Role role)
        {
            this.name = name;
            this.surname = surname;
            this.password = password;
            this.role = role;
        }

        public bool comparePassword(string password)
        {
            return this.password == password;
        }
    }
}