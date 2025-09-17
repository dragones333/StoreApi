using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreAPI.Models2.Entities;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly StoreDbContext _context;

        public InvoicesController(StoreDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices([FromQuery] int? orderId, [FromQuery] bool? isPaid)
        {
            var query = _context.Invoice.AsQueryable();

            if (orderId.HasValue)
                query = query.Where(i => i.OrderId == orderId.Value);

            if (isPaid.HasValue)
                query = query.Where(i => i.IsPaid == isPaid.Value);

            return await query.ToListAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int id)
        {
            var invoice = await _context.Invoice.FindAsync(id);

            if (invoice == null)
                return NotFound();

            return invoice;
        }
        
        [HttpPost]
        public async Task<ActionResult<Invoice>> CreateInvoice([FromBody] Invoice invoice)
        {
            if (invoice.Total == 0)
                invoice.Total = invoice.Subtotal + invoice.Tax;

            invoice.CreatedAt = DateTime.UtcNow;

            _context.Invoice.Add(invoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInvoice), new { id = invoice.Id }, invoice);
        }
    }
}