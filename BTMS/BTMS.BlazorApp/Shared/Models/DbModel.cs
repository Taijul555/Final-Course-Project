using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTMS.BlazorApp.Shared.Models
{
    public enum BusType { Ac = 1, NonAc, Sleeper, DoubleDecker, Luxury }
    public enum SeatStatus { Available = 1, Booked, Selected }
    public enum PaymentStatus { Pending = 1, Completed, Failed, Cancelled, Refunded }
    public enum FareType { Regular=1, PickSeason, Special }
    public class Bus
    {
        public int BusId { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; } = default!;
        [Required, StringLength(50)]
        public string Number { get; set; } = default!;
        [Required, EnumDataType(typeof(BusType))]
        public BusType BusType { get; set; }
        [Required]
        public  int? Capacity { get; set; }
        [Required, StringLength(120)]
        public string Picture { get; set; }=default!;
        //navigation
        public virtual ICollection<BusSchedule> Schedules { get; set;}= new List<BusSchedule>();

        
    }
    public class BusRoute
    {
        public int BusRouteId { get; set; }


        [Required, StringLength(100)]
        public string From { get; set; } = default!;//From

        [Required, StringLength(80)]
        public string To { get; set; } = default!;//To
        [Required]
        public int? ApproximateDistance {get;set;}
        [Required]
        public int? ApproximateJourneyHour { get; set; }

        //
        public virtual ICollection<Fare> Fares { get; set; } = new List<Fare>();
        public virtual ICollection<BusSchedule> Schedules { get; set; }= new List<BusSchedule>();
    }
    public class Fare
    {
        public int FareId { get; set; }
        [Required, ForeignKey("BusRoute")]        
        public int BusRouteId { get; set; }
        [Required, Column(TypeName ="money")]
        public decimal SeatFare { get; set; }
        [Required, EnumDataType(typeof(BusType))]
        public BusType BusType { get;set; }
        [Required, EnumDataType(typeof(FareType))]
        public FareType FareType { get; set; }
        public bool IsActive { get; set; }
        //navigation
        public virtual BusRoute? BusRoute { get; set; }

    }
    public class BusSchedule
    {
        public int BusScheduleId { get; set; }
        [Required, Column(TypeName ="date")]
        public DateTime? Date { get; set; }
        [Required, Column(TypeName ="time")]
        public TimeSpan? Time { get; set; }
        [Required, ForeignKey("Bus")]
        public int BusRouteId { get; set; }
        [Required, ForeignKey("BusRoute")]
        public int BusId { get; set; }
        //navigation
        public virtual Bus? Bus { get; set; }
        public virtual BusRoute? BusRoute { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }= new List<Booking>();
    }
    public class Passenger
    {
        public int PassengerId { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; } = default!;
        
        [Required, StringLength(50)]
        public string PhoneNumber { get; set; } = default!;
        [Required, StringLength(50)]
        public string Email { get; set; } = default!;
        //navigation property for mapping
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
    public class Agent
    {
        public int AgentId { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } = default!;
        [StringLength(100)]
        public string Email { get; set; } = default!;
        [StringLength(150)]
        public string Address { get; set; } = default!;
        [Required, StringLength(100)]
        public string PhoneNumber { get; set; } = default!;
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
    public class Booking
    {
        public int BookingId { get; set; }
        [Required, ForeignKey("Passenger")]
        public int PassengerId { get; set; }
        [Required, ForeignKey("BusSchedule")]
        public int ScheduleId { get; set; }
        [Required, StringLength(100)]
        public string SeatNumber { get; set; } = default!;
        
        public Passenger? Passenger { get; set; } = default!;
        public BusSchedule? BusSchedule { get; set; } = default!;   
       
    }
    public class BusDbContext : DbContext
    {
        public BusDbContext(DbContextOptions<BusDbContext> options) : base(options) { }
        public DbSet<Bus> Buses { get; set; } = default!;
        public DbSet<BusRoute> BusRoutes { get; set; } = default!;
        public DbSet<Fare> Fares { get; set; } = default!;
        public DbSet<BusSchedule> Schedules { get; set; } = default!;
        public DbSet<Passenger> Passengers { get; set; } = default!;
        public DbSet<Agent> Agents { get; set; } = default!;
        public DbSet<Booking> Bookings { get; set; } = default!;
    }
    


}
