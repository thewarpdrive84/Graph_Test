using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Test_Chart.Models;

namespace Test_Chart.Controllers
{
    public class PointsController : Controller
    {
        private readonly DataPointsDB _db;

        public PointsController(DataPointsDB db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Point> objList = _db.Points;
            return View(objList);
        }

        public IActionResult Create()
        {
            ViewData["x"] = new SelectList(_db.Points, "x", "y");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("x,y")] Point point)
        {
            if (ModelState.IsValid)
            {
                _db.Add(point);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["x"] = new SelectList(_db.Points, "x", "y", point.x);
            return View(point);
        }

        // GET: HowTo
        public ActionResult DataFromDataBase()
        {
            try
            {
                ViewBag.DataPoints = JsonConvert.SerializeObject(_db.Points.ToList(), _jsonSetting);

                return View();
            }
            catch (EntityException)
            {
                return View("Error");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return View("Error");
            }
        }

        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };


    }
}
