using AddressBookCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBookCore.Entities.Context;

namespace AddressBookCore.Entities.Service
{
    public class ContactService
    {
        private readonly AddressBookContext _context;

        public ContactService(AddressBookContext context)
        {
            _context = context;
        }

        public bool AddContact(Contact contact)
        {
            _context.Add(contact);
            _context.SaveChanges();
            return true;
        }

        public bool EditContact(Contact contact)
        {
            try
            {
                _context.Update(contact);
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(contact.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        public bool Delete(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public Contact GetContact(int id)
        {
            Contact contact = null;
            if (ContactExists(id))
            {
                contact = _context.Contacts.FirstOrDefault(m => m.Id == id);
            }
            return contact;
        }

        public List<Contact> GetListFromDB()
        {
            return _context.Contacts.ToList();
        }

        public bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}
