using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentData.Data;
using StudentData.Models;

namespace StudentData.Controllers
{
    public class Login: Controller
    {
        private readonly AppDbContext _appDbContext;
        public Login(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            StudentLogin login = new StudentLogin();
            return View(login);
        }
        //[HttpPost]
        public IActionResult logindesign(StudentLogin obj)
        {
            var status = _appDbContext.student.Where(m => m.Email == obj.Email && m.Password == obj.Password).FirstOrDefault();
            if (status == null)
            {
                ViewBag.LoginStatus = 0;
                //errorMessageLabel.Text = "Invalid username or password.";
            }
            else
            {
                Response.Cookies.Append("Id", status.Id.ToString());
                Response.Cookies.Append("Name", status.Name);
                Response.Cookies.Append("Email", status.Email);

                return RedirectToAction("StudentDashboard", "Login");
            }
            return View(obj);
        }
        



        public IActionResult StudentDashboard()
        {
            string Id = Request.Cookies["Id"];
            string Name = Request.Cookies["Name"];
            string Email = Request.Cookies["Email"];
            
            ViewData["Id"] = Id;
            ViewData["Name"] = Name;
            ViewData["Email"] = Email;

            List<url>c=_appDbContext.url.ToList();
       

            return View(c);
        }

        [HttpGet]
        public IActionResult ChangeProfile()
        {
            string Id = Request.Cookies["Id"];
            var user= _appDbContext.Students.FirstOrDefault(n=>n.Id.ToString() == Id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult ChangeProfile(Student obj)
        {
            if (!ModelState.IsValid) { 
                return View(obj);   

            
            }
            
            _appDbContext.Update(obj);
            _appDbContext.SaveChanges();
            Response.Cookies.Delete("");
            Response.Cookies.Append("Name", obj.Name);
            //Response.Cookies.Delete("");
            Response.Cookies.Append("Email", obj.Email);
            //Console.WriteLine(obj.Name);
            //Console.ReadLine();
            return RedirectToAction("StudentDashboard","Login");
        }

    }
}
