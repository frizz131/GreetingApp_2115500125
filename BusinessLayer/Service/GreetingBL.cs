using BusinessLayer.Interface;
using ModelLayer.Model;
using RepositoryLayer.DTO;
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
    }
}
