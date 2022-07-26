﻿using ContactList.Domain.Models;

namespace ContactList.Domain.Repositories
{
    public interface IContactRepository
    {
        Task<ContactDto> CreateAsync(ContactDto contactDto);
        Task<ContactDto> GetByIdAsync(int id);
        Task<List<ContactDto>> GetAllAsync();
        Task<ContactDto> UpdateAsync(ContactDto contactDto);
        Task<ContactDto> RemoveAsync(int id);
    }
}