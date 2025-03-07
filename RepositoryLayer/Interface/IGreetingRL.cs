using RepositoryLayer.DTO;

namespace RepositoryLayer.Interface
{
    public interface IGreetingRL
    {
        public string GetGreeting();
        string GetGreeting(string firstname, string lastname);
        bool AddGreeting(GreetingDTO greetingDTO);
        GreetingDTO GetGreetingById(int id); //method for retrieving a greeting by ID
    }
}
