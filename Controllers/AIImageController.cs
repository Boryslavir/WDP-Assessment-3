using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WDP_Assessment_3.Data;
using WDP_Assessment_3.Models;

// For authorisation validation
using Microsoft.AspNetCore.Authorization;

namespace WDP_Assessment_3.Controllers
{
    public class AIImageController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AIImageController(
                ApplicationDbContext context,
                IWebHostEnvironment webHostEnvironment
        )
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: AIImage
        public async Task<IActionResult> Index()
        {
            return View(await _context.AIImage.ToListAsync());
        }

        // GET: AIImage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aIImage = await _context.AIImage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aIImage == null)
            {
                return NotFound();
            }

            return View(aIImage);
        }

        // GET: AIImage/Create
        [Authorize(Roles = "admin, user")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: AIImage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> Create([Bind("Id,Prompt,ImageGenerator,Like,canIncreaseLike")] AIImage aIImage, IFormFile ImageFile)
        {
            aIImage.UploadDate = DateTime.Now; // enforces current date and time by default

            if (ImageFile != null && ImageFile.Length > 0)
            {
                // Build target file path
                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img");
                Directory.CreateDirectory(uploadFolder); // ensure folder have to exist

                string uploadFilePath = Path.Combine(uploadFolder, ImageFile.FileName);

                // Save file to 'wwwroot/img/'
                using (var stream = new FileStream(uploadFilePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                // Store filename in the database
                aIImage.Filename = ImageFile.FileName;
            }

            if (ModelState.IsValid)
            {
                _context.Add(aIImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aIImage);
        }

        // GET: AIImage/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aIImage = await _context.AIImage.FindAsync(id);
            if (aIImage == null)
            {
                return NotFound();
            }
            return View(aIImage);
        }

        // POST: AIImage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Prompt,ImageGenerator,UploadDate,Filename,Like,canIncreaseLike")] AIImage aIImage, IFormFile ImageFile)
        {
            if (id != aIImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Handle file upload if a new file is provided
                    if (ImageFile != null && ImageFile.Length > 0)
                    {
                        string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img");
                        Directory.CreateDirectory(uploadFolder); // ensure folder exists

                        string uploadFilePath = Path.Combine(uploadFolder, ImageFile.FileName);

                        using (var stream = new FileStream(uploadFilePath, FileMode.Create))
                        {
                            await ImageFile.CopyToAsync(stream);
                        }

                        // Update the filename in the database
                        aIImage.Filename = ImageFile.FileName;
                    }
                    else
                    {
                        // Preserve the existing filename (so it doesn't get overwritten with null)
                        var existingImage = await _context.AIImage.AsNoTracking()
                            .FirstOrDefaultAsync(ai => ai.Id == id);
                        if (existingImage != null)
                        {
                            aIImage.Filename = existingImage.Filename;
                        }
                    }

                    _context.Update(aIImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AIImageExists(aIImage.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(aIImage);
        }


        // GET: AIImage/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aIImage = await _context.AIImage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aIImage == null)
            {
                return NotFound();
            }

            return View(aIImage);
        }

        // POST: AIImage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aIImage = await _context.AIImage.FindAsync(id);
            if (aIImage != null)
            {
                _context.AIImage.Remove(aIImage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AIImageExists(int id)
        {
            return _context.AIImage.Any(e => e.Id == id);
        }
    }
}
