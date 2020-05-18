using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListContact.Models
{
    // Turma
    public class ContactBook
    {
        public String Name { get; set; }
        public String Type { get; set; }
        public int Size { get; set; }
        public String UsernamePerson { get; set; }
        public List<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
