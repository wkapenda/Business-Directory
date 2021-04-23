using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BusinessDirectoryApp.Models;

namespace BusinessDirectoryApp.Models
{
    public class ClientModel
    { 
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClientID { get; set; }

        [Display(Name = "Client Name")]
        [Required (ErrorMessage = "You need to provide the Client Name")]
        public string Name { get; set; }

        [Display(Name = "Client Code")]
        public string clientCode { get; set; }

        [Display(Name = "No. of Linked Contacts")]
        public int linkedContacts { get; set; }

        //public virtual ICollection<ContactModel> Contacts { get; set; }
        // navigational property
        public virtual ICollection <ClientContact> ClientContact { get; set; }


        public ClientModel()
        {
            
            //Contacts = new HashSet<ContactModel>();

        }

        internal static object AsNoTracking()
        {
            throw new NotImplementedException();
        }
    }
}
