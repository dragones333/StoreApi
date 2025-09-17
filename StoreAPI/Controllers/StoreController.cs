using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wkhtmltopdf.NetCore;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IGeneratePdf _generatePDF;
        private readonly StoreDbContext _context;

        public StoreController(IGeneratePdf generatePDF, StoreDbContext context)
        {
            _generatePDF = generatePDF;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllStores()
        {
            var store=await _context.Store.ToListAsync();
            return Ok(store);
        }

        [HttpGet("{id}/pdf")]
        public async Task<IActionResult> GetStorePDF(int id)
        {
            var store = await _context.Store
                .Include(s =>s.Products)
                .FirstOrDefaultAsync(s =>s.Id==id);
            var result = await _generatePDF.GetPdf("Templates/StoreTemplate.cshtml", 
                store
                );
            return result;
        }
    }
}
