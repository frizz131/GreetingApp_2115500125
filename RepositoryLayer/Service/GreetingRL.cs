using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.DTO;
using RepositoryLayer.Entity;
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

        private readonly GreetingDBContext _context;

        public GreetingRL(GreetingDBContext context)
        {
            _context = context;
        }

        //Saves greeting messages in the database
        public bool AddGreeting(GreetingDTO greetingDTO)
        {
            var greetingEntity = new GreetingEntity
            {
                Key = greetingDTO.Key,
                Value = greetingDTO.Value
            };
            _context.Greetings.Add(greetingEntity);
            
            return true;
        }
    }
}
