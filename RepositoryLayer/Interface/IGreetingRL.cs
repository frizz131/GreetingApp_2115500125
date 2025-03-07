using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer.DTO;

namespace RepositoryLayer.Interface
{
    public interface IGreetingRL
    {
        string GetGreeting(string firstname, string lastname);
        bool AddGreeting(GreetingDTO greetingDTO);
    }
}
