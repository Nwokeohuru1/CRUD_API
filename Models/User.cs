using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int? Quantity { get; set; }
        public string? UserCreated { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool DelFlag { get; set; }
        public string? UserModified { get; set; }
        public DateTime? DateModified { get; set; }

    }
}

