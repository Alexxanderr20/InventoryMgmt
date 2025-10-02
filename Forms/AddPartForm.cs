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
            try
            {
                int partID = int.Parse(txtPartID.Text);
                string name = txtPartName.Text;
                decimal price = decimal.Parse(txtPrice.Text);
                int stock = int.Parse(txtInStock.Text);
                int min = int.Parse(txtMin.Text);
                int max = int.Parse(txtMax.Text);

                Part newPart;

                if (rbtnInhouse.Checked)
                {
                    int machineID = int.Parse(txtMachineID.Text);
                    newPart = new Inhouse(partID, name, price, stock, min, max, machineID);
                }
                else
                {
                    string companyName = txtMachineID.Text;
                    newPart = new Outsourced(partID, name, price, stock, min, max, companyName);
                }

                Inventory.AddPart(newPart);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
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
