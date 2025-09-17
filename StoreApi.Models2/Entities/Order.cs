using StoreApi.Models2;

namespace StoreAPI.Models2.Entities;

public class Order
{
    public int Id { get; set; }
    public double Total { get; set; }
    public DateTime CreateAt { get; set; }
    public int SystemUserId { get; set; }
    public SystemUser SystemUser { get; set; }
    public List<OrderProduct>OrderProducts { get; set; }
}