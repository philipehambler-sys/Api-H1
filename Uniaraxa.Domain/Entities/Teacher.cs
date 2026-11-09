using System.ComponentModel.DataAnnotations;

namespace Uniaraxa.Domain.Entities
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string UrlLattes { get; set; } = string.Empty;

        public DateTime DataAdmissao { get; set; }
    }
}
