using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LucyCalender.Models;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Extensions.Hosting;

namespace LucyCalender.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IHostingEnvironment _hostingEnvironment;

        public HomeController(ILogger<HomeController> logger, IHostingEnvironment environment)
        {
            _logger = logger;
            _hostingEnvironment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Add() 
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var body = reader.ReadToEndAsync().Result;
                var events = JsonConvert.DeserializeObject<List<Event>>(body);

                foreach (var entry in events) {
                    AddEvent(entry);
                }

                return Json(LoadEvent());
            }
        }

        public IActionResult Get()
        {
            return Json(LoadEvent());
        }

        public IActionResult Update()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var body = reader.ReadToEndAsync().Result;
                var events = JsonConvert.DeserializeObject<List<Event>>(body);
                UpdateEvent(events);
            }
            return Ok();
        }

        public IActionResult Delete()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var body = reader.ReadToEndAsync().Result;
                var events = JsonConvert.DeserializeObject<Event>(body);
                DeleteEvent(events.id);
            }
            return Json("sucess");
        }












        private void DeleteEvent(int Id)
        {
            using (var db = new EventContext())
            {
                var remove = db.Events.FirstOrDefault(e => e.id == Id);
                if (remove == null) {
                    return;
                }

                db.Events.Remove(remove);
                db.SaveChanges();
            }
        }

        private List<Event> LoadEvent()
        {
            using (var db = new EventContext())
            {
                return db.Events.ToList();
            }
        }

        private Event AddEvent(Event eventIn)
        {
            using (var db = new EventContext())
            {
                if (eventIn.id != 0)
                {
                    return UpdateEvent(eventIn);
                }
                else {
                    var added = db.Events.Add(eventIn);
                    db.SaveChanges();

                    return added.Entity;
                }
            }
        }

        private void UpdateEvent(List<Event> events)
        {
            foreach (var entry in events)
            {
                UpdateEvent(entry);
            }
        }

        private Event UpdateEvent(Event eventIn) {
            using (var db = new EventContext())
            {
                var edit = db.Events.First(e => e.id == eventIn.id);

                edit.start = eventIn.start;
                edit.end = eventIn.end;
                edit.eventColor = eventIn.eventColor;
                edit.backgroundColor = eventIn.backgroundColor;
                edit.borderColor = eventIn.borderColor;
                edit.title = eventIn.title;

                var track = db.Events.Update(edit);
                db.SaveChanges();

                return track.Entity;
            }
        }

    }
}
