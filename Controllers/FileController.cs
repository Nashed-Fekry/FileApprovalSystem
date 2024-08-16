using FileApprovalSystem.Context;
using FileApprovalSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FileApprovalSystem.Controllers
{
    [Authorize]
    public class FileController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FileController(ApplicationDbContext context)
        {
            _context = context;
        }

        //View files
        public async Task<IActionResult> Index()
        {
            var files = await _context.FileRecords.ToListAsync();
            return View(files);
        }

        // Create a new file by the first employee
        [HttpGet]
        [Authorize(Roles = "Employee1")]
        public IActionResult Create()
        {
            if (User.IsInRole("Employee2") || User.IsInRole("Employee3"))
            {
                TempData["AccessDeniedMessage"] = "You do not have permission to access the Create page.";
                return RedirectToAction("AccessDenied", "Account");
            }

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Employee1")]
        public async Task<IActionResult> Create(FileRecord model, IFormFile uploadedFile)
        {
            if (User.IsInRole("Employee2") || User.IsInRole("Employee3"))
            {
                TempData["AccessDeniedMessage"] = "You do not have permission to access the Create page.";
                return RedirectToAction("AccessDenied", "Account");
            }

            if (ModelState.IsValid)
            {
                if (uploadedFile != null && uploadedFile.Length > 0)
                {
                    var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                    Directory.CreateDirectory(uploadsFolderPath);

                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + uploadedFile.FileName;
                    var filePath = Path.Combine(uploadsFolderPath, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }

                    model.UploadedFilePath = "/uploads/" + uniqueFileName;
                }

                model.FileStatus = "Created";
                model.FileDate = DateTime.Now;
                model.ApprovalStage = 1;

                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        public IActionResult Download(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return File(fileStream, "application/octet-stream", fileName);
        }

        public IActionResult Details(int id)
        {
            var file = _context.FileRecords.Find(id); 
            if (file == null)
            {
                return NotFound();
            }
            return View(file);
        }
        // File approval by the second employee
        [Authorize(Roles = "Employee2")]
        public async Task<IActionResult> ApproveByEmployee2(int id)
        {
            var file = await _context.FileRecords.FindAsync(id);
            if (file == null)
            {
                return NotFound();
            }

            file.FileStatus = "Pending"; 
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // File approval by the third employee
        [Authorize(Roles = "Employee3")]
        public async Task<IActionResult> ApproveByEmployee3(int id)
        {
            var file = await _context.FileRecords.FindAsync(id);
            if (file == null)
            {
                return NotFound();
            }

            file.FileStatus = "Approved"; 
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
