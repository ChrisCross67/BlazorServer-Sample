using DataLibrary;

namespace BlazorServer.Models
{
    public class PersonModel : IPersonModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}