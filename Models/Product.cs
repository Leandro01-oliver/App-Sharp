using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace app_web.Models
{
    public class Product
    {
        [Display(Name = "id")]
        public int Id { get; set; }

        [Display(Name = "name")]
        public string  Name { get; set; }

        [Display(Name = "prince")]
        public double Prince { get; set; }

        [Display(Name = "active")]
        public bool  Active { get; set; }

        [Display(Name = "userId")]
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
