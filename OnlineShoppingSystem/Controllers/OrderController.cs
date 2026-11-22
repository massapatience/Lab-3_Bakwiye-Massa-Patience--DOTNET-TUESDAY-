using System.Data;
using OnlineShoppingSystem.Models;

namespace OnlineShoppingSystem.Controllers
{
    public class OrderController
    {
        private readonly OrderRepository _repository = new OrderRepository();

        public DataTable GetOrders() => _repository.GetAll();

        public DataTable SearchOrders(string keyword) => _repository.Search(keyword.Trim());

        public void AddOrder(Order order)
        {
            Validate(order);
            _repository.Insert(order);
        }

        public void EditOrder(Order order)
        {
            if (order.OrderId <= 0)
                throw new ArgumentException("Select an order before updating.");
            Validate(order);
            _repository.Update(order);
        }

        public void RemoveOrder(int orderId)
        {
            if (orderId <= 0)
                throw new ArgumentException("Select an order before deleting.");
            _repository.Delete(orderId);
        }

        private static void Validate(Order order)
        {
            if (order.UserId <= 0)
                throw new ArgumentException("Choose a customer.");
            if (order.TotalAmount <= 0)
                throw new ArgumentException("Total amount must be greater than 0.");
            if (order.OrderStatus == "")
                throw new ArgumentException("Choose an order status.");
        }
    }
}
