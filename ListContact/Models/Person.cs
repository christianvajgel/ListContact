using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListContact.Models
{
    // Teacher
    public class Person
    {
        public String Name { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Username { get; set; }
        public List<ContactBook> ContactBooks { get; set; } = new List<ContactBook>();
    }
}
