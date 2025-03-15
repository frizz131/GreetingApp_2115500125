using BusinessLayer.Interface;
using ModelLayer.Model;
using RepositoryLayer.DTO;
using RepositoryLayer.Interface;
using Microsoft.Extensions.Logging;

namespace BusinessLayer.Service
{
    public class GreetingBL : IGreetingBL
    {
        private readonly IGreetingRL _greetingRL;
        private readonly ILogger<GreetingBL> _logger;

        public GreetingBL(IGreetingRL greetingRL, ILogger<GreetingBL> logger)
        {
            _greetingRL = greetingRL;
            _logger = logger;
        }
        
        public string GetGreeting()
        {
            return _greetingRL.GetGreeting();
        }
        public string GetGreetingMessage(string firstName, string lastName)
        {
            return _greetingRL.GetGreeting(firstName, lastName);
        }
        public string GetPersonalizedGreeting(GreetingRequestModel request)
        {
            return _greetingRL.GetGreeting(request.FirstName, request.LastName);
        }
        //Calls the repository to save greetings
        public bool AddGreeting(GreetingDTO greetingDTO)
        {
            return _greetingRL.AddGreeting(greetingDTO);
        }

        //Implementation of GetGreetingById
        public GreetingDTO GetGreetingById(int id)
        {
            return _greetingRL.GetGreetingById(id);
        }

        //Calls the repository layer method to fetch all greetings.
        public List<GreetingDTO> GetAllGreetings()
        {
            return _greetingRL.GetAllGreetings();
        }
        //Calls the repository layer method to update a greeting.
        public bool UpdateGreeting(int id, GreetingDTO greetingDTO)
        {
            return _greetingRL.UpdateGreeting(id, greetingDTO);
        }
        //Calls the repository layer method to delete a greeting.
        public bool DeleteGreeting(int id)
        {
            _logger.LogInformation($"Attempting to delete greeting with ID, {id}");
            return _greetingRL.DeleteGreeting(id);
        }
    }
}
