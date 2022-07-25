using ContactList.Data.Models.Enums;

namespace ContactList.Domain.Models
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public CategoryEnum Category { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public int UserID { get; set; }
    }
}
