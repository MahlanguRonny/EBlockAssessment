using Contact.DatabaseManager.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contact.DatabaseManager.Contracts
{
    public interface IContactManager
    {
        Task<bool> AddNewContact(ContactDto contact);
        Task<bool> DeleteContact(int id);
        Task<List<ContactDto>> GetAllContacts();
        Task<bool> UpdateContact(ContactDto contact);
        Task<ContactDto> GetConmtactById(int id);
    }
}
