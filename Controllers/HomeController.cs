using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using STUDENTPORTAL.Models;

namespace STUDENTPORTAL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        FinTrakAcademyyContext context = new FinTrakAcademyyContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Index(string FirstName)
        //{
        //    return View();
        //}
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(StudentInformation student)
        {
            if (student == null)
            {
                return View();
            }
            if (ModelState.IsValid)
            {
                var existRecord = GetStaff().Where(o => o.Email.ToUpper() == student.Email.ToUpper()).Count();
                if (existRecord > 0)
                {
                    ModelState.AddModelError("", "Email has already been used");
                    return View(student);
                }
                context.StudentInformation.Add(student);
                context.SaveChanges();
                //return RedirectToAction("Details", new { Id = newEmployee.Id });
                return RedirectToAction("ViewStudent");
            }
            return View();
        }
        // Too get Student Information

        public IActionResult ViewStudent()
        {
            IEnumerable<StudentInformation> student = context.StudentInformation.ToList();
            return View(student);
        }
        //[HttpGet]
        ////public JsonResult GetStudent()
        //public IActionResult GetStudent()
        //{
        //    var result = context.StudentInformation.ToList();
        //    return Json(result);
        //}
        public IActionResult Details(int Id)
        {
            StudentInformation student = context.StudentInformation.Find(Id);
            return View(student);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            StudentInformation student = context.StudentInformation.Find(Id);

            if (student == null)

            {
                return Error();
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(StudentInformation studentChanges)
        {
            if (ModelState.IsValid)
            {
                var student = context.StudentInformation.Attach(studentChanges);
                student.State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("ViewStudent");
            }
            return View(studentChanges);
        }

        [HttpGet]
        public IActionResult DeleteStudent(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var student = context.StudentInformation.Find(Id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        //Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int StudentId)
        {
            var student = context.StudentInformation.Find(StudentId);
            context.StudentInformation.Remove(student);
            context.SaveChanges();
            return RedirectToAction("ViewStudent");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public JsonResult GetStaff()
        {
            List<Root> result = new List<Root>();
            var client = new RestClient("http://localhost/FintrakWebAPI/api/v1/weatherforecast/getemployee");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var reply = response.Content;
            List<Root> myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(response.Content);
            return Json(myDeserializedClass);
        }

        public JsonResult GetPosts()
        {
            List<Root> result = new List<Root>();
            var client = new RestClient("https://jsonplaceholder.typicode.com/posts");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var reply = response.Content;
            List<Root> myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(response.Content);
            return Json(myDeserializedClass);
        }
        public JsonResult GetComments()
        {
            List<Root> result = new List<Root>();
            var client = new RestClient("https://jsonplaceholder.typicode.com/comments");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            List<Root> myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(response.Content);
            return Json(myDeserializedClass);
        }
        public JsonResult GetAlbums()
        {
            List<Root> result = new List<Root>();
            var client = new RestClient("https://jsonplaceholder.typicode.com/albums");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            List<Root> myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(response.Content);
            return Json(myDeserializedClass);
        }
        public JsonResult GetPhotos()
        {
            List<Root> result = new List<Root>();
            var client = new RestClient("https://jsonplaceholder.typicode.com/photos");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            
            List<Root> myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(response.Content);
            return Json(myDeserializedClass);

        }


    }
}
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        
