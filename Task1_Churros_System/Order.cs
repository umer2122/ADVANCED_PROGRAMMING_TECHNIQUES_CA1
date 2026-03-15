using System;

namespace Que1_Churros
{
    public class Order
    {
        public int OrderNo { get; private set; }
        public string OrderDetails { get; set; }
        public int Quantity { get; set; }
        public double Bill { get; private set; }

        public Order(int orderNo, string orderDetails, int quantity)
        {
            OrderNo = orderNo;
            OrderDetails = orderDetails;
            Quantity = quantity;
        }

        public double PayBill(double price)
        {
            Bill = price * Quantity;
            return Bill;
        }

        public void CollectOrder()
        {
            Console.WriteLine($"Order {OrderNo} delivered.");
        }
    }
}