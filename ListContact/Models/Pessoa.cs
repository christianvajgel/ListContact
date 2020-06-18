using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListContact.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        [Required]
        //[Display = "Nome"]
        public String Nome { get; set; }
        [Required]
        public String Email { get; set; }
    }

}
