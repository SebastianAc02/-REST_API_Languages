using System;
using System.Collections.Generic;

namespace ApiRestParser
{
    public interface IService
    {
        void Create(string body);
        List<User> ReadAll();
        void UpdateById(string body, string  id);
        void DeleteById(string  id);
        void FindById(string  id);
        
    }
}
