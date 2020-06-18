using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListContact.Models;
using ListContact.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ListContact.Controllers
{
    public class TodoController : Controller
    {
        //public static List<Todo> Todos { get; set; } = new List<Todo>();
        private TodoRepository TodoRepository { get; set; }

        public TodoController(TodoRepository todoRepository) { this.TodoRepository = todoRepository; }


        public IActionResult Index(string? message)
        {
            var result = this.TodoRepository.GetAll();
            ViewBag.message = message;

            //List<Todo> todos = new List<Todo>();

            //todos.Add(new Todo()
            //{
            //    Name = "TP1",
            //    Finished = true
            //});

            //todos.Add(new Todo()
            //{
            //    Name = "TP3",
            //    Finished = false
            //});

            //todos.Add(new Todo()
            //{
            //    Name = "AT",
            //    Finished = false
            //});

            return View(result);
        }

        public IActionResult New()
        {
            return View();
        }

        public IActionResult Edit([FromQuery] Guid id)
        {
            //var todo = Todos.Where(x => x.Id == id).FirstOrDefault();
            var todo = TodoRepository.GetById(id); 
            return View(todo);
        }

        public IActionResult Delete([FromQuery] Guid id) 
        {
            if (!ModelState.IsValid) { return View(); }
            TodoRepository.Delete(id);
            return RedirectToAction("Index", "Todo", new { message = "Task deleted." });
        }

        [HttpPost]
        public IActionResult Save(Todo model)
        {
            if (!ModelState.IsValid) { return View(); }
            model.Id = Guid.NewGuid();
            TodoRepository.Save(model);
            //Todos.Add(model);
            return RedirectToAction("Index", "Todo", new { message = "Task added." });
        }

        [HttpPost]
        public IActionResult SaveEdit(Guid id, Todo model)
        {
            if (!ModelState.IsValid) { return View(); }

            var todoEdit = TodoRepository.GetById(id);
            todoEdit.Name = model.Name;
            todoEdit.Finished = model.Finished;

            TodoRepository.Update(todoEdit);

            //var todoEdit = Todos.Where(x => x.Id == id).FirstOrDefault();
            //todoEdit.Name = model.Name;
            //todoEdit.Finished = model.Finished;

            //Todos.Remove(todoEdit);
            //Todos.Add(todoEdit);

            return RedirectToAction("Index", "Todo", new { message = "Task edited." });
        }
    }
}