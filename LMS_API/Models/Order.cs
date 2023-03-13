namespace LMS_API.Models
{
    public class Order : ModelBase
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int BookId { get; set; }
        public string BookName { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public int Returned { get; set; }
    }
}
