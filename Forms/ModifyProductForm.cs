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
            if (dgvAssociatedParts.CurrentRow == null)
            {
               MessageBox.Show("Please select a part to remove.");
               return;
            }

            Part selectedPart = (Part)dgvAssociatedParts.CurrentRow.DataBoundItem;

            DialogResult confirm = MessageBox.Show($"Are you sure you want to remove part " +
                $"'{selectedPart.Name}'?", "Confirm Remove", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                associatedParts.Remove(selectedPart);
            }
        }

        //Saves Product
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtInventory.Text) ||
                    string.IsNullOrWhiteSpace(txtPrice.Text) ||
                    string.IsNullOrWhiteSpace(txtMin.Text) ||
                    string.IsNullOrWhiteSpace(txtMax.Text))
                {
                    MessageBox.Show("Please ensure all fields are filled out correctly.");
                    return;
                }

                if (!int.TryParse(txtID.Text, out int id) ||
                    !int.TryParse(txtInventory.Text, out int stock) ||
                    !decimal.TryParse(txtPrice.Text, out decimal price) ||
                    !int.TryParse(txtMin.Text, out int min) ||
                    !int.TryParse(txtMax.Text, out int max))
                {
                    MessageBox.Show("Please ensure Inventory, Min, Max, and Price contain valid numbers.");
                    return;
                }

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

                Product updatedProduct = new Product(
                    id, txtName.Text.Trim(), price, stock, min, max);

                foreach (Part part in associatedParts)
                {
                    updatedProduct.AddAssociatedPart(part);
                }

                Inventory.UpdateProduct(updatedProduct.ProductID, updatedProduct);
                this.Close();

            }

            catch (Exception ex) 
            {
                MessageBox.Show("An unexpected error occured:  " + ex.Message);
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
