using System.Collections.Generic;

namespace VendorOrder.Models
{
    public class Order
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Due { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

        public int Id { get; }
        private static List<Order> _instances = new List<Order> { };

        public Order(string name, string location, string due, int quantity)
        {
            
            Name = name;
            Location = location;
            Due = due;
            Quantity = quantity; 
            _instances.Add(this);
            Id = _instances.Count;
        }

        public static List<Order> GetAll()
        {
            return _instances;
        }

        public static void ClearAll()
        {
            _instances.Clear();
        }

        public static Order Find(int searchId)
        {
            return _instances[searchId - 1];
        }
    }
}