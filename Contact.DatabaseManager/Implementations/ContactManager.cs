using Contact.Data.Models;
using Contact.DatabaseManager.Contracts;
using Contact.DatabaseManager.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.DatabaseManager.Implementations
{
    public class ContactManager : IContactManager
    {
        private readonly ContactDBContext _contactDBContext = new ContactDBContext();
        public async Task<bool> AddNewContact(ContactDto contact)
        {
            bool added = false;
            if (contact != null)
            {
                var newContact = new Data.Models.Contact
                {
                    Name = contact.Name,
                    PhoneNo = contact.PhoneNo
                };

                _contactDBContext.Attach(newContact);
                _contactDBContext.Entry(newContact).State = EntityState.Added;
                added = await _contactDBContext.SaveChangesAsync() > 0;
            }

            return added;


        }

        public async Task<bool> DeleteContact(int id)
        {
            var contactToRemove = _contactDBContext.Contacts.FirstOrDefault(x => x.Id == id);
            _contactDBContext.Entry(contactToRemove).State = EntityState.Deleted;
            return await _contactDBContext.SaveChangesAsync() > 0;
        }

        public async Task<List<ContactDto>> GetAllContacts()
        {
            return await _contactDBContext.Contacts.Select(x => new ContactDto
            {
                Id = x.Id,
                Name = x.Name,
                PhoneNo = x.PhoneNo
            }).ToListAsync();
        }

        public async Task<bool> UpdateContact(ContactDto contactDto)
        {
            bool updated = false;
            var currentContact = _contactDBContext.Contacts.FirstOrDefault(x => x.Id == contactDto.Id);
            if (currentContact != null)
            {
                currentContact.Name = contactDto.Name;
                currentContact.PhoneNo = contactDto.PhoneNo;

                _contactDBContext.Contacts.Attach(currentContact);
                _contactDBContext.Entry(currentContact).State = EntityState.Modified;
                updated = await _contactDBContext.SaveChangesAsync() > 0;
            }

            return updated;
        }

        public async Task<ContactDto> GetConmtactById(int id)
        {
            ContactDto contact = new ContactDto();
            var currentContact = await _contactDBContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            if (currentContact != null)
            {
                contact.Id = currentContact.Id;
                contact.Name = currentContact.Name;
                contact.PhoneNo = currentContact.PhoneNo;
            }

            return contact;
        }
    }
}
