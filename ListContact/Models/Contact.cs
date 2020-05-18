using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListContact.Models
{
    // Student
    public class Contact
    {
        public String FirstName { get; set; }
        public String Surname { get; set; }
        public DateTime Birthday { get; set; }
        public String Profession { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public String Address { get; set; }
    }
}
