using InventoryMgmt.Forms;
using InventoryMgmt.Models;
using System;
using System.Windows.Forms;

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
            if (dgvParts.CurrentRow != null)
            {
                Part selectedPart = (Part)dgvParts.CurrentRow.DataBoundItem;

                var confirm = MessageBox.Show($"Are you sure want to delete part '{selectedPart.Name}'?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    Models.Inventory.DeletePart(selectedPart);
                }
            }
            else
            {
                MessageBox.Show("Please select a part to delete.");
            }
        }



        private void btnAddProduct_Click(Object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            addProductForm.ShowDialog();
        }

        private void btnModifyProduct_Click(object sender, EventArgs e)
        {
            //
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgvParts.CurrentRow != null)
            {
                Product selectedProduct = (Product)dgvParts.CurrentRow.DataBoundItem;

                if (selectedProduct.AssociatedParts.Count > 0)
                {
                    MessageBox.Show("Can't delete a product that has associated parts");
                    return;
                }

                var confirm = MessageBox.Show($"Are you sure you want to delete {selectedProduct.Name}?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    Inventory.RemoveProduct(selectedProduct.ProductID);
                }
            }

            else 
            {
                MessageBox.Show("Please select a product to delete.");
            }
        }
    }
}