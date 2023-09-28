using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderApi.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }

        // Additional properties specific to your order entity

        public List<OrderItem> OrderItems { get; set; }

        public decimal GetTotalPrice()
        {
            decimal totalPrice = 0;
            foreach (var orderItem in OrderItems)
            {
                totalPrice += orderItem.GetTotalPrice();
            }
            return totalPrice;
        }
    }
}
