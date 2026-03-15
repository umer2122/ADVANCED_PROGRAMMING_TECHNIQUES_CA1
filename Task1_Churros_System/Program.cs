using System;
using System.Collections.Generic;

namespace Que1_Churros
{
    class Program
    {
        static Queue<Order> orderQueue = new Queue<Order>();
        static int orderCounter = 1;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nDelicious Churros");
                Console.WriteLine("1. Place Order");
                Console.WriteLine("2. Deliver Order");
                Console.WriteLine("0. Exit");

                Console.Write("Choose option: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        PlaceOrder();
                        break;

                    case 2:
                        DeliverOrder();
                        break;

                    case 0:
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        static void PlaceOrder()
        {
            Console.WriteLine("\nMenu");
            Console.WriteLine("1. Plain Sugar (€6)");
            Console.WriteLine("2. Cinnamon Sugar (€6)");
            Console.WriteLine("3. Chocolate Sauce (€8)");
            Console.WriteLine("4. Nutella (€8)");

            Console.Write("Choose item: ");
            int option = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter quantity: ");
            int qty = Convert.ToInt32(Console.ReadLine());

            Churros item = null;

            switch (option)
            {
                case 1:
                    item = new Churros("Plain Sugar", 6);
                    break;
                case 2:
                    item = new Churros("Cinnamon Sugar", 6);
                    break;
                case 3:
                    item = new Churros("Chocolate Sauce", 8);
                    break;
                case 4:
                    item = new Churros("Nutella", 8);
                    break;
            }

            Order order = new Order(orderCounter++, item.Name, qty);

            double bill = order.PayBill(item.Price);

            Console.WriteLine($"Total Bill: €{bill}");
            Console.WriteLine($"Order Number: {order.OrderNo}");

            orderQueue.Enqueue(order);
        }

        static void DeliverOrder()
        {
            if (orderQueue.Count == 0)
            {
                Console.WriteLine("No orders in queue");
                return;
            }

            Order order = orderQueue.Dequeue();
            order.CollectOrder();
        }
    }
}