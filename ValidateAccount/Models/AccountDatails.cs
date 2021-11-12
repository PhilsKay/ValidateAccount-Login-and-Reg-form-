using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ValidateAccount.Models
{
    public class AccountDatails
    {
        [Key]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; }

        [DataType(DataType.Password, ErrorMessage = "Invalid Password")]
        [Required]
        [MaxLength(10)]
        [DisplayName("Password")]
        [StringLength(maximumLength: 10, MinimumLength = 6, ErrorMessage = "Min of 6 characters eg. @Davlibs62")]
        public string UserPass { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [MaxLength(10)]
        [DisplayName("Confirm Password")]
        [StringLength(10, MinimumLength = 6)]
        [NotMapped]
        [Compare("UserPass",ErrorMessage ="Password does not match")]
        public string ConfirmUserPass { get; set; }

    }
}
