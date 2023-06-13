using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Build.Framework;
using Newtonsoft.Json;
using Services.Implementation;
using Services.Interfaces;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class ToDoListController : Controller
    {

        private IToDoListService _ToDoListService;
        private IToDoItemService _ToDoItemService;
        private IUserService _UserService;


        public ToDoListController(IToDoListService _ToDoListService, IToDoItemService toDoItemService, IUserService userService)
        {

            this._ToDoListService = _ToDoListService;
            this._ToDoItemService = toDoItemService;
            this._UserService = userService;
        }

        // GET: ToDoListController
        public ActionResult Index(User user)
        {
            int usrid = user.Id;

            var list = _ToDoListService.GetToDoListByUserId(user.Id);

            return View(list);
        }

        public ActionResult ViewListsSession()
        {


            var c = HttpContext.Session.GetString("demo");
            var d = JsonConvert.DeserializeObject<User>(c);


            return RedirectToAction("Index", "ToDoList", d);

        }

        // GET: ToDoListController/Details/5
        public ActionResult Details(int id)
        {
            return RedirectToAction("ViewToDoItems", "ToDoItem", new { ListId = id });

        }

        // GET: ToDoListController/CreateI
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        // POST: ToDoListController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToDoList tdl)
        {
            try
            {

                var c = HttpContext.Session.GetString("demo");
                var d = JsonConvert.DeserializeObject<User>(c);
                tdl.UserID = d.Id;
                _ToDoListService.CreateToDoList(tdl);
                return RedirectToAction("Create", "ToDoItem", new { ToDoListId = tdl.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoListController/Edit/5
        public ActionResult Edit(int id)
        {

            ToDoList tdl = _ToDoListService.GetToDoListById(id);

            ToDoListModel model = new ToDoListModel();

            model.Id = tdl.Id;
            model.UserID = tdl.UserID;


            return View(model);


        }

        // POST: ToDoListController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ToDoListModel model)
        {
            try
            {

                ToDoList tdl = _ToDoListService.GetToDoListById(model.Id);

                tdl.ListName = model.ListName;
                tdl.PublicList = model.PublicList;
                
                _ToDoListService.UpdateToDoList(tdl);
                return RedirectToAction("ViewListsSession", "ToDoList");
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoListController/Delete/5
        public ActionResult Delete(int id)
        {

            int usrid = _ToDoListService.GetToDoListById(id).UserID;

            User usr = _UserService.GetUserById(usrid);

             List<ToDoItem> Itmz = _ToDoItemService.GetAllToDoItemsByListId(id);


            foreach (var item in Itmz)
            {
                _ToDoItemService.DeleteToDoItem(item.Id);
            }

            _ToDoListService.DeleteToDoList(id);
            int userid = usr.Id;
            return RedirectToAction("Index", "ToDoList", usr);
        }

        // POST: ToDoListController/Delete/5
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
        public ActionResult ViewPublic()
        {
            List<ToDoList>tdl = _ToDoListService.GetPublicToDoLists();
            return View(tdl);

        }

        public ActionResult ViewPublicNoLogin()
        {
            List<ToDoList> tdl = _ToDoListService.GetPublicToDoLists();
            return View(tdl);

        }


    }
}
