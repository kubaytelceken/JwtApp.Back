using System.ComponentModel.DataAnnotations;

namespace JwtApp.Front.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Şifre Boş Geçilemez")]
        public string? Password { get; set; }
    }
}
