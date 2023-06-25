namespace UserAPI.Models
{
    public class UserCreateDto
    {
        
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int? Quantity { get; set; }
        public string? UserCreated { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool DelFlag { get; set; }
        
    }
}
