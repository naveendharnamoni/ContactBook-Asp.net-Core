using AddressBookCore.Entities;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using AddressBookCore.Entities.Service;
using System.Threading.Tasks;
using AddressBookCore.Entities.Context;

namespace AddressBookCore.Controllers
{
    public class AddressBookController : Controller
    {
        private readonly ContactService contactService;
        private readonly AddressBookContext _context;

        public AddressBookController(AddressBookContext context)
        {
            _context = context;
            contactService = new ContactService(context);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Form(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (contactService.ContactExists(contact.Id) && contact.Id > 0)
                {
                    contactService.EditContact(contact);
                }
                else
                {
                    contactService.AddContact(contact);
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(contact);
            }
        }

        public ActionResult Details(int id)
        {
            Contact contact = contactService.GetContact(id);
            return View("Index", contact);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Contact contact = contactService.GetContact(id);
            return View("Form", contact);
        }

        public ActionResult Delete(int id)
        {
            contactService.Delete(id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}