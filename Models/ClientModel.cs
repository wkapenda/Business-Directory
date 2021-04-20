using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessDirectoryApp.Models
{
    public class ClientModel
    { 
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        

        public ClientModel()
        {

        }
    }
}
