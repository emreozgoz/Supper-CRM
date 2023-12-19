using System.ComponentModel.DataAnnotations;

namespace SupperCRM.Models
{

    public class CreateUserModel
    {
        [Display(Name = "Ad Soyad / Şirket Adı")]
        [Required(ErrorMessage = "{0} zorunludur"), StringLength(60, ErrorMessage = "{0} alanı en fazla {1} karakter olabilir")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} zorunludur"), StringLength(60, ErrorMessage = "{0} alanı en fazla {1} karakter olabilir")]
        [EmailAddress(ErrorMessage = "Geçerli bir Eposta girin")]
        public string Email { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} zorunludur"), StringLength(16,MinimumLength =6, ErrorMessage = "{0} alanı en az {2} karakter olabilir")]
        public string Password { get; set; }
        [Required, StringLength(100)]
        public string rePassword { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} zorunludur"), StringLength(25, ErrorMessage = "{0} alanı en fazla {1} karakter olabilir")]
        public string Username { get; set; }
        [Required, StringLength(20)]
        public string Role { get; set; }
        public bool Locked { get; set; }
    }


    public abstract class CustomerBaseModel
    {
        [Display(Name = "Ad Soyad / Şirket Adı")]
        [Required(ErrorMessage = "{0} zorunludur"), StringLength(60, ErrorMessage = "{0} alanı en fazla {1} karakter olabilir")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} zorunludur"), StringLength(60, ErrorMessage = "{0} alanı en fazla {1} karakter olabilir")]
        [EmailAddress(ErrorMessage = "Geçerli bir Eposta girin")]
        public string Email { get; set; }
        [Display(Name = "Telefon")]
        [StringLength(25, ErrorMessage = "{0} alanı en fazla {1} karakter olabilir")]
        public string Phone { get; set; }
        [Display(Name = "Description")]
        [StringLength(500, ErrorMessage = "{0} alanı en fazla {1} karakter olabilir")]
        public string Description { get; set; }
        public bool Locked { get; set; }
        public bool isCorporate { get; set; }
    }

    public class CreateCustomerModel : CustomerBaseModel
    {
       
    }

    public class EditCustomerModel : CustomerBaseModel
    {
       
    }
}