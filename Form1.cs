using InventoryMgmt.Forms;
using InventoryMgmt.Models;
using System;
using System.Windows.Forms;
using System.Linq;
using System.ComponentModel;

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
                    dgvParts.DataSource = null;
                    dgvParts.DataSource = Inventory.AllParts;
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

        private void btnSearchParts_Click(Object sender, EventArgs e)
        {
            string query = txtPartsSearch.Text.Trim().ToLower();
            bool found = false;

            foreach (DataGridViewRow row in dgvParts.Rows)
            {
                Part part = row.DataBoundItem as Part;
                if (part != null && (part.PartID.ToString().Contains(query) || part.Name.ToLower().Contains(query)))
                {
                    row.Selected = true;
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                MessageBox.Show("No matching part found.");
            }
        }


        private void btnProductsSearch_Click(Object sender, EventArgs e)
        {
            string query = txtProductsSearch.Text.Trim().ToLower();
            bool found = false;

            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                Product product = row.DataBoundItem as Product;
                if (product != null && (product.ProductID.ToString().Contains(query) || product.Name.ToLower().Contains(query)))
                {
                    row.Selected = true;
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                MessageBox.Show("No matching product found.");
            }
        }

        //private void btnSearchParts_Click(object sender, EventArgs e)
        //{
        //    string query = txtSearchParts.Text.ToLower().Trim();

        //    if (int.TryParse(query, out int id))
        //    {
        //        Part part = Inventory.LookupPart(id);

        //        if (part != null)
        //        {
        //            dgvParts.DataSource = new BindingList<Part> { part };
        //            return;
        //        }
        //    }


        //    var results = Inventory.LookupPart(query);
        //    if (results.Count > 0)
        //    {
        //        dgvParts.DataSource = new BindingList<Part>(results);
        //    }
        //    else 
        //    {
        //        MessageBox.Show("No matching parts found.");
        //        dgvParts.DataSource = Inventory.AllParts;
        //    }
        //}



        //private void btnSearchProducts_Click(object sender, EventArgs)
        //{
        //    string query = txtProductsSearch.Text.ToLower().Trim();

        //    if (int.TryParse(query, out int id))
        //    {
        //        Product product = Inventory.LookupProduct(id);
        //        if (product != null)
        //        {
        //            dgvProducts.DataSource = new BindingList<Product> { product };
        //            return;
        //        }
        //    }

        //    var results = Inventory.LookupProduct(query);
        //    if (results.Count > 0)
        //    {
        //        dgvProducts.DataSource = new BindingList<Product>(results);
        //    }
        //    else
        //    {
        //        MessageBox.Show("No matching products found.");
        //        dgvProducts.DataSource = Inventory.Products;
        //    }
        //}

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}