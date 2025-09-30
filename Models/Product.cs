using System.Collections.Generic;

namespace InventoryMgmt.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public List<Part> AssociatedParts { get; set; }
        public Product(int productID, string name, double price, int inStock, int min, int max)
        {
            ProductID = productID;
            Name = name;
            Price = price;
            InStock = inStock;
            Min = min;
            Max = max;
            AssociatedParts = new List<Part>();
        }
        public void AddAssociatedPart(Part part)
        {
            AssociatedParts.Add(part);
        }
        public bool RemoveAssociatedPart(int partID)
        {
            var part = AssociatedParts.Find(p => p.PartID == partID);
            if (part != null)
            {
                AssociatedParts.Remove(part);
                return true;
            }
            return false;
        }
        public Part LookupAssociatedPart(int partID)
        {
            return AssociatedParts.Find(p => p.PartID == partID);
        }
    }
}