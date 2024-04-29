using System.ComponentModel.DataAnnotations;

namespace To_Do_List_API.Models
{
    public class User
    {
        public Guid Id { get; set; } = new Guid();
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;

        public User(string username, string password, string email)
        {
            Id = Guid.NewGuid();
            Username = username;
            Password = password;
            Email = email;
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }

        public User(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Password = user.Password;
            Email = user.Email;
            CreateDate = user.CreateDate;
            UpdateDate = user.UpdateDate;
        }
    }
}
