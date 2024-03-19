using BTMS.BlazorApp.Shared.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTMS.Web.ViewModels
{
    public class SearchResultViewModel
    {
        public int BusId { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; } = default!;
        [Required, StringLength(50)]
        public string Number { get; set; } = default!;
        [Required, EnumDataType(typeof(BusType))]
        public BusType BusType { get; set; }
        [Required]
        public int? Capacity { get; set; }
        [Required, StringLength(120)]
        public int BusRouteId { get; set; }


        [Required, StringLength(100)]
        public string From { get; set; } = default!;//From

        [Required, StringLength(80)]
        public string To { get; set; } = default!;//To
        public decimal Fare { get; set; }
        public int BusScheduleId { get; set; }
        [Required, Column(TypeName = "date")]
        public DateTime? Date { get; set; }
        [Required, Column(TypeName = "time")]
        public TimeSpan? Time { get; set; }
        

    }
}

