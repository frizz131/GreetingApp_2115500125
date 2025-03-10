﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Channels;
using RepositoryLayer.Context;
using RepositoryLayer.DTO;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            else if (!string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
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

        public string GetGreeting()
        {
            return "Hello World!";
        }

        //Saves greeting messages in the database
        public bool AddGreeting(GreetingDTO greetingDTO)
        {
            var greetingEntity = new GreetingEntity
            {
                key = greetingDTO.key,
                value = greetingDTO.value
            };
            _context.Greetings.Add(greetingEntity);
            _context.SaveChanges();

            return true;
        }

        //Method for retrieving a greeting by ID
        public GreetingDTO GetGreetingById(int Id)
        {
            var greeting = _context.Greetings.FirstOrDefault(g => g.Id == Id);
            return greeting == null ? null : new GreetingDTO { key = greeting.key, value = greeting.value };

        }

        //This retrieves all the greeting messages from the Greetings table.
        public List<GreetingDTO> GetAllGreetings()
        {
            return _context.Greetings
                .Select(g => new GreetingDTO { key = g.key, value = g.value })
                .ToList();
        }
        /// <summary>
        /// Finds the greeting message by id.
        /// Updates its Key and Value fields.
        /// Saves changes to the database.
        /// </summary>
        public bool UpdateGreeting(int id, GreetingDTO greetingDTO)
        {
            var existingGreeting = _context.Greetings.FirstOrDefault(g => g.Id == id);
            if(existingGreeting != null)
            {
                existingGreeting.key = greetingDTO.key;
                existingGreeting.value = greetingDTO.value;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
