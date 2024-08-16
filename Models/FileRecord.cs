using System.ComponentModel.DataAnnotations;

namespace FileApprovalSystem.Models
{
    public class FileRecord
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "File Number is required")]
        [StringLength(20, ErrorMessage = "File Number cannot be longer than 20 characters")]
        public string FileNumber { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        [StringLength(100, ErrorMessage = "Subject cannot be longer than 100 characters")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "File Presenter is required")]
        public string FilePresenter { get; set; }

        [Required(ErrorMessage = "File Status is required")]
        public string FileStatus { get; set; } = "Created";

        [Required(ErrorMessage = "File Date is required")]
        public DateTime FileDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "File Category is required")]
        public string FileCategory { get; set; }

        [Required(ErrorMessage = "Responsible Employee is required")]
        public string ResponsibleEmployee { get; set; }

        [Range(1, 3, ErrorMessage = "Approval Stage must be between 1 and 3")]
        public int ApprovalStage { get; set; } = 1;

        [StringLength(255, ErrorMessage = "Uploaded File Path cannot be longer than 255 characters")]
        public string? UploadedFilePath { get; set; }
    }
}
