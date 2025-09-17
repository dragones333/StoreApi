using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreAPI.Models2.Entities
{
    public class Invoice
    {
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Required]
        [MaxLength(50)]
        public string InvoiceNumber { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }

        public DateTime? DueDate { get; set; }

        public double Subtotal { get; set; }
        public double Tax { get; set; }
        public double Total { get; set; }

        [Required]
        [MaxLength(10)]
        public string Currency { get; set; }

        public bool IsPaid { get; set; }
        public DateTime? PaymentDate { get; set; }

        [Required]
        [MaxLength(200)]
        public string BillingName { get; set; }

        public string BillingAddress { get; set; }

        [EmailAddress]
        public string BillingEmail { get; set; }

        public string TaxId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}