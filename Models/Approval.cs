using System.ComponentModel.DataAnnotations;

namespace FileApprovalSystem.Models
{
    public class Approval
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee Name is required")]
        [StringLength(100, ErrorMessage = "Employee Name cannot be longer than 100 characters")]
        public string EmployeeName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Approval Order must be a positive number")]
        public int ApprovalOrder { get; set; }

        public bool IsApproved { get; set; }
    }
}
