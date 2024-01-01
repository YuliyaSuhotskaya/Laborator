using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Laborator.Data;
using Laborator.Entities;

namespace Laborator.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Laborator.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public CreateModel(Laborator.Data.ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult OnGet()
        {
        ViewData["JewelryGroupId"] = new SelectList(_context.JewelryGroups, "JewelryGroupId", "GroupName");
            return Page();
        }

        [BindProperty]
        public Jewelry Jewelry { get; set; }
        
        [BindProperty]
        public IFormFile Image { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid || _context.Jewelries == null || Jewelry == null)
            //  {
            //      return Page();
            //  }
            if (!ModelState.IsValid)
            {
                return Page();
            }


            _context.Jewelries.Add(Jewelry);
            await _context.SaveChangesAsync();

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
                await _context.SaveChangesAsync();
            }


            return RedirectToPage("./Index");
        }
    }
}
