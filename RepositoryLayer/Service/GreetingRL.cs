using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Service
{
    public class GreetingRL : IGreetingRL
    {
        public string GetGreeting(string firstName, string lastName)
        {
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                return $"Hello, {firstName} {lastName}";
            }
            else if(!string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                return $"Hello, {firstName}";
            }
            else if (string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                return $"Hello, Mr./Mrs. {lastName}";
            }
            else
            {
                return $"Hello, World";
            }

        }
    }
}
