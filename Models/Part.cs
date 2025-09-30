using System;
namespace InventoryMgmt.Models
{
    public abstract class Part
    {
        public int PartID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        protected Part(int partID, string name, double price, int inStock, int min, int max)
        {
            PartID = partID;
            Name = name;
            Price = price;
            InStock = inStock;
            Min = min;
            Max = max;
        }
    }
}