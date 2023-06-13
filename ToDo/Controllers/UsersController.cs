using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repo.Interfaces;
using Services.Implementation;
using Services.Interfaces;

namespace ToDo.Controllers
{
    public class UsersController : Controller
    {


        private IUserService _UserService;

        public UsersController(IUserService _UserService)
        {
            this._UserService = _UserService;

        }


        // GET: UsersController
        public ActionResult Index()
        {
            return View();
        }




        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User u)
        {
            var user = _UserService.GetUserByUserName(u.UserName);
            if (user != null && user.Pass == u.Pass)
            {
                HttpContext.Session.SetString("demo", JsonConvert.SerializeObject(user));
                return RedirectToAction("Index", "ToDoList", user);
            }
            return View();
        }


        // POST: CustomerController/Create

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User u)
        {
            try
            {
                _UserService.CreateUser(u);
                return RedirectToAction(nameof(Login));
            }
            catch
            {
                return View();
            }
        }

        

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            var u = HttpContext.Session.GetString("demo");
            var d = JsonConvert.DeserializeObject<User>(u);
            return View(d);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersController/Delete/5
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
    }
}
