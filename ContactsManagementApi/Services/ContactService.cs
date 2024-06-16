using ContactsManagementApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace ContactsManagementApi.Services
{
    public class ContactService
    {
        private readonly List<Contact> _contacts;

        public ContactService()
        {
            _contacts = new List<Contact>
            {
                new Contact { Id = 1, FirstName = "ABC", LastName = "DEF", Email = "abc.def@gmail.com" },
                new Contact { Id = 2, FirstName = "GHI", LastName = "JKL", Email = "ghi.jkl@gmail.com" }
            };
        }

        public List<Contact> GetAll() => _contacts;

        public Contact Get(int id) => _contacts.FirstOrDefault(c => c.Id == id);

        public void Add(Contact contact)
        {
            if (_contacts.Count == 0)
                contact.Id = 1;
            else
            contact.Id = _contacts.Max(c => c.Id) + 1;
            _contacts.Add(contact);
        }

        public void Update(Contact contact)
        {
            var existingContact = Get(contact.Id);
            if (existingContact != null)
            {
                existingContact.FirstName = contact.FirstName;
                existingContact.LastName = contact.LastName;
                existingContact.Email = contact.Email;
            }
        }

        public void Delete(int id)
        {
            var contact = Get(id);
            if (contact != null)
            {
                _contacts.Remove(contact);
            }
        }
    }
}