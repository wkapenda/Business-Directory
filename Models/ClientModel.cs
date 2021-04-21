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

        [Display(Name = "Client Name")]
        [Required (ErrorMessage = "You need to provide the Client Name")]
        public string Name { get; set; }

        

        public ClientModel()
        {

        }

        internal static object AsNoTracking()
        {
            throw new NotImplementedException();
        }
    }
}
