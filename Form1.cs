using InventoryMgmt.Forms;
using InventoryMgmt.Models;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;

namespace InventoryMgmt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dgvParts.DataSource = Models.Inventory.AllParts;
            dgvProducts.DataSource = Models.Inventory.Products;

            dgvParts.Columns["PartID"].HeaderText = "Part ID";
            dgvParts.Columns["Name"].HeaderText = "Part Name";
            dgvParts.Columns["Price"].HeaderText = "Price";
            dgvParts.Columns["InStock"].HeaderText = "Inventory";

            dgvProducts.Columns["ProductID"].HeaderText = "Product ID";
            dgvProducts.Columns["Name"].HeaderText = "Product Name";
            dgvProducts.Columns["Price"].HeaderText = "Price";
            dgvProducts.Columns["InStock"].HeaderText = "Inventory";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAddPart_Click(object sender, EventArgs e)
        {
            AddPartForm addForm = new AddPartForm();
            addForm.ShowDialog();
        }

        private void btnModifyPart_Click(Object sender, EventArgs e)
        {
            if (dgvParts.CurrentRow != null)
            {
               Part selectedPart = (Part)dgvParts.CurrentRow.DataBoundItem;
               ModifyPartForm modifyForm = new ModifyPartForm(selectedPart);
               modifyForm.ShowDialog();
            }
        }

        private void btnDeletePart_Click(Object sender, EventArgs e)
        {
            var selectedPart = (Part)dgvParts.CurrentRow?.DataBoundItem;

            if(selectedPart == null)
            {
                MessageBox.Show("Please select a part to delete.");
                return;
            }

            foreach (var product in Inventory.Products)
            {
                if(product.AssociatedParts.Contains(selectedPart))
                {
                    MessageBox.Show("This part is associated with a product and cannot be deleted.",
                        "Delete Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
            }

            var confirm = MessageBox.Show($"Are you sure want to delete part '{selectedPart.Name}'?", 
                "Confirm Delete", 
                MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                Inventory.DeletePart(selectedPart);
            }

        }

        private void btnAddProduct_Click(Object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            addProductForm.ShowDialog();
        }

        private void btnModifyProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Please select a product to modify.");
                return;
            }

            Product selectedProduct = (Product)dgvProducts.CurrentRow.DataBoundItem;
            ModifyProductForm modifyForm = new ModifyProductForm(selectedProduct);
            modifyForm.ShowDialog();

        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
           if (dgvProducts.CurrentRow == null)
           {
               MessageBox.Show("Please select a product to delete.");
               return;
           }

           Product selectedProduct = (Product)dgvProducts.CurrentRow.DataBoundItem;

            if (selectedProduct.AssociatedParts.Count > 0)
            {
                MessageBox.Show("Cannot delete a product that has associated parts. Please remove associated parts first.");
                return;
            }

            DialogResult confirm = MessageBox.Show($"Are you sure you want to delete product '{selectedProduct.Name}'?", 
                "Confirm Delete", 
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                bool success = Models.Inventory.RemoveProduct(selectedProduct.ProductID);
                if (success)
                {
                    MessageBox.Show("Product deleted successfully.");
                    dgvProducts.DataSource = null;
                    dgvProducts.DataSource = Inventory.Products;
                }
                else
                {
                    MessageBox.Show("Error deleting product. Please try again.");
                }
            }


        }

        private void btnSearchParts_Click(Object sender, EventArgs e)
        {
            string query = txtSearchParts.Text.Trim().ToLower();
            bool found = false;

            dgvParts.ClearSelection();

            foreach (DataGridViewRow row in dgvParts.Rows)
            {
                if (row.Cells["PartID"].Value.ToString().ToLower().Contains(query) ||
                    row.Cells["Name"].Value.ToString().ToLower().Contains(query)) 
                {
                    row.Selected = true;
                    found = true;
                }
            }

            if (!found)
            {
                MessageBox.Show("No matching parts found.");
            }
        }


        private void btnProductsSearch_Click(Object sender, EventArgs e)
        {
            string query = txtProductsSearch.Text.Trim().ToLower();
            bool found = false;

            dgvProducts.ClearSelection();

            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                if (row.Cells["ProductID"].Value.ToString().ToLower().Contains(query) ||
                    row.Cells["Name"].Value.ToString().ToLower().Contains(query))
                {
                    row.Selected = true;
                    found = true;
                }
            }

            if (!found)
            {
                MessageBox.Show("No matching products found.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}