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

        [Display(Name = "Client Code")]
        public string clientCode { get; set; }

        [Display(Name = "No. of Linked Contacts")]
        public int linkedContacts { get; set; }



        public ClientModel()
        {


        }

        internal static object AsNoTracking()
        {
            throw new NotImplementedException();
        }
    }
}
