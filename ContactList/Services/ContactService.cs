using ContactList.Domain.Models;
using ContactList.Domain.Repositories;

namespace ContactList.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<ContactDto> CreateAsync(ContactDto contactDto)
        {
            return await _contactRepository.CreateAsync(contactDto);
        }
        public async Task<ContactDto> GetByIdAsync(int id)
        {
            return await _contactRepository.GetByIdAsync(id);
        }
        public async Task<List<ContactDto>> GetAllAsync()
        {
            return await _contactRepository.GetAllAsync();
        }

        public async Task<ContactDto> UpdateAsync(ContactDto contactDto)
        {
            return await _contactRepository.UpdateAsync(contactDto);
        }

        public async Task<ContactDto> RemoveAsync(int id)
        {
            return await _contactRepository.RemoveAsync(id);
        }
    }
}
