using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModalCRUD.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = null!;


        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = null!;


        [NotMapped]
        [Required(ErrorMessage = "Password is required")]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
