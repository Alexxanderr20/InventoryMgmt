using System.Collections.Generic;

namespace InventoryMgmt.Models { 
    public static class Inventory
    {
        public static List<Part> AllParts { get; set; } = new List<Part>();
        public static List<Product> Products { get; set; } = new List<Product>();

        //Product methods
        public static void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public static bool RemoveProduct(int productID)
        {
            var product = Products.Find(p => p.ProductID == productID);
            if (product != null)
            {
                Products.Remove(product);
                return true;
            }
            return false;
        }

        public static Product LookupProduct(int productID)
        {
            return Products.Find(p => p.ProductID == productID);
        }

        public static List<Product> GetAllProducts()
        {
            return new List<Product>(Products);
        }

        //Part methods
        public static void AddPart(Part part)
        {
            AllParts.Add(part);
        }

        public static bool DeletePart(Part part)
        {
            return AllParts.Remove(part);
        }

        public static Part LookupPart(int partID)
        {
            return AllParts.Find(p => p.PartID == partID);
        }
        public static List<Part> GetAllParts()
        {
            return new List<Part>(AllParts);
        }
    }
}