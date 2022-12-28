namespace UserAPI.Data.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Quantity { get; set; }
        public string? UserCreated { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool DelFlag { get; set; }
        public string? UserModified { get; set; }
        public DateTime? DateModified { get; set; }
     
    }
}
