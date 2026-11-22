using System.Data;
using System.Security.Cryptography;
using System.Text;
using OnlineShoppingSystem.Models;

namespace OnlineShoppingSystem.Controllers
{
    public class UserController
    {
        private readonly UserRepository _repository = new UserRepository();

        public DataTable GetUsers() => _repository.GetAll();

        public DataTable GetCustomers() => _repository.GetCustomers();

        public DataTable SearchUsers(string keyword) => _repository.Search(keyword.Trim());

        public User Login(string email, string password)
        {
            if (email.Trim() == "" || password == "")
                throw new ArgumentException("Enter email and password.");

            User user = _repository.Login(email.Trim(), HashPassword(password));
            if (user == null)
                throw new ArgumentException("Wrong email or password.");
            return user;
        }

        public void AddUser(User user)
        {
            Validate(user);
            if (user.Password == "")
                throw new ArgumentException("Password is required.");
            user.Password = HashPassword(user.Password);
            _repository.Insert(user);
        }

        public void EditUser(User user)
        {
            if (user.UserId <= 0)
                throw new ArgumentException("Select a user before updating.");
            Validate(user);
            if (user.Password != "")
                user.Password = HashPassword(user.Password);
            _repository.Update(user);
        }

        public void RemoveUser(int userId)
        {
            if (userId <= 0)
                throw new ArgumentException("Select a user before deleting.");
            _repository.Delete(userId);
        }

        private static void Validate(User user)
        {
            if (user.FullName == "" || user.Email == "")
                throw new ArgumentException("Full name and email are required.");
            if (!user.Email.Contains("@"))
                throw new ArgumentException("Enter a valid email.");
            if (user.Role != "Admin" && user.Role != "Customer")
                throw new ArgumentException("Choose a role.");
        }

        // Passwords are saved as SHA-256 hash (same as SHA2(...,256) in MySQL)
        private static string HashPassword(string password)
        {
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            return Convert.ToHexString(bytes).ToLower();
        }
    }
}
