using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JSONTest.Models;

namespace JSONTest.Controllers
{
    public class HomeController : Controller
    {

        ApplicationContext dbcontext;

        public HomeController(ApplicationContext context){
            dbcontext=context;
        }

        public IActionResult Index()
        {
            IndexViewModel viewModel=new IndexViewModel();
            viewModel.Persons=dbcontext.Persons.Where(p=>p.Name.Contains("s")).ToList();
            return View(viewModel);
        }

        [HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Names(string frag)
{
    var names = dbcontext.Persons.Where(x => x.Name.Contains(frag)).ToList();

    return Json(names);
}

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
