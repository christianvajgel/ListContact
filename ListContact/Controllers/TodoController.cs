using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListContact.Models;
using Microsoft.AspNetCore.Mvc;

namespace ListContact.Controllers
{
    public class TodoController : Controller
    {
        List<Todo> todos = new List<Todo>();
        public IActionResult Index()
        {
            //List<Todo> todos = new List<Todo>();

            todos.Add(new Todo()
            {
                Name = "TP1",
                Finished = true
            });

            todos.Add(new Todo()
            {
                Name = "TP3",
                Finished = false
            });

            todos.Add(new Todo()
            {
                Name = "AT",
                Finished = false
            });

            return View(todos);
        }    
        
        public IActionResult New()
        {


            return View(todos);
        }
    }
}