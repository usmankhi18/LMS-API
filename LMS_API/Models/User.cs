namespace LMS_API.Models
{
    public class User : ModelBase
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string University { get; set; } = string.Empty;
        public string LogoPath { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsBlocked { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public float Fine { get; set; } = 0;
        public UserType UserType { get; set; }
        public string AddedOn { get; set; } = string.Empty;
    }
}
