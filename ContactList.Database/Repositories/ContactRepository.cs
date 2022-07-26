using AutoMapper;
using ContactList.Database.Models;
using ContactList.Domain.Models;
using ContactList.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Database.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactListContext _context;
        private readonly IMapper _mapper;

        public ContactRepository(ContactListContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ContactDto> CreateAsync(ContactDto contactDto)
        {
            var newContact = _mapper.Map<Contact>(contactDto);
            await _context.Contacts.AddAsync(newContact);
            await _context.SaveChangesAsync();

            return _mapper.Map<ContactDto>(newContact);
        }

        public async Task<ContactDto> GetByIdAsync(int id)
        {
            var contact = await _context.Contacts.Where(x => x.Id == id).SingleOrDefaultAsync();

            return _mapper.Map<ContactDto>(contact);
        }

        public async Task<List<ContactDto>> GetAllAsync()
        {
            var contacts = await _context.Contacts.ToListAsync();

            return _mapper.Map<List<ContactDto>>(contacts);
        }

        public async Task<ContactDto> UpdateAsync(ContactDto contactDto)
        {
            var contactToUpdate = await _context.Contacts.SingleOrDefaultAsync(x => x.Id == contactDto.Id);
            _mapper.Map(contactDto, contactToUpdate);
            await _context.SaveChangesAsync();

            return _mapper.Map<ContactDto>(contactToUpdate);
        }

        public async Task<ContactDto> RemoveAsync(int id)
        {
            var contactToRemove = await _context.Contacts.SingleOrDefaultAsync(x => x.Id == id);
            _context.Remove(contactToRemove);
            await _context.SaveChangesAsync();

            return _mapper.Map<ContactDto>(contactToRemove);
        }
    }
}
