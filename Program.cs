using InventoryMgmt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryMgmt
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Inhouse testPart = new Inhouse(1, "Test Part", 5.99m, 10, 1, 2, 123);
            Inventory.AddPart(testPart);

            Product testProduct = new Product(100, "Test Product", 19.99m, 5, 1, 10);
            testProduct.AddAssociatedPart(testPart);
            Inventory.AddProduct(testProduct);

            Console.WriteLine($"Parts in inventory: {Inventory.AllParts.Count}");
            Console.WriteLine($"Products in inventory: {Inventory.Products.Count}");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
