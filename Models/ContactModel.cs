using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BusinessDirectoryApp.Models;

namespace BusinessDirectoryApp.Models
{
    public class ContactModel
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ContactID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "You need to provide the Contact Name")]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "You need to provide the Contact Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "You need to provide the Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "No. of linked clients")]
        public int linkedClients { get; set; }

        //public int ClientID { get; set; }
        //public ClientModel Client { get; set; }

        public virtual ICollection<ClientContact> ClientContact { get; set; }

        //public virtual ICollection<ClientModel> Clients { get; set; }

        public ContactModel()
        {
            //Clients = new HashSet<ClientModel>();
        }
    }
}
