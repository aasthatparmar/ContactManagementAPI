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

        //[HttpGet]
        //public ActionResult<List<Contact>> Get() =>
        //    _contactService.GetAll();

        [HttpGet]
        public ActionResult<List<Contact>> Get()
        {
            var contact = _contactService.ReadData();
            return Ok(contact);
        }

        [HttpGet("{id}")]
        public ActionResult<Contact> Get(int id)
        {
            var contact = _contactService.GetDataById(id);
            if (contact == null)
            {
                return NotFound();
            }
            return contact;
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            var users = _contactService.ReadData();
            if (users.Count == 0)
                contact.Id = 1;
            else
                contact.Id = users.Max(c => c.Id) + 1;
            users.Add(contact);
            _contactService.WriteData(users);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Contact contact)
        {
            var users = _contactService.ReadData();
            var existingUser = users.FirstOrDefault(u => u.Id == id);
            if (existingUser != null)
            {
                existingUser.FirstName = contact.FirstName;
                existingUser.LastName = contact.LastName;
                existingUser.Email = contact.Email;
                _contactService.WriteData(users);
                return Ok();
            }
            return NotFound();


            //if (id != contact.Id)
            //{
            //    return BadRequest();
            //}

            //var existingContact = _contactService.Get(id);
            //if (existingContact == null)
            //{
            //    return NotFound();
            //}

            //_contactService.Update(contact);
            //return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var users = _contactService.ReadData();
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                users.Remove(user);
                _contactService.WriteData(users);
                return Ok();
            }
            return NotFound();

        }

        [HttpGet("exception")]
        public IActionResult GetException()
        {
            throw new Exception("This is a test exception.");
        }
    }
}