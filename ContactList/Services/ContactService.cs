using ContactList.Domain.Models;
using ContactList.Domain.Repositories;
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
            return await _contactRepository.GetByIdAsync(id);
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

            return await _contactRepository.UpdateAsync(contactDto);
        }

        public async Task<ContactDto> RemoveAsync(int id)
        {
            return await _contactRepository.RemoveAsync(id);
        }
    }
}
