using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext _context;

        public StudentController(StudentContext context)
        {
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
              return _context.Student != null ? 
                          View(await _context.Student.ToListAsync()) :
                          Problem("Entity set 'StudentContext.Student'  is null.");
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Student model, IFormFile imageFile)
        {
            if (true)
            {
                // Xử lý tệp tin ảnh và lưu đường dẫn
                if (imageFile != null && imageFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine("wwwroot", "img", "product");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }


                    var imagePath = Path.Combine(uploadsFolder, Guid.NewGuid().ToString() + "_" + imageFile.FileName);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    // Lưu đường dẫn vào trường Image của mô hình Student
                    model.Image = "/img/product/" + Path.GetFileName(imagePath);
                }

                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Trả về View nếu dữ liệu không hợp lệ
            return View(model);
        }


        public IActionResult Edit()
        {
            return View();
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Student model, IFormFile imageFile)
        {
            if (true)
            {
                // Xử lý tệp tin ảnh và lưu đường dẫn
                if (imageFile != null && imageFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine("wwwroot", "img", "product");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }


                    var imagePath = Path.Combine(uploadsFolder, Guid.NewGuid().ToString() + "_" + imageFile.FileName);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    // Lưu đường dẫn vào trường Image của mô hình Student
                    model.Image = "/img/product/" + Path.GetFileName(imagePath);
                }

                _context.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Trả về View nếu dữ liệu không hợp lệ
            return View(model);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Student == null)
            {
                return Problem("Entity set 'StudentContext.Student'  is null.");
            }
            var student = await _context.Student.FindAsync(id);
            if (student != null)
            {
                _context.Student.Remove(student);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
          return (_context.Student?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
