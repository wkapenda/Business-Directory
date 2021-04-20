using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessDirectoryApp.Models
{
    public class ContactModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        public ContactModel()
        {
        }
    }
}
