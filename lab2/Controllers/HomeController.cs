using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lab2.Models;

namespace lab2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
 
        public IActionResult Manual()
        {
            if (Request.Method == "POST")
            {
                string firstNumberString = Request.Form["firstNumber"];
                int firstNumber = Int32.Parse(firstNumberString);
                ViewData["firstNumber"] = firstNumber;
                string secondNumberString = Request.Form["secondNumber"];
                int secondNumber = Int32.Parse(secondNumberString);
                ViewData["secondNumber"] = secondNumber;
                string operation = Request.Form["operation"];
                ViewData["operation"] = operation;
                Calc calc = new Calc(firstNumber, secondNumber, operation);
                ViewData["result"] = calc.FindSolution();
                return View();
            }
            else
            {
                return View();
            }
        }

        public IActionResult ManualWithSeparateHandlers()
        {
            return View();
        }
        
        [HttpPost]
        [ActionName("ManualWithSeparateHandlers")]
        public IActionResult ManualWithSeparateHandlersPost()
        {
            string firstNumberString = Request.Form["firstNumber"];
            int firstNumber = Int32.Parse(firstNumberString);
            ViewData["firstNumber"] = firstNumber;
            string secondNumberString = Request.Form["secondNumber"];
            int secondNumber = Int32.Parse(secondNumberString);
            ViewData["secondNumber"] = secondNumber;
            string operation = Request.Form["operation"];
            ViewData["operation"] = operation;
            Calc calc = new Calc(firstNumber, secondNumber, operation);
            ViewData["result"] = calc.FindSolution();
            return View();
        }

        public IActionResult ModelBindingInParameters()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ModelBindingInParameters(double firstNumber, string operation, double secondNumber)
        {
            ViewData["firstNumber"] = firstNumber;
            ViewData["secondNumber"] = secondNumber;
            ViewData["operation"] = operation;
            Calc calc = new Calc(firstNumber, secondNumber, operation);
            ViewData["result"] = calc.FindSolution();
            return View();
        }

        public IActionResult ModelBindingInSeparateModel()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ModelBindingInSeparateModel(Calc calc)
        {
            ViewData["firstNumber"] = calc.firstNumber;
            ViewData["secondNumber"] = calc.secondNumber;
            ViewData["operation"] = calc.operation;
            ViewData["result"] = calc.FindSolution();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
