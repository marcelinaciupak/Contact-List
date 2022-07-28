using ContactList.Domain.Models;
using ContactList.Domain.Repositories;
using ContactList.Exceptions;
using ContactList.Services.BusinessValidation;

namespace ContactList.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IContactValidationService _contactValidationService;

        public ContactService(IContactRepository contactRepository, IContactValidationService contactValidationService)
        {
            _contactRepository = contactRepository;
            _contactValidationService = contactValidationService;
        }

        public async Task<ContactDto> CreateAsync(ContactDto contactDto)
        {
            await _contactValidationService.ValidateContact(contactDto);

            return await _contactRepository.CreateAsync(contactDto);
        }
        public async Task<ContactDto> GetByIdAsync(int id)
        {
            var result = await _contactRepository.GetByIdAsync(id);
            if (result == null)
                throw new NotFoundException("Contact not found");

            return result;
        }
        public async Task<List<ContactDto>> GetByUserIdAsync(string userId)
        {
            return await _contactRepository.GetByUserIdAsync(userId);
        }

        public async Task<List<ContactDisplayListDto>> GetAllAsync()
        {
            return await _contactRepository.GetAllAsync();
        }

        public async Task<ContactDto> UpdateAsync(ContactDto contactDto)
        {
            await _contactValidationService.ValidateContact(contactDto);

            var result = await _contactRepository.UpdateAsync(contactDto);
            if (result == null)
                throw new NotFoundException("Contact not found");

            return result;
        }

        public async Task<ContactDto> RemoveAsync(int id)
        {
            var result = await _contactRepository.RemoveAsync(id);
            if (result == null)
                throw new NotFoundException("Contact not found");

            return result;
        }
    }
}
