

namespace Domain
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get;set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = true;
        public UserProfile UserProfile { get; set; }

    }
}
