using ContactList.Domain.Models;

namespace ContactList.Services
{
    public interface IContactService
    {
        Task<ContactDto> CreateAsync(ContactDto contactDto);
        Task<ContactDto> GetByIdAsync(int id);
        Task<List<ContactDto>> GetByUserIdAsync(string userId);
        Task<List<ContactDisplayListDto>> GetAllAsync();
        Task<ContactDto> UpdateAsync(ContactDto contactDto);
        Task<ContactDto> RemoveAsync(int id);
    }
}
