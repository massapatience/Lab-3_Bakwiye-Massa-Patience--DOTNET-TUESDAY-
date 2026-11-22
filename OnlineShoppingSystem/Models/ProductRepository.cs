using System.Data;
using MySqlConnector;

namespace OnlineShoppingSystem.Models
{
    public class ProductRepository
    {
        private const string SelectSql =
            @"SELECT p.product_id, p.category_id, c.category_name, p.product_name,
                     p.description, p.price, p.quantity, p.image
              FROM Products p
              JOIN Categories c ON p.category_id = c.category_id";

        public DataTable GetAll()
        {
            string sql = SelectSql + " ORDER BY p.product_id";
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
            string sql = SelectSql + @" WHERE p.product_name LIKE @key OR c.category_name LIKE @key
                                        ORDER BY p.product_id";
            using var con = new MySqlConnection(Db.ConnectionString);
            using var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@key", "%" + keyword + "%");
            con.Open();
            using var reader = cmd.ExecuteReader();
            var table = new DataTable();
            table.Load(reader);
            return table;
        }

        public void Insert(Product product)
        {
            string sql = @"INSERT INTO Products (category_id, product_name, description, price, quantity, image)
                           VALUES (@cat, @name, @desc, @price, @qty, @image)";
            using var con = new MySqlConnection(Db.ConnectionString);
            using var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@cat", product.CategoryId);
            cmd.Parameters.AddWithValue("@name", product.ProductName);
            cmd.Parameters.AddWithValue("@desc", product.Description);
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.Parameters.AddWithValue("@qty", product.Quantity);
            cmd.Parameters.AddWithValue("@image", product.Image);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        public void Update(Product product)
        {
            string sql = @"UPDATE Products SET category_id=@cat, product_name=@name, description=@desc,
                           price=@price, quantity=@qty, image=@image
                           WHERE product_id=@id";
            using var con = new MySqlConnection(Db.ConnectionString);
            using var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@cat", product.CategoryId);
            cmd.Parameters.AddWithValue("@name", product.ProductName);
            cmd.Parameters.AddWithValue("@desc", product.Description);
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.Parameters.AddWithValue("@qty", product.Quantity);
            cmd.Parameters.AddWithValue("@image", product.Image);
            cmd.Parameters.AddWithValue("@id", product.ProductId);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        public void Delete(int productId)
        {
            string sql = "DELETE FROM Products WHERE product_id=@id";
            using var con = new MySqlConnection(Db.ConnectionString);
            using var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", productId);
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
