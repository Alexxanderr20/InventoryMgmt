using InventoryMgmt.Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace InventoryMgmt.Forms
{
    public partial class AddProductForm : Form
    {
        private BindingList<Part> associatedParts = new BindingList<Part>();

        public AddProductForm()
        {
            InitializeComponent();

            txtProductID.ReadOnly = true;
            txtProductID.Text = Inventory.GetNextProductID().ToString();

            dgvAllParts.DataSource = Inventory.AllParts;
            dgvAssociatedParts.DataSource = associatedParts;
        }



        //Adds a selected part from the All Parts grid to the Associated Parts grid
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvAllParts.CurrentRow == null)
            {
                MessageBox.Show("Please select a part to add.");
                return;
            }

            Part selectedPart = (Part)dgvAllParts.CurrentRow.DataBoundItem;

            if (associatedParts.Any(p => p.PartID == selectedPart.PartID))
            {
                MessageBox.Show("This part is already associated with the product.");
                return;
            }

            associatedParts.Add(selectedPart);
        }


        //Removes a selected part from the Associated Parts grid
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAssociatedParts.CurrentRow == null)
            {
                MessageBox.Show("Please select a part to remove.");
                return;
            }

            Part selectedPart = (Part)dgvAssociatedParts.CurrentRow.DataBoundItem;

            DialogResult confirm = MessageBox.Show($"Are you sure you want to remove part " +
                $"'{selectedPart.Name}'?", "Confirm Remove", MessageBoxButtons.YesNo);

            if(DialogResult == DialogResult.Yes)
            {
                associatedParts.Remove(selectedPart);
            }
        }

        //Saves Product
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Name cannot be empty.");
                return;
            }

            decimal price;
            int inStock, min, max;

            try
            {
                price = decimal.Parse(txtProductPrice.Text);
                inStock = int.Parse(txtProductInStock.Text);
                min = int.Parse(txtProductMin.Text);
                max = int.Parse(txtProductMax.Text);
            }
            catch
            {
                MessageBox.Show("Please enter valid values for Price, In Stock, Min, and Max.");
                return;
            }

            if (min > max)
            {
                MessageBox.Show("Min cannot be greater than Max.");
                return;
            }
            if (inStock < min || inStock > max)
            {
                MessageBox.Show("Inventory must be between Min and Max.");
                return;
            }
            if (!associatedParts.Any())
            {
                MessageBox.Show("A product must have at least one associated part.");
                return;
            }

            decimal totalPartsCost = associatedParts.Sum(p => p.Price);

            if (price <= 0)
            {
                MessageBox.Show($"Product price cannot be less than the total cost of " +
                    $"associated parts (${totalPartsCost}).");
                return;
            }

            int productID = int.Parse(txtProductID.Text);
            Product newProduct = new Product(productID, txtProductName.Text, price, inStock, min, max);

            foreach (Part part in associatedParts)
            {
                newProduct.AddAssociatedPart(part);
            }
            Inventory.AddProduct(newProduct);

            this.Close();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show(
                "Are you sure you want to cancel?",
                "Confirm cancel",
                MessageBoxButtons.YesNo);

            if (DialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                dgvAllParts.DataSource = Inventory.AllParts;
                return;
            }

            var filtered = Inventory.AllParts
                .Where(p => p.Name.ToLower().Contains(searchTerm) ||
                p.PartID.ToString() == searchTerm).ToList();

            if (filtered.Any())
            {
                dgvAllParts.DataSource = new BindingList<Part>(filtered);
            }
            else 
            {
                MessageBox.Show("No matching parts found.");
                dgvAllParts.DataSource= Inventory.AllParts;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
