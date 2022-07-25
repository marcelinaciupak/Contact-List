using ContactList.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Database
{
    public class ContactListContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public ContactListContext(DbContextOptions<ContactListContext> options) : base(options)
        {
              
        }
    }
}
