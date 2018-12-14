using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevBuild_Assessment6_PutMeOnTheList.Models
{
    public class LoginModel
    {
        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "The user name must be atleast {2} characters long.")]
        public string UserName { get; set; }
        

        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "The password must be atleast {2} characters long.")]
        public string Password { get; set; }

       
    }
}