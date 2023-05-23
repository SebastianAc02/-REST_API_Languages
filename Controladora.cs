using System.Collections.Generic;
using Newtonsoft.Json;
using System;
namespace ApiRestParser

{
   public class Controller
    {



        private Service service = new Service();
        private string method;
        private string URL;
        private string versionProtocol;
        private  string headers;
        private string body;
        private string id;

        public Controller() { }

        public  void cleanParams()
        {
            this.method = "";
            this.URL = "";
            this.versionProtocol = "";
            this.headers = "";
            this.body = "";
            this.id = ""; 
        }

        public void ControllerReq(string method, string URL, string verstionProtocol, string headers, string body )
        {

            this.method = method;
          //  this.URL = URL;
            this.versionProtocol = verstionProtocol;
            this.headers = headers;
            this.body = body;


            if (URL == "http://localhost:8080/api/users"){

                this.URL = URL; 


                switch (method)
                {

                    case "GET":
                        
                        
                           
                        service.ReadAll();

                        
                        break;
                    case "POST":

                        service.Create(body);
                        break;

                    default:
                        
                        break;



            }

            }
        }



        public void ControllerReq(string method, string URL, string verstionProtocol, string headers, string body, string  id)
        {

            this.method = method;
            //  this.URL = URL;
            this.versionProtocol = verstionProtocol;
            this.headers = headers;
            this.body = body;
            this.id = id;

            string url = "http://localhost:8080/api/users/"+id;
              
            if (URL == url ){

                 
                this.URL = URL;



                switch (method)
                {

                    case "GET":



                        service.FindById(id);


                        break;
                    case "PUT":
                        service.UpdateById(body, id);
                        break;

                    case "DELETE":
                        service.DeleteById(id);
                        break;
                   

                    default:

                        break;



                }




            }
        }


        public string GetUsers()
        {
            service.ReadAll();
            string response = this.versionProtocol + "200 Ok\r\n";
            response += "Content-Type: application/json\r\n";
            response += "Content-Length: " + body.Length + "\r\n";
            response += "\r\n" + body;
               

            return response;



        }

        public string GetUserById(string  id)
        {

            service.FindById(id);
            string response = this.versionProtocol + "200 Ok\r\n";
            response += "Content-Type: application/json\r\n";
            response += "Content-Length: " + body.Length + "\r\n";
            response += "\r\n" + body;


            return response;

        }

        public string PostUser(string body)
        {
            service.Create(body);

           // service.FindById(id);
            string response = this.versionProtocol + "201 Created\r\n";
            response += "Content-Type: application/json\r\n";
            response += "Content-Length: " + body.Length + "\r\n";
            response += "\r\n" + body;


            return response;
        }


        public string DeleteUserById(string  id )
        {
            service.DeleteById(id);
            string response = this.versionProtocol + "204 No Content\r\n";
            response += "\r\n";

            return response;

        }

        public string PutUserById(string body, string  id)
        {

            service.UpdateById(body, id);
            string response = this.versionProtocol + "200 OK\r\n";
            response += "Content-Type: application/json\r\n";
            response += "Content-Length: " + body.Length + "\r\n";
            response += "\r\n" + body;

            return response;


        }





    }

}
