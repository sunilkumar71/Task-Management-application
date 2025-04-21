using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "User name is required")]
        public string Name { get; set; }=string.Empty;

    }
}
