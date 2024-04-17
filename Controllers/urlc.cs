using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentData.Data;
using StudentData.Models;

namespace StudentData.Controllers
{
    public class urlc : Controller
    {

        private readonly AppDbContext _appDbContext;
        public urlc(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(url obj)
        {
            _appDbContext.Add(obj);
            _appDbContext.SaveChanges();
            return RedirectToAction("StudentDashboard", "Login");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contact = await _appDbContext.url.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, url obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _appDbContext.Entry(obj).State = EntityState.Modified;
                await _appDbContext.SaveChangesAsync();
                _appDbContext.SaveChanges();
                return RedirectToAction("StudentDashboard", "Login");
            }
            return View(obj);
        }
        public IActionResult Delete(int? Id,url obj)
        {
            var user= _appDbContext.url.FirstOrDefault(c=>c.Id==obj.Id);
            _appDbContext.url.Remove(user);
            _appDbContext.SaveChanges();
            return RedirectToAction("StudentDashboard", "Login");
        }
        public async Task<IActionResult> LogOut()
        {
            return RedirectToAction("Index", "Home");
        }

    }

}
