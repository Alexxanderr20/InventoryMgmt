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
            try
            {
                int id = Inventory.GetNextProductID();
                string name = txtProductName.Text;
                int stock = int.Parse(txtProductInStock.Text.Trim());
                decimal price = decimal.Parse(txtProductPrice.Text.Trim());
                int min = int.Parse(txtProductMin.Text.Trim());
                int max = int.Parse(txtProductMax.Text.Trim());

                //MessageBox.Show($"Inventory: {stock}, Min: {min}, Max: {max}, Price: {price}");

                if (min > max)
                {
                    MessageBox.Show("Min can not be greater than Max.");
                    return;
                }

                if (stock < min || stock > max)
                {
                    MessageBox.Show("Inventory must be between Min and Max.");
                    return;
                }

                Product newProduct = new Product(id, name, price, stock, min, max);

                foreach (Part part in associatedParts)
                {
                    newProduct.AddAssociatedPart(part);
                }

                Inventory.AddProduct(newProduct);

                MessageBox.Show("Product added sucessfully! ");
                Close();
            }

            catch (FormatException)
            {
                MessageBox.Show("Please enter valid values for all fields.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving product: {ex.Message}");
            }
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
