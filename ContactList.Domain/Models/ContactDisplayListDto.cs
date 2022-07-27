using ContactList.Domain.Models.Enums;

namespace ContactList.Domain.Models
{
    public class ContactDisplayListDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CategoryEnum Category { get; set; }
    }
}
