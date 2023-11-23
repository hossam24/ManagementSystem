using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManagementSystem.Models
{
    public class ViewModel
    {
        public Employee Employee { get; set; }
        public List<SelectListItem> Departments { get; set; }
        public List<SelectListItem> Branches { get; set; }
    }
}
