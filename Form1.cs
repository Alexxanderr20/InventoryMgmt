using InventoryMgmt.Forms;
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
            MessageBox.Show("Modify Part clicked (placeholder)");
        }

        private void btnDeletePart_Click(Object sender, EventArgs e)
        {
            MessageBox.Show("Delete Part clicked (placeholder)");
        }
        private void btnAddProduct_Click(Object sender, EventArgs e)
        {
            MessageBox.Show("Add Product clicked (placeholder)");
        }

        private void btnModifyProduct_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Modify Product clicked (placeholder)");
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete Product clicked (placeholder) ");
        }
    }
}