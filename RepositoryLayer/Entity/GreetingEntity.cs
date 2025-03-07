using System.ComponentModel.DataAnnotations;

namespace RepositoryLayer.Entity
{
    //represents the greeting table in the database

    public class GreetingEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string key { get; set; }
        [Required]
        public string value { get; set; }
    }
}
