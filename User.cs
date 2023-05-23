using System;
namespace ApiRestParser
{
    public class User
    {
        private string names;
        private string email;
        private Guid id;
        private string phone;

        public User(string names, string email, string phone)
        {
            this.names = names;
            this.email = email;
            this.phone = phone;
            this.id = Guid.NewGuid();
        }

        public string Names
        {
            get { return names; }
            set { names = value; }
        }

        internal static string getNames()
        {
            throw new NotImplementedException();
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        public override string ToString()
        {
            return "User{" +
                "Id=" + Id +
                ", Names='" + Names + '\'' +
                ", Email='" + Email + '\'' +
                ", Phone='" + Phone + '\'' +
                '}';
        }
    }

}


