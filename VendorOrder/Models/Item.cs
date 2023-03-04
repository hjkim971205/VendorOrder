using System.Collections.Generic;

namespace VendorOrder.Models
{
    public class Item
    {
        public string Album { get; set; }
        public string Artist { get; set; }
        public string Release { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int Id { get; }
        private static List<Item> _instances = new List<Item> { };

        public Item(string album, string artist, string release, string title)
        {
            
            Album = album;
            Artist = artist;
            Release = release;
            Title = title; 
            _instances.Add(this);
            Id = _instances.Count;
        }

        public static List<Item> GetAll()
        {
            return _instances;
        }

        public static void ClearAll()
        {
            _instances.Clear();
        }

        public static Item Find(int searchId)
        {
            return _instances[searchId - 1];
        }
    }
}