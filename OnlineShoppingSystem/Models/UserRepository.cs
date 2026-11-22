using System.Data;
using MySqlConnector;

namespace OnlineShoppingSystem.Models
{
    public class UserRepository
    {
        public DataTable GetAll()
        {
            string sql = @"SELECT user_id, full_name, email, phone, address, role
                           FROM Users ORDER BY user_id";
            using var con = new MySqlConnection(Db.ConnectionString);
            using var cmd = new MySqlCommand(sql, con);
            con.Open();
            using var reader = cmd.ExecuteReader();
            var table = new DataTable();
            table.Load(reader);
            return table;
        }

        public DataTable GetCustomers()
        {
            string sql = "SELECT user_id, full_name FROM Users WHERE role = 'Customer' ORDER BY full_name";
            using var con = new MySqlConnection(Db.ConnectionString);
            using var cmd = new MySqlCommand(sql, con);
            con.Open();
            using var reader = cmd.ExecuteReader();
            var table = new DataTable();
            table.Load(reader);
            return table;
        }

        public DataTable Search(string keyword)
        {
            string sql = @"SELECT user_id, full_name, email, phone, address, role
                           FROM Users
                           WHERE full_name LIKE @key OR email LIKE @key OR role LIKE @key
                           ORDER BY user_id";
            using var con = new MySqlConnection(Db.ConnectionString);
            using var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@key", "%" + keyword + "%");
            con.Open();
            using var reader = cmd.ExecuteReader();
            var table = new DataTable();
            table.Load(reader);
            return table;
        }

        // Returns the user if email and (hashed) password match, otherwise null
        public User Login(string email, string hashedPassword)
        {
            string sql = @"SELECT user_id, full_name, email, role FROM Users
                           WHERE email = @email AND password = @pass";
            using var con = new MySqlConnection(Db.ConnectionString);
            using var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@pass", hashedPassword);
            con.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new User
                {
                    UserId = Convert.ToInt32(reader["user_id"]),
                    FullName = reader["full_name"].ToString(),
                    Email = reader["email"].ToString(),
                    Role = reader["role"].ToString()
                };
            }
            return null;
        }

        public void Insert(User user)
        {
            string sql = @"INSERT INTO Users (full_name, email, password, phone, address, role)
                           VALUES (@name, @email, @pass, @phone, @address, @role)";
            using var con = new MySqlConnection(Db.ConnectionString);
            using var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@name", user.FullName);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@pass", user.Password);
            cmd.Parameters.AddWithValue("@phone", user.Phone);
            cmd.Parameters.AddWithValue("@address", user.Address);
            cmd.Parameters.AddWithValue("@role", user.Role);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        // If Password is empty, the old password is kept
        public void Update(User user)
        {
            string sql = @"UPDATE Users SET full_name=@name, email=@email, phone=@phone,
                           address=@address, role=@role";
            if (user.Password != "")
                sql += ", password=@pass";
            sql += " WHERE user_id=@id";

            using var con = new MySqlConnection(Db.ConnectionString);
            using var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@name", user.FullName);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@phone", user.Phone);
            cmd.Parameters.AddWithValue("@address", user.Address);
            cmd.Parameters.AddWithValue("@role", user.Role);
            cmd.Parameters.AddWithValue("@pass", user.Password);
            cmd.Parameters.AddWithValue("@id", user.UserId);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        public void Delete(int userId)
        {
            string sql = "DELETE FROM Users WHERE user_id=@id";
            using var con = new MySqlConnection(Db.ConnectionString);
            using var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", userId);
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
