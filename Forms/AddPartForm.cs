using InventoryMgmt.Models;
using System;
using System.Windows.Forms;

namespace InventoryMgmt.Forms
{
    public partial class AddPartForm : Form
    {
        public AddPartForm()
        {
            InitializeComponent(); 

            txtPartID.Text = Inventory.GeneratePartID().ToString();
            txtPartID.ReadOnly = true;
            rbtnInhouse.Checked = true;
        }

        //Cancel button
        private void btnCancel_Click(Object sender, EventArgs e)
        {
            this.Close();
        }

        //Saves the new part
        private void btnSave_Click(Object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPartName.Text))
            {
                MessageBox.Show("Name cannot be empty.");
                return;
            }

            decimal price;
            int inStock, min, max;

            try
            {
                price = decimal.Parse(txtPrice.Text);
                inStock = int.Parse(txtInStock.Text);
                min = int.Parse(txtMin.Text);
                max = int.Parse(txtMax.Text);
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

            if (price < 0)
            {
                MessageBox.Show("Price cannot be negative.");
                return;
            }

            int partID = int.Parse(txtPartID.Text);

            Part newPart;

            if (rbtnInhouse.Checked)
            {
                if (!int.TryParse(txtMachineID.Text, out int machineID))
                {
                    MessageBox.Show("Please enter a valid Machine ID.");
                    return;
                }
                newPart = new Inhouse(partID, txtPartName.Text, price, inStock, min, max, machineID);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtMachineID.Text))
                {
                    MessageBox.Show("Company Name cannot be empty.");
                    return;
                }
                newPart = new Outsourced(partID, txtPartName.Text, price, inStock, min, max, txtMachineID.Text);
            }

            Inventory.AddPart(newPart);

            this.Close();
        }

        //Toggles between In-House is selected
        private void rbtnInhouse_CheckedChanged(Object sender, EventArgs e)
        {
           if (rbtnInhouse.Checked)
            {
                lblMachineCompany.Text = "Machine ID";
                txtMachineID.Text = "";
            }
        }

        //Toggles between Outsourced is selected
        private void rbtnOutsourced_CheckedChanged(Object sender, EventArgs e)
        {
            if (rbtnOutsourced.Checked)
            {
                lblMachineCompany.Text = "Company Name";
                txtMachineID.Text = "";
            }
        }

        private void AddPartForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtPartID_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbtnInhouse_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}
