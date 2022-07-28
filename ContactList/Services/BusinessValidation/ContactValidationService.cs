using ContactList.Domain.Models;
using ContactList.Domain.Repositories;
using ContactList.Exceptions;

namespace ContactList.Services.BusinessValidation
{
    public class ContactValidationService : IContactValidationService
    {
        private readonly IContactRepository _contactReository;

        public ContactValidationService(IContactRepository contactRepository)
        {
            _contactReository = contactRepository;
        }

        public async Task ValidateContact(ContactDto contactDto)
        {
            await CheckFullNameIsUnique(contactDto);
            await CheckIfPhoneIsUnique(contactDto.Phone);
            await CheckIfEmailIsUnique(contactDto.Email);
        }

        private async Task CheckFullNameIsUnique(ContactDto contactDto)
        {
            var contact = await _contactReository.GetByFullName(contactDto);

            if (contact != null)
            {
                throw new BusinessException($"Contact {contactDto.FirstName} {contactDto.LastName} already exists");
            }
        }

        private async Task CheckIfPhoneIsUnique(string phone)
        {
            var contact = await _contactReository.GetByPhone(phone);

            if (contact != null)
            {
                throw new BusinessException($"Contact with phone: {phone} already exists");
            }
        }

        private async Task CheckIfEmailIsUnique(string email)
        {
            var contact = await _contactReository.GetByEmail(email);

            if (contact != null)
            {
                throw new BusinessException($"Contact with email: {email} already exists");
            }
        }
    }
}
