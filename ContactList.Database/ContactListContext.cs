using ContactList.Database.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Database
{
    public class ContactListContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Contact> Contacts { get; set; }


        public ContactListContext(DbContextOptions<ContactListContext> options) : base(options)
        {
              
        }
    }
}
