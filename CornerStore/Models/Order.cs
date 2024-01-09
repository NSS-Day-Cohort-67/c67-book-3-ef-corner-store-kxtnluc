
using System.ComponentModel.DataAnnotations;

namespace CornerStore.Models;

public class Order
{
    public int Id { get; set; }
    [Required]
    public int CashierId { get; set; }
    public Cashier Cashier { get; set; }
    public List<OrderProduct> OrderProducts { get; set; }
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