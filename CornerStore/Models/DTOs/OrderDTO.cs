
using System.ComponentModel.DataAnnotations;

namespace CornerStore.Models.DTOs;

public class OrderDTO
{
    public int Id { get; set; }
    [Required]
    public int CashierId { get; set; }
    public CashierDTO Cashier { get; set; }
    public List<OrderProductDTO> OrderProducts { get; set; }
    public decimal Total {
        get
        {
            decimal total = 0;

            if(OrderProducts != null)
            {
                total = OrderProducts.Sum(op => op.Product.Price * op.Quantity);
            }

            return total;
        }
    }
    public DateTime? PaidOnDate { get; set; }
}