using System;
using System.ComponentModel.DataAnnotations;

namespace app_web.Models
{
    public class User
    {
        [Display(Name = "id")]
        public int Id { get; set; }

        [Display(Name = "email")]
        public string Email { get; set; }

        [Display(Name = "password")]
        public string Password { get; set; }

    }
}
