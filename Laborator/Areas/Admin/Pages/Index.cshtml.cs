using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Laborator.Data;
using Laborator.Entities;

namespace Laborator.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Laborator.Data.ApplicationDbContext _context;

        public IndexModel(Laborator.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Jewelry> Jewelry { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Jewelries != null)
            {
                Jewelry = await _context.Jewelries
                .Include(j => j.Group).ToListAsync();
            }
        }
    }
}
