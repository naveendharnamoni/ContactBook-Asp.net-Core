using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AddressBookCore.Entities.Service;
using AddressBookCore.Entities.Context;
using AddressBookCore.Models;

namespace AddressBookCore.Views.AddressBook
{
    [ViewComponent(Name = "ContactsList")]
    public class ContactsList : ViewComponent
    {
        private readonly AddressBookContext _context;

        public ContactsList(AddressBookContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var contacts =  new ContactService(_context).GetListFromDB();
            return View("ContactsList", contacts);
        }
    }
}
