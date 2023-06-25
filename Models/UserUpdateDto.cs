namespace UserAPI.Models
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int? Quantity { get; set; }
        public string? UserModified { get; set; }
        public DateTime? DateModified { get; set; }
        public bool DelFlag { get; set; }
    }
}
