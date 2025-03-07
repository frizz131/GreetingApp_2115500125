using ModelLayer.Model;
using RepositoryLayer.DTO;

namespace BusinessLayer.Interface
{
    public interface IGreetingBL
    {
        public string GetGreeting();
        string GetGreetingMessage(string firstname, string lastname);
        string GetPersonalizedGreeting(GreetingRequestModel request);
        bool AddGreeting(GreetingDTO greetingDTO);
        GreetingDTO GetGreetingById(int Id);
    }
}
