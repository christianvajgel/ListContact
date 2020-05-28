using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListContact.Models
{
    public class Todo
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Every task should have a name.")]
        public String Name { get; set; }
        public Boolean Finished { get; set; }
    }
}
