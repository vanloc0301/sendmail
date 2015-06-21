using System.ComponentModel.DataAnnotations;

namespace SendMailMVC.Models
{
    public class EmailFormModel
    {
        [Required, Display(Name="Họ Tên:")]
        public string FromName { get; set; }

        [Required, Display(Name="Email của bạn"), EmailAddress]
        public string FromEmail { get; set; }

        [Required]
        public string Message { get; set; }
    }
}