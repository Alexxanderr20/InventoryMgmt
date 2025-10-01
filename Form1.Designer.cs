namespace InventoryMgmt
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvParts;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnAddPart;
        private System.Windows.Forms.Button btnModifyPart;
        private System.Windows.Forms.Button btnDeletePart;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnModifyProduct;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.Button btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvParts = new System.Windows.Forms.DataGridView();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.btnAddPart = new System.Windows.Forms.Button();
            this.btnModifyPart = new System.Windows.Forms.Button();
            this.btnDeletePart = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnModifyProduct = new System.Windows.Forms.Button();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();

            //Title
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Text = "Iventory Management App";

            //Parts
            this.dgvParts.Location = new System.Drawing.Point(20, 80);
            this.dgvParts.Size = new System.Drawing.Size(500, 200);

            //Products
            this.dgvProducts.Location = new System.Drawing.Point(540, 80);
            this.dgvProducts.Size = new System.Drawing.Size(500, 20);

            //Part Buttons
            this.btnAddPart.Text = "Add";
            this.btnAddPart.Location = new System.Drawing.Point(20, 300);
            this.btnAddPart.Click += new System.EventHandler(this.btnAddPart_Click);

            this.btnModifyPart.Text = "Modify";
            this.btnModifyPart.Location = new System.Drawing.Point(100, 300);
            this.btnModifyPart.Click += new System.EventHandler(this.btnModifyPart_Click);

            this.btnDeletePart.Text = "Delete";
            this.btnDeletePart.Location = new System.Drawing.Point(180, 300);
            this.btnDeletePart.Click += new System.EventHandler(this.btnDeletePart_Click);

            //Product Buttons
            this.btnAddProduct.Text = "Add";
            this.btnAddProduct.Location = new System.Drawing.Point(540, 300);
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);

            this.btnModifyProduct.Text = "Modify";
            this.btnModifyPart.Location = new System.Drawing.Point(620, 300);
            this.btnModifyPart.Click += new System.EventHandler(this.btnModifyPart_Click);

            this.btnDeleteProduct.Text = "Delete";
            this.btnDeleteProduct.Location = new System.Drawing.Point(700, 300);
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);

            //Exit button
            this.btnExit.Text = "Exit";
            this.btnExit.Location = new System.Drawing.Point(940, 340);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            //Form 1
            this.ClientSize = new System.Drawing.Size(1080, 400);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvParts);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.btnAddPart);
            this.Controls.Add(this.btnModifyPart);
            this.Controls.Add(this.btnDeletePart);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.btnModifyProduct);
            this.Controls.Add(this.btnDeleteProduct);
            this.Controls.Add(this.btnExit);
            this.Text = "Inventory Management System";

            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}