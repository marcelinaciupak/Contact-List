using ContactList.Domain.Models;

namespace ContactList.Services.BusinessValidation
{
    public interface IContactValidationService
    {
        Task ValidateContact(ContactDto contactDto);
    }
}
