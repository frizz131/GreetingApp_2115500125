using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using ModelLayer.Model;
using RepositoryLayer.Interface;

namespace BusinessLayer.Service
{
    public class GreetingBL : IGreetingBL
    {
        private readonly IGreetingRL _greetingRL;

        public GreetingBL(IGreetingRL greetingRL)
        {
            _greetingRL = greetingRL;
        }

        public string GetGreetingMessage(string firstName, string lastName)
        {
            return _greetingRL.GetGreeting(firstName, lastName);
        }
        public string GetPersonalizedGreeting(GreetingRequestModel request)
        {
            return _greetingRL.GetGreeting(request.FirstName, request.LastName);
        }
    }
}
