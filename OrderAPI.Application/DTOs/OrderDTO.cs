using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderApi.Application.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer ID is required.")]
        public int CustomerId { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "Invalid date format.")]
        [Required(ErrorMessage = "Order date is required.")]
        public DateTime OrderDate { get; set; }

        // Additional properties with validation rules
        [StringLength(100, ErrorMessage = "Shipping address cannot exceed 100 characters.")]
        public string ShippingAddress { get; set; }

        //[Range(0.01, double.MaxValue, ErrorMessage = "Total price must be greater than 0.")]
        public decimal TotalPrice { get; set; }
        // Add other properties as needed for API responses

        // You can add additional validation attributes for other properties as required.
    }
}
