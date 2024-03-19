using BTMS.BlazorApp.Shared.Models;

namespace BTMS.Web.ViewModels
{
    public class BusDataViewModel
    {
        public int BusId {  get; set; }
        public int BusRouteId {  get; set; }
        public BusType BusType { get; set; }
        public decimal Fare {  get; set; }  
        public int SeatCount {  get; set; }

        public List<Booking> Bookings { get; set; }= new List<Booking>();
    }
}
