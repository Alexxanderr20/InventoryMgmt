using InventoryMgmt.Models;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace InventoryMgmt.Forms
{
    public partial class ModifyProductForm : Form
    {
        private Product selectedProduct;
        private BindingList<Part> associatedParts = new BindingList<Part>();

        public ModifyProductForm(Product product)
        {
            InitializeComponent();
            selectedProduct = product;

            txtID.Text = selectedProduct.ProductID.ToString();
            txtName.Text = selectedProduct.Name;
            txtInventory.Text = selectedProduct.InStock.ToString();
            txtPrice.Text = selectedProduct.Price.ToString();
            txtMin.Text = selectedProduct.Min.ToString();
            txtMax.Text = selectedProduct.Max.ToString();

            foreach (var part in product.AssociatedParts)
            {
                associatedParts.Add(part);
            }

            dgvAllParts.DataSource = Inventory.AllParts;
            dgvAssociatedParts.DataSource = associatedParts;
        }


        //ADDS PART
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvAllParts.CurrentRow != null) 
            {
                Part selectedPart = (Part)dgvAllParts.CurrentRow.DataBoundItem;
                associatedParts.Add(selectedPart);
            }
        }

        //Removes Part
        private void btnDeleteAssociated_Click(object sender, EventArgs e)
        {
            if (dgvAssociatedParts.CurrentRow != null)
            {
                Part selectedPart = (Part)dgvAllParts.CurrentRow.DataBoundItem;
                associatedParts.Add(selectedPart);
            }
        }

        //Saves Product
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtID.Text);
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

                Product updatedProduct = new Product(id, name, price, stock, min, max);
                foreach (var part in associatedParts)
                {
                    updatedProduct.AddAssociatedPart(part);

                    Inventory.UpdateProduct(id, updatedProduct);
                    MessageBox.Show("Product updated succcesfully!");
                    this.Close();
                }
            }

            catch 
            {
                MessageBox.Show("Please ensure all fields are filed out correctly.");
                this.Close();
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
