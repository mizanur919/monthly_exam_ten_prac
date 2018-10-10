using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class MyNewsInfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        NewsInfoContext myCtx;
        public MyNewsInfoController(NewsInfoContext ctx)
        {
            myCtx = ctx;
        }

        // Get
        public IActionResult Get() {
            return Json(myCtx.NewsInfos.ToList());
        }

        // Create 
        [HttpPost]
        public IActionResult Create([FromBody]NewsInfoVM vm)
        {
            NewsInfo nw = new NewsInfo();
            nw.title = vm.title;
            nw.description = vm.description;
            myCtx.NewsInfos.Add(nw);
            myCtx.SaveChanges();
            return Json(true);
        }

        // Edit
        [HttpPost]
        public IActionResult Edit(int id, [FromBody]NewsInfo nw)
        {
            var a = (from n in myCtx.NewsInfos where id == n.id select n).First();
            a.id = nw.id;
            a.title = nw.title;
            a.description = nw.description;
            myCtx.SaveChanges();
            return Json(true);
        }

        // Delete
        public IActionResult Delete(int id) {
            var nw = myCtx.NewsInfos.Remove(myCtx.NewsInfos.Find(id));
            myCtx.SaveChanges();
            return Json(true);
        }
    }
}