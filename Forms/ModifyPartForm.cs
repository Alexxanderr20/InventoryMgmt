using System;
using InventoryMgmt.Models;
using System.Windows.Forms;

namespace InventoryMgmt.Forms
{
    public partial class ModifyPartForm : Form
    {
        private Part _partToModify;

        public ModifyPartForm(Part partToModify)
        {
            InitializeComponent();
            _partToModify = partToModify;

            txtPartID.Text = _partToModify.PartID.ToString();
            txtPartName.Text = _partToModify.Name;
            txtPrice.Text = _partToModify.Price.ToString();
            txtInStock.Text = _partToModify.InStock.ToString();
            txtMin.Text = _partToModify.Min.ToString();
            txtMax.Text = _partToModify.Max.ToString();


            //Sets radio buttons and machine/company field based on part type
            if (_partToModify is Inhouse inhouse)
            {
                rbtnInhouse.Checked = true;
                txtMachineID.Text = (_partToModify as Inhouse).MachineID.ToString();
            }
            else if (_partToModify is Outsourced outsourced)
            {
                rbtnOutsourced.Checked = true;
                txtMachineID.Text = (_partToModify as Outsourced).CompanyName;
            }


            //Wires events
            rbtnInhouse.CheckedChanged += rbtnInhouse_CheckedChanged;
            rbtnOutsourced.CheckedChanged += rbtnOutsourced_CheckedChanged;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;

            UpdateMachineCompanyLabel();
        }

        private void rbtnInhouse_CheckedChanged(object sender, EventArgs e)
        {
            UpdateMachineCompanyLabel();
        }

        private void rbtnOutsourced_CheckedChange(object sender, EventArgs e)
        {
            UpdateMachineCompanyLabel();
        }

        private void UpdateMachineCompanyLabel()
        {
            lblMachineCompany.Text = rbtnInhouse.Checked ? "Machine ID" : "Company Name";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int partID = int.Parse(txtPartID.Text);
                string name = txtPartName.Text;
                decimal price = decimal.Parse(txtPrice.Text);
                int stock = int.Parse(txtInStock.Text);
                int min = int.Parse(txtMin.Text);
                int max = int.Parse(txtMax.Text);

                Part updatedPart;

                if (rbtnInhouse.Checked)
                {
                    int machineID = int.Parse(txtMachineID.Text);
                    updatedPart = new Inhouse(partID, name, price, stock, min, max, machineID);
                }
                else
                {
                    string companyName = txtMachineID.Text;
                    updatedPart = new Outsourced(partID, name, price, stock, min, max, companyName);
                }

                int index = Inventory.AllParts.IndexOf(_partToModify);
                if (index >= 0)
                {
                   Inventory.AllParts[index] = updatedPart;
                }
                this.Close();
            }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
        }

        private void ModifyPartForm_Load(object sender, EventArgs e)
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

        private void rbtnOutsourced_CheckedChanged(Object sender, EventArgs e)
        {
            
        }
    }
}
