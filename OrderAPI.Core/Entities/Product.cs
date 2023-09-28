using System;
using System.ComponentModel.DataAnnotations;

namespace OrderApi.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be non-negative.")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity must be non-negative.")]
        public int StockQuantity { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        [StringLength(50)]
        public string Manufacturer { get; set; }

        // Additional properties specific to your product entity

        public bool IsInStock => StockQuantity > 0;
    }
}
