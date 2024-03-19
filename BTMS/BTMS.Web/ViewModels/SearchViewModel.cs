using System.ComponentModel.DataAnnotations;

namespace BTMS.Web.ViewModels
{
    public class SearchViewModel
    {
        [Required]
        public string From { get; set; } = default!;
        [Required]
        public string To { get; set; } = default!;
        [Required]
        public DateTime? Date { get; set; }
    }
}
