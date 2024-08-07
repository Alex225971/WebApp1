﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Company Name")]
        [MaxLength(30)]
        public string? Name { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
