using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace InventoryMgmt.Models { 
    public static class Inventory
    {
        public static BindingList<Part> AllParts { get; } = new BindingList<Part>();
        public static BindingList<Product> Products { get; } = new BindingList<Product>();

        private static int nextProductID = 1;
        private static int nextPartID = 1;

        public static int GetNextProductID()
        {
            if (Products.Count == 0)
            {
                return 1000;
            }
            return Products.Max(p => p.ProductID) + 1;
        }

        public static int GetNextPartID()
        {
            return nextPartID++;
        }


        //Product methods
        public static void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public static bool RemoveProduct(int productID)
        {
            var product = Products.FirstOrDefault(p => p.ProductID == productID);
            if (product != null)
            {
                Products.Remove(product);
                return true;
            }
            return false;
        }

        public static Product LookupProduct(int productID)
        {
            return Products.FirstOrDefault(p => p.ProductID == productID);
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
            return AllParts.FirstOrDefault(p => p.PartID == partID);
        }
        public static List<Part> GetAllParts()
        {
            return new List<Part>(AllParts);
        }


    }
}