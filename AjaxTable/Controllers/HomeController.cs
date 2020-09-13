using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AjaxTable.Models;

namespace AjaxTable.Controllers
{
    public class HomeController : Controller
    {
        private string _connection = @"Data Source=.\sqlexpress;Initial Catalog=People;Integrated Security=true;";
        public IActionResult Home()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(People person)
        {
            var db = new Db(_connection);
            db.Add(person);
            return Json(person);
        }
        [HttpPost]
        public IActionResult Edit(People person)
        {
            var db = new Db(_connection);
            db.Edit(person);
            return Json(person);
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var db = new Db(_connection);
            db.Delete(Id);
            return Json(Id);
        }
        public IActionResult getpeople()
        {
            var db = new Db(_connection);
            return Json(db.GetPeople());
        }
    }
}
