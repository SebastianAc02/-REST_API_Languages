using System;
using System.Collections.Generic;


namespace ApiRestParser
{
    public class Service : IService
    {
        public static List<User> UserList = new List<User>();


        public void Create(string body)
        {
            string[] data = body.Split(",");


            User newUser = new User(data[0], data[1], data[2]);

            UserList.Add(newUser);

            string response = "Se ha creado el usuario con exito y sus datos son:\n" + "Id: " + newUser.Id + ", " + " Nombres: " + newUser.Names + ", " +
                "Email: " + newUser.Email + ", " + "Teléfono: " + newUser.Phone;

            Console.WriteLine(response);

        }

        public List<User> ReadAll()
        {

            PrintUsers(UserList);
            return UserList;
            
        }

        public void UpdateById(string body, string id)
        {
            Guid guidValue;
            if (!Guid.TryParse(id, out guidValue))
            {
                Console.WriteLine("Formato erroneo en el id ");
                return;
            }
            User userFound = null;
            foreach (User user in UserList)
            {
                 
                if (user.Id == guidValue)
                {


                    string[] data = body.Split(",");
                    user.Names = data[0];
                    user.Email = data[1];
                    user.Phone = data[2];
                    userFound = user;
                    break;
                }
            }

            if (userFound != null )
            {
                Console.WriteLine("Se ha actualizado el usuario con éxito y sus datos son:\n" +
                    $"Id: {id}, Nombres: {userFound.Names}, Email: {userFound.Email}, Teléfono: {userFound.Phone}");
            }


            else
            {
                Console.WriteLine("No se ha encontrado el usuario con el id: " + id);
            }
        }


        public void DeleteById(string  id)
        {
            Guid guidValue;
            if (!Guid.TryParse(id, out guidValue))
            {
                Console.WriteLine("Formato erroneo en el id ");
                return;
            }
            UserList.RemoveAll(p => p.Id == guidValue);

            PrintUsers(UserList);

        }



        public void FindById(string  id)
        {
            Guid guidValue;
            if(!Guid.TryParse(id, out guidValue))
            {
                Console.WriteLine("Formato erroneo en el id ");
                return;
            }

            User userEncontrado = UserList.Find(u => u.Id == guidValue);

            if (userEncontrado != null)
            {
                Console.WriteLine($"Se ha encontrado el usuario con id : {userEncontrado.Id}");
                Console.WriteLine("{" + $"Nombre: {userEncontrado.Names} Email : {userEncontrado.Email} Telefono : {userEncontrado.Phone}" + "}");
            }
            else
            {
                Console.WriteLine("Non se encontro el usuario");
            }

        }

        static void PrintUsers(List<User> users)
        {
            Console.WriteLine("Lista de usuarios:");
            foreach (User user in users)
            {
                Console.WriteLine($"\n{{\n\t\"id\": {user.Id},\n\t\"nombres\": \"{user.Names}\",\n\t\"email\": \"{user.Email}\",\n\t\"phone\": \"{user.Phone}\"\n\t\t\t\t\t}},");
            }
        }

    }
}
