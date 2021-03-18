using BidWeb.Conversion;
using BidWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BidWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //created Index action to get list of employees and display on the report view
            ExecuteConversion execConv = new ExecuteConversion();
            //gets employee list
            var list = execConv.GetEmployees();
            var empList = new List<Employee>();
            foreach(var item in list)
            {
                //mapping employee list to BidWeb model  
                var emp = new Employee();
                emp.id = item.id;
                emp.firstname = item.firstname;
                emp.surname = item.surname;
                emp.email = item.email;
                emp.gender = item.gender;
                emp.ip = item.ip;
                empList.Add(emp);
            }            
            //pass BidWeb model to View
            return View(empList.ToList());
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
    }
}
