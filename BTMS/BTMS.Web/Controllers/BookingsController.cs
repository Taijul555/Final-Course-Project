using BTMS.BlazorApp.Shared.Models;
using BTMS.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace BTMS.Web.Controllers
{
    public class BookingsController : Controller
    {
        private readonly BusDbContext db;
        public BookingsController(BusDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Search(SearchViewModel data)
        {
            var routeId = db.BusRoutes.FirstOrDefault(x=> x.From == data.From &&  x.To == data.To)?.BusRouteId;
            if(routeId == null)
            {
                return NotFound();
            }
            List<BusSchedule> busSchedules = db.Schedules                   
                  
                   .Where(x=> x.BusRouteId == routeId).ToList();
            if(data.Date?.Date == DateTime.Today)

            {
                  busSchedules = busSchedules
                    
                    .Where(x=> (x.Date == DateTime.Today && x.Time > (DateTime.Today - DateTime.Now)))
                   .ToList();
                
            }
            else
            {


                 busSchedules = busSchedules
               
                    .Where(x =>x.Date == data.Date)
                   .ToList();
                
            }
           
            var modelData=busSchedules.Select(sch =>            
            new SearchResultViewModel
            {
                BusScheduleId = sch.BusScheduleId,
                BusId = sch.BusId,
                BusType = GetType(sch.BusId),
                BusRouteId = routeId.Value,
                From = GetFrom(routeId.Value),
                To = GetTo(routeId.Value),
                Date = sch.Date,
                Time = sch.Time,
                Name = sch.Bus == null ? "" : sch.Bus.Name,
                Capacity = sch.Bus == null ? 0 : sch.Bus.Capacity,
                Fare = GetFare(sch.BusRouteId, sch.BusId)
                
            }).ToList();
            return View(modelData);
        }
        public IActionResult BookSeats(int id, int busId)
      {
            var b = db.Buses.FirstOrDefault(x => x.BusId == busId);
            if (b == null) return NotFound();
            var sch = db.Schedules.FirstOrDefault(x=> x.BusScheduleId == id);
            if (sch == null) return NotFound();
            var data = new BusDataViewModel { BusId = busId, BusRouteId = id, BusType = b.BusType, SeatCount = b.Capacity == null ? 0: b.Capacity.Value };
           data.Bookings= db.Bookings.Where(x => x.ScheduleId == id).ToList();

            if(b.BusType == BusType.Sleeper || b.BusType == BusType.DoubleDecker)
            {
                var labels = Enumerable.Range((int)'A', data.SeatCount / 8).Select(x => (char)x).ToList();
                ViewBag.Labels = labels;
                return View("DoubleLayerBus", data);
            }
            else
            {
                var labels = Enumerable.Range((int)'A', data.SeatCount / 4).Select(x => (char)x).ToList();
                ViewBag.Labels=labels;
                
                return View("SingleLayerBus", data);
            }
            
        }
        public JsonResult GetDestination(string from)
        {
            var data = db.BusRoutes.Where(x=> x.From == from).Select(x=> x.To).ToList();
            return Json(data);
        }
        private decimal GetFare(int routeId, int busId)
        {
           var bus = db.Buses.First(x=> x.BusId == busId);
            var Fare = db.Fares.Where(x => x.BusType == bus.BusType && x.BusRouteId == routeId && x.IsActive).FirstOrDefault();
            return Fare == null ?  0 : Fare.SeatFare;
        }
        private string GetFrom(int RouteId)
        {
            
            var From = db.BusRoutes.First(x => x.BusRouteId== RouteId).From;
            return From;
        }
        private string GetTo(int RouteId)
        {

            var To = db.BusRoutes.First(x => x.BusRouteId == RouteId).To;
            return To;
        }
        private BusType GetType(int busId)
        {
            var t = db.Buses.First(x => x.BusId == busId).BusType;
            return t;
        }
    }
}
