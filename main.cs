using System;

namespace ApiRestParser
{
    class main
    {

        static public Controller controladora = new Controller();
        static  public string  URL = "http://localhost:8080/api/users";
        static public string version = "HTTP/1.1";
        static public string headers = "Content-Type: application/json";




        static void Main(string[] args)
        {
            Console.WriteLine("Starting proyect");
           WriteMenu();

        }


        static void WriteMenu()
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("----- MENÚ -----");
                Console.WriteLine("1. Método GET de todos los usuarios");
                Console.WriteLine("2. Método POST de un usuario");
                Console.WriteLine("3. Método GET de un usuario por ID");
                Console.WriteLine("4. Método PUT de usuarios (edición)");
                Console.WriteLine("5. Método DELETE de un usuario por ID");
                Console.WriteLine("6. Salir");
                Console.WriteLine("-----------------");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();
                //string method, string URL, string verstionProtocol, string headers, string body
                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Opción seleccionada: Método GET de todos los usuarios");

                        
                        

                        
                        
                        controladora.ControllerReq("GET", URL, version, headers , "");
                        controladora.cleanParams();

                        break;

                    case "2":
                        Console.WriteLine("Opción seleccionada: Método POST de un usuario");

                        Console.Write("Ingrese el nombre,  email y el número de teléfono (separados por comas): ");
                        string inputUsuario = Console.ReadLine();
                        inputUsuario = inputUsuario.Trim();
                        // Verificar el formato del input del usuario
                        string[] valores = inputUsuario.Split(',');
                        if (valores.Length != 3)
                        {
                            Console.WriteLine("El formato del input es incorrecto. Debe ser 'email, número de teléfono'.");
                            break;
                        }

                        controladora.ControllerReq("POST", URL, version, headers, inputUsuario);
                        controladora.cleanParams();

                        break;
                    case "3":

                        Console.WriteLine("Opción seleccionada: Método GET de un usuario por ID");


                        Console.WriteLine("Ingrese el id del usuario ");
                        string inputUsuario2 = Console.ReadLine();
                        inputUsuario2 = inputUsuario2.Trim();

                        controladora.ControllerReq("GET", URL+"/"+inputUsuario2, version, headers, inputUsuario2, (inputUsuario2));
                        controladora.cleanParams();


                        break;
                    case "4":
                        Console.WriteLine("Opción seleccionada: Método PUT de usuarios (edición)");

                        Console.WriteLine("Ingrese el id del usuario ");
                        string inputusuarioPut = Console.ReadLine();
                        inputusuarioPut = inputusuarioPut.Trim();

                        Console.WriteLine("Ingrese los campos a editar (nombre, email y tel) delimitando con una coma (,) ");
                        string inputusuarioPutBody = Console.ReadLine();
                        inputusuarioPutBody = inputusuarioPutBody.Trim();


                        controladora.ControllerReq("PUT", URL+"/"+inputusuarioPut, version, headers, inputusuarioPutBody, (inputusuarioPut));
                        controladora.cleanParams();
                        break;
                    case "5":
                        Console.WriteLine("Opción seleccionada: Método DELETE de un usuario por ID");


                        Console.WriteLine("Ingrese el id del usuario ");
                        string inputusuarioDelete = Console.ReadLine();
                        inputusuarioDelete = inputusuarioDelete.Trim();
                        controladora.ControllerReq("DELETE", URL+"/"+inputusuarioDelete, version, headers, inputusuarioDelete, (inputusuarioDelete));
                        controladora.cleanParams();
                        break;
                    case "6":
                        salir = true;
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                        break;
                }

                Console.WriteLine();
            }



        }


    }
}
