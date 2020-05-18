using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListContact.Models;
using Microsoft.AspNetCore.Mvc;

namespace ListContact.Controllers
{
    [Route("[controller]")]
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Meet/{name}/{surname}")]
        public IActionResult Interation(string name, string surname) 
        {
            if (!String.IsNullOrWhiteSpace(name) && !String.IsNullOrWhiteSpace(surname))
            {
                ViewBag.CompleteName = $"{name} {surname}";
                return View("Greeting");
            }
            return View();
        }

        [Route("About")]
        public IActionResult About()
        {
            var person = new Person()
            {
                Name = "Christian",
                Email = "christian@mail.com",
                Password = "123456",
                Username = "christian"
            };

            var contact = new Contact() {
                FirstName = "Christian",
                Surname = "Rocha",
                Birthday = new DateTime(1993, 12, 18),
                Profession = "Student",
                Email = "christian@infnet.edu.br",
                Phone = "987654321",
                Address = "Street X"
            };

            var contactBook = new ContactBook()
            {
                Name = "PersonalContacts",
                Type = "Personal",
                Size = 100,
                UsernamePerson = "christian",
            };

            contactBook.Contacts.Add(contact);

            person.ContactBooks.Add(contactBook);

            return View(person);
        }

        [Route("{usernamePerson}/{contactBookName}/Contacts")]
        public IActionResult Contacts(String usernamePerson, String contactBookName)
        {
            List<Contact> contacts = new List<Contact>();
            Random random = new Random();
            for (int i = 1; i <= 10; i++) 
            {
                contacts.Add(new Contact
                {
                    FirstName = $"John",
                    Surname = $"Doe {i}",
                    Birthday = new DateTime(random.Next(1,9999),random.Next(1,12),random.Next(1,28)),
                    Profession = "Student",
                    Email = $"johndoe_{i}@mail.com",
                    Phone = $"+55 ({random.Next(1,21)}) {random.Next(4,9)}{random.Next(0, 9)}" +
                            $"{random.Next(0, 9)}-{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}-" +
                            $"{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}",
                    Address = $"Street {random.Next(1,999)}"
                });
            }
            return View(contacts);
        }
    }


    

}