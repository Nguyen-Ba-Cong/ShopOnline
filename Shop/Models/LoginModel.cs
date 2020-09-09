using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class LoginModel
    {
        [Key]
        [Required(ErrorMessage ="Enter User Name")]
        public String UserName { get; set; }
        [Required(ErrorMessage ="Enter Password")]
        public String Password { get; set; }
    }
}