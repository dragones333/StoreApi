using Microsoft.EntityFrameworkCore;
using StoreAPI.Models.Entities;
using StoreAPI.Models2.Entities;

namespace StoreAPI;

public class StoreDbtext: DbContext
{
    public DbSet<Order> Order { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<SystemUser> SystemUser { get; set; }
    public DbSet<Store> Store { get; set; }
    public DbSet<OrderProduct> OrderProduct { get; set; }
}