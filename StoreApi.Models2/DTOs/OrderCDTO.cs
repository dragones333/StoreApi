namespace StoreApi.Models2.DTOs;

//transacciones SQL
public class OrderCDTO
{
    public double Total { get; set; }
    public int SystemUserId { get; set; }
    public List<int> Products { get; set; }
}