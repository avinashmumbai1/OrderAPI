using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderApi.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // Additional properties specific to the customer entity
        public DateTime RegistrationDate { get; set; } // Date when the customer registered
        public bool IsActive { get; set; } // Indicates if the customer account is active

        // Define a one-to-many relationship with orders
        public List<Order> Orders { get; set; }

        // You can define other relationships here with other entities if needed

        // Constructors, methods, and other members as needed
    }
}
