using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessDirectoryApp.Models
{
    public class ClientContact
    {
        public int ClientID { get; set; }
        public int ContactID { get; set; }

        [ForeignKey("ClientID")]
        public ClientModel Client { get; set; }
        [ForeignKey("ContactID")]
        public ContactModel Contact { get; set; }


        public ClientContact()
        {
        }
    }
}
