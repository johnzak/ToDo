using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Interfaces;
using System.Collections.Generic;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class ToDoItemController : Controller
    {
        private IToDoItemService _ToDoItemService;
        public ToDoItemController(IToDoItemService _ToDoItemService)
        {
            this._ToDoItemService = _ToDoItemService;
        }
        // GET: HomeController1
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }


        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController1/Create
        [HttpGet]
        public ActionResult Create(int ToDoListId)
        {


            ClassModel cm = new ClassModel();

            if (ToDoListId != 0) { 
            cm.ToDoListID = ToDoListId;
            }

            return View(cm);
        }


        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClassModel cm)
        {
            try
            {

                ToDoItem toDoItem = new ToDoItem();

                toDoItem.Data = cm.Data;
                toDoItem.Checked = cm.Checked;
                toDoItem.Priority = cm.Priority;
                toDoItem.ToDoListID = cm.ToDoListID;
                toDoItem.DateCreated = DateTime.Now.ToString("MMM d yyyy h:mm tt");
                _ToDoItemService.CreateToDoItem(toDoItem);

                return RedirectToAction("ViewToDoItems", "ToDoItem", new { ListId = toDoItem.ToDoListID });
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ViewToDoItems(int ListId)
        {
            List<ToDoItem> tdi = _ToDoItemService.GetAllToDoItemsByListId(ListId);

            return View(tdi);
        }


        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {

            ToDoItem toDoItem = _ToDoItemService.GetToDoItemByItemId(id);

            ClassModel cm2 = new ClassModel();

            cm2.ToDoListID = toDoItem.ToDoListID;
            cm2.DateCreated = toDoItem.DateCreated;
            cm2.Id = id;



            return View(cm2);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClassModel cm2)
        {
            try
            {

                ToDoItem tdi = _ToDoItemService.GetToDoItemByItemId(cm2.Id);
                
                tdi.Priority = cm2.Priority;
                tdi.Data = cm2.Data;
                tdi.Checked = cm2.Checked;
                _ToDoItemService.UpdateToDoItem(tdi);
                return RedirectToAction("ViewToDoItems", "ToDoItem", new { ListId = tdi.ToDoListID });
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            int ToDoListId = _ToDoItemService.GetToDoItemByItemId(id).ToDoListID;
            _ToDoItemService.DeleteToDoItem(id);

            return RedirectToAction("ViewToDoItems", "ToDoItem", new { ListId = id });
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Check(int id)
        {
            _ToDoItemService.Check(id);

            var lstid = _ToDoItemService.GetToDoItemByItemId(id).ToDoListID;


            return RedirectToAction("ViewToDoItems", "ToDoItem", new { ListId = lstid });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Check(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }


}
