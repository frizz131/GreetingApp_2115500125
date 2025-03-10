using RepositoryLayer.DTO;

namespace RepositoryLayer.Interface
{
    public interface IGreetingRL
    {
        public string GetGreeting();
        string GetGreeting(string firstname, string lastname); //Method to GetGreeting by first and last name
        bool AddGreeting(GreetingDTO greetingDTO); //Method to add greering in DataBase
        GreetingDTO GetGreetingById(int id); //method for retrieving a greeting by ID
        List<GreetingDTO> GetAllGreetings(); //method will return list of all greetings stored in database
        bool UpdateGreeting(int id, GreetingDTO greetingDTO);   //method for updating a greeting
    }
}
