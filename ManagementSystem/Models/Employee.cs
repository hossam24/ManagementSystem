using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Sex { get; set; }
        [Required]
        [StringLength(14),MinLength(14)]
        public string national_Id { get; set; }
        public decimal salpermonth { get; set; }
        public int UseEntry { get; set; }
        public DateTime Birth_date { get; set; }
        public DateTime entrydata { get; set; }
        [ForeignKey("bran")]
        public int branchcode { get; set; }
        [ForeignKey("Dept")]

        public int deptId { get; set; }

        virtual public Department ?Dept { get; set; }
        virtual public Branch ?bran { get; set; }



    }
}
