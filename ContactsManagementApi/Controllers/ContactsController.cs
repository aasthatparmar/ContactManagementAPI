using ContactsManagementApi.Models;
using ContactsManagementApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContactsManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactService _contactService;

        public ContactsController(ContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public ActionResult<List<Contact>> Get() =>
            _contactService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Contact> Get(int id)
        {
            var contact = _contactService.Get(id);
            if (contact == null)
            {
                return NotFound();
            }
            return contact;
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            _contactService.Add(contact);
            return CreatedAtAction(nameof(Get), new { id = contact.Id }, contact);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Contact contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }

            var existingContact = _contactService.Get(id);
            if (existingContact == null)
            {
                return NotFound();
            }

            _contactService.Update(contact);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contact = _contactService.Get(id);
            if (contact == null)
            {
                return NotFound();
            }

            _contactService.Delete(id);
            return NoContent();
        }

        [HttpGet("exception")]
        public IActionResult GetException()
        {
            throw new Exception("This is a test exception.");
        }
    }
}