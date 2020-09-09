using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class RegisterModel
    {
        [Key]
        public long ID { get; set; }
        [Required(ErrorMessage ="Enter UserName")]
        public String UserName { get; set; }
        [StringLength(50,MinimumLength =6,ErrorMessage ="Length at least 6 characters")]
        [Required(ErrorMessage ="Enter Password")]
        public String Password { get; set; }
        [Compare("Password",ErrorMessage ="Password incorrect")]
        [Required(ErrorMessage ="Enter Password Confirm")]
        public String ConfirmPassword { get; set; }
        [Required(ErrorMessage ="Enter Your Name")]
        public String Name { get; set; }
        public String Phone { get; set; }
        public String Address { get; set; }
        [Required(ErrorMessage ="Enter Your Email")]
        public String Email { get; set; }

    }
}