using MyMvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MyMvcApplication.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            IEnumerable<Student> st = null;
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("");
                var responseTask = client.GetAsync("Student/GetAllStudent");
                responseTask.Wait();

                HttpResponseMessage response = responseTask.Result;

                if(response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsAsync<List<Student>>();
                    readTask.Wait();

                    st = readTask.Result;
                }
            }
            return View();
        }
    }
}