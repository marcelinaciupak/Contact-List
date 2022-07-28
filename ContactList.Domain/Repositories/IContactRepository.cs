using ContactList.Domain.Models;

namespace ContactList.Domain.Repositories
{
    public interface IContactRepository
    {
        Task<ContactDto> CreateAsync(ContactDto contactDto);
        Task<ContactDto> GetByIdAsync(int id);
        Task<ContactDto> GetByFullName(ContactDto contactDto);
        Task<ContactDto> GetByPhone(string phone);
        Task<ContactDto> GetByEmail(string email);
        Task<List<ContactDisplayListDto>> GetAllAsync();
        Task<ContactDto> UpdateAsync(ContactDto contactDto);
        Task<ContactDto> RemoveAsync(int id);
        Task<List<ContactDto>> GetByUserIdAsync(string userId);
    }
}
