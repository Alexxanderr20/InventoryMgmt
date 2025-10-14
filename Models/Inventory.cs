using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace InventoryMgmt.Models { 
    public static class Inventory
    {
        public static BindingList<Part> AllParts { get; } = new BindingList<Part>();
        public static BindingList<Product> Products { get; } = new BindingList<Product>();

        //Product methods
        public static void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public static bool RemoveProduct(int productID)
        {
            Product product = Products.FirstOrDefault(p => p.ProductID == productID);
            if (product != null)
            {
                Products.Remove(product);
                return true;
            }
            return false;
        }

        public static void UpdateProduct(int productID, Product newProduct)
        {
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].ProductID == productID)
                {
                    Products[i] = newProduct;
                    return;
                }
            }
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

        public static List<Part> LookupPart(string query)
        {
            return AllParts.Where(p => p.Name.ToLower().Contains(query.ToLower()) || p.PartID.ToString() == query).ToList();
        }
        public static List<Part> GetAllParts()
        {
            return new List<Part>(AllParts);
        }

        public static int GeneratePartID()
        {
            if (AllParts.Count == 0)
            {
                return 1;
            }
            else
            {
                return AllParts.Max(p => p.PartID) + 1;
            }
        }

        public static int GetNextProductID()
        {
            if (Products.Count == 0)
            {
                return 1;
            }
            return Products.Max(p => p.ProductID) + 1;
        }
    }
}