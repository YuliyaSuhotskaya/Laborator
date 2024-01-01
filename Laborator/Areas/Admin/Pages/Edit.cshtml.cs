using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Laborator.Data;
using Laborator.Entities;

namespace Laborator.Areas.Admin.Pages
{
    public class EditModel : PageModel
    {
        private readonly Laborator.Data.ApplicationDbContext _context;
        private IWebHostEnvironment _environment;

        public EditModel(Laborator.Data.ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public Jewelry Jewelry { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Jewelries == null)
            {
                return NotFound();
            }

            var jewelry =  await _context.Jewelries.FirstOrDefaultAsync(m => m.JewelryId == id);
            if (jewelry == null)
            {
                return NotFound();
            }
            Jewelry = jewelry;
           ViewData["JewelryGroupId"] = new SelectList(_context.JewelryGroups, "JewelryGroupId", "GroupName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Image != null)
            {
                var fileName = $"{Jewelry.JewelryId}" +
                Path.GetExtension(Image.FileName);
                Jewelry.Image = fileName;
                var path = Path.Combine(_environment.WebRootPath, "Images",
                fileName);
                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fStream);
                }
            }

            _context.Attach(Jewelry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JewelryExists(Jewelry.JewelryId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool JewelryExists(int id)
        {
          return (_context.Jewelries?.Any(e => e.JewelryId == id)).GetValueOrDefault();
        }
    }
}
