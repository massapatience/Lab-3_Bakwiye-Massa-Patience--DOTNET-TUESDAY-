using System.Data;
using MySqlConnector;

namespace OnlineShoppingSystem.Models
{
    public class CategoryRepository
    {
        public DataTable GetAll()
        {
            string sql = "SELECT category_id, category_name, description FROM Categories ORDER BY category_id";
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
            string sql = @"SELECT category_id, category_name, description FROM Categories
                           WHERE category_name LIKE @key OR description LIKE @key
                           ORDER BY category_id";
            using var con = new MySqlConnection(Db.ConnectionString);
            using var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@key", "%" + keyword + "%");
            con.Open();
            using var reader = cmd.ExecuteReader();
            var table = new DataTable();
            table.Load(reader);
            return table;
        }

        public void Insert(Category category)
        {
            string sql = "INSERT INTO Categories (category_name, description) VALUES (@name, @desc)";
            using var con = new MySqlConnection(Db.ConnectionString);
            using var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@name", category.CategoryName);
            cmd.Parameters.AddWithValue("@desc", category.Description);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        public void Update(Category category)
        {
            string sql = "UPDATE Categories SET category_name=@name, description=@desc WHERE category_id=@id";
            using var con = new MySqlConnection(Db.ConnectionString);
            using var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@name", category.CategoryName);
            cmd.Parameters.AddWithValue("@desc", category.Description);
            cmd.Parameters.AddWithValue("@id", category.CategoryId);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        public void Delete(int categoryId)
        {
            string sql = "DELETE FROM Categories WHERE category_id=@id";
            using var con = new MySqlConnection(Db.ConnectionString);
            using var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", categoryId);
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
