using Microsoft.AspNetCore.Mvc;
using StudentData.Data;
using StudentData.Models;

namespace StudentData.Controllers
{
    public class student : Controller
    {
        private readonly AppDbContext _appDbContext;

        public student(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(Student obj)
        {
            _appDbContext.Add(obj);
            _appDbContext.SaveChanges();
            return RedirectToAction("logindesign","Login");
        }

      

    }
}
