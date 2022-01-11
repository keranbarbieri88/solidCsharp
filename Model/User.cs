using System.ComponentModel.DataAnnotations;


namespace solidCsharp.Model
{
    public class User
    {
        [Key]
        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

    }
}
