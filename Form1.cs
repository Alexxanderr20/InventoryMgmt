using System;
using System.Windows.Forms;

namespace InventoryMgmt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAddPart_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Part clicked (placeholder)");
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