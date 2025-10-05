using InventoryMgmt.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryMgmt.Forms
{
    public partial class ModifyProductForm : Form
    {
        //private Part SelectedPart;
        private Product currentProduct;
        private BindingList<Part> associatedParts = new BindingList<Part>();

        public ModifyProductForm(Product product)
        {
            InitializeComponent();
            currentProduct = product;
        }

        private void ModifyProductForm_Load(object sender, EventArgs e)
        {
            dgvAllParts.DataSource = Inventory.AllParts;

            associatedParts = new BindingList<Part>(currentProduct.AssociatedParts.ToList());
            dgvAssociatedParts.DataSource = associatedParts;

            txtID.Text = currentProduct.ProductID.ToString();
            txtName.Text = currentProduct.Name;
            txtInventory.Text = currentProduct.InStock.ToString();
            txtPrice.Text = currentProduct.Price.ToString();
            txtMin.Text = currentProduct.Min.ToString();
            txtMax.Text = currentProduct.Max.ToString();
        }

        //ADDS PART

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvAllParts.CurrentRow == null)
            {
                MessageBox.Show("Please select a part to add. ");
                return;
            }

            Part selectedPart = (Part)dgvAllParts.CurrentRow.DataBoundItem;

            if (associatedParts.Any(p => p.PartID == selectedPart.PartID))
            {
                MessageBox.Show("This part is already associated with this product.");
                return;
            }

            associatedParts.Add(selectedPart);
        }

        //Remove Part

        private void btnDeleteAssociated_Click(object sender, EventArgs e)
        {
            if (dgvAssociatedParts.CurrentRow == null)
            {
                MessageBox.Show("Please select a part to remove.");
                return;
            }

            Part selectedPart = (Part)dgvAssociatedParts.CurrentRow.DataBoundItem;

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to remove {selectedPart.Name}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                associatedParts.Remove(selectedPart);
            }
        }

        //Saves Product

        private void btnSave_Click(object sender, EventArgs e)
        {
            try 
            {
                string name = label3.Text.Trim();
                int stock = int.Parse(label4.Text);
                decimal price = decimal.Parse(label5.Text);
                int min = int.Parse(label6.Text);
                int max = int.Parse(label7.Text);

                if (min > max)
                {
                    MessageBox.Show("Min cannot be greater than Max.");
                    return;
                }

                if (stock < min || stock > max)
                {
                    MessageBox.Show("Inventory must be between Min and Max.");
                    return;
                }

                currentProduct.Name = name;
                currentProduct.InStock = stock;
                currentProduct.Price = price;
                currentProduct.Min = min;
                currentProduct.Max = max;

                currentProduct.AssociatedParts.Clear();
                foreach (var part in associatedParts)
                    currentProduct.AddAssociatedPart(part);

                MessageBox.Show("Product updated successfully!");
                this.Close();
            }

            catch(FormatException)
            {
                MessageBox.Show("Please enter valid values for all fields.");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error updating product: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to cancel?",
                "Confirm cancel",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
                this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim().ToLower();

            if(string.IsNullOrWhiteSpace(searchTerm))
            {
                dgvAllParts.DataSource = Inventory.AllParts;
                return;
            }

            var filtered = Inventory.AllParts
                .Where(p => p.Name.ToLower().Contains(searchTerm) ||
                p.PartID.ToString() == searchTerm)
                .ToList();

            if (filtered.Any())
            {
                dgvAllParts.DataSource = new BindingList<Part>(filtered);
            }

            else
            {
                MessageBox.Show("No matching parts found.");
                dgvAllParts.DataSource = Inventory.AllParts;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtName_Click(object sender, EventArgs e)
        {

        }
    }
}
