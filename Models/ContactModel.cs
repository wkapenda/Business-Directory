using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessDirectoryApp.Models
{
    public class ContactModel
    {
        [Key]
        public int Id { get; set; }

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


        public ContactModel()
        {
        }
    }
}
