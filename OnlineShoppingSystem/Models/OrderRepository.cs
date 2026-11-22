using System.Data;
using MySqlConnector;

namespace OnlineShoppingSystem.Models
{
    public class OrderRepository
    {
        private const string SelectSql =
            @"SELECT o.order_id, o.user_id, u.full_name AS customer, o.order_date,
                     o.total_amount, o.order_status
              FROM Orders o
              JOIN Users u ON o.user_id = u.user_id";

        public DataTable GetAll()
        {
            string sql = SelectSql + " ORDER BY o.order_id";
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
            string sql = SelectSql + @" WHERE u.full_name LIKE @key OR o.order_status LIKE @key
                                        ORDER BY o.order_id";
            using var con = new MySqlConnection(Db.ConnectionString);
            using var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@key", "%" + keyword + "%");
            con.Open();
            using var reader = cmd.ExecuteReader();
            var table = new DataTable();
            table.Load(reader);
            return table;
        }

        public void Insert(Order order)
        {
            string sql = @"INSERT INTO Orders (user_id, order_date, total_amount, order_status)
                           VALUES (@user, @date, @total, @status)";
            using var con = new MySqlConnection(Db.ConnectionString);
            using var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@user", order.UserId);
            cmd.Parameters.AddWithValue("@date", order.OrderDate);
            cmd.Parameters.AddWithValue("@total", order.TotalAmount);
            cmd.Parameters.AddWithValue("@status", order.OrderStatus);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        public void Update(Order order)
        {
            string sql = @"UPDATE Orders SET user_id=@user, order_date=@date,
                           total_amount=@total, order_status=@status
                           WHERE order_id=@id";
            using var con = new MySqlConnection(Db.ConnectionString);
            using var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@user", order.UserId);
            cmd.Parameters.AddWithValue("@date", order.OrderDate);
            cmd.Parameters.AddWithValue("@total", order.TotalAmount);
            cmd.Parameters.AddWithValue("@status", order.OrderStatus);
            cmd.Parameters.AddWithValue("@id", order.OrderId);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        // Deletes the order together with its items, payment and delivery
        public void Delete(int orderId)
        {
            using var con = new MySqlConnection(Db.ConnectionString);
            con.Open();
            string[] sqls =
            {
                "DELETE FROM Order_Items WHERE order_id=@id",
                "DELETE FROM Payments WHERE order_id=@id",
                "DELETE FROM Deliveries WHERE order_id=@id",
                "DELETE FROM Orders WHERE order_id=@id"
            };
            foreach (string sql in sqls)
            {
                using var cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", orderId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
