using CrypDrone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CrypDrone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DronesController dronesController;

        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            dronesController = new DronesController(memoryCache) { ControllerContext = ControllerContext };
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(string id)
        {
            List<Drone> droneList = dronesController.Get() as List<Drone>;
            return View(droneList.Find(drone => drone.droneId == id));
        }

        public IActionResult Drone()
        {
            List<Drone> droneList = dronesController.Get() as List<Drone>;
            return View(droneList);
        }

        public IActionResult Edit(string id)
        {
            List<Drone> droneList = dronesController.Get() as List<Drone>;
            return View(droneList.Find(drone => drone.droneId == id));
        }

        [HttpPost]
        public IActionResult Edit(Drone drone)
        {
            dronesController.Put(drone.droneId, drone);
            return RedirectToAction(nameof(Drone));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Drone drone)
        {
            dronesController.Post(drone);
            return RedirectToAction(nameof(Drone));
        }

        public IActionResult Delete(string id)
        {
            List<Drone> droneList = dronesController.Get() as List<Drone>;
            return View(droneList.Find(drone => drone.droneId == id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            dronesController.Delete(id);
            return RedirectToAction(nameof(Drone));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
