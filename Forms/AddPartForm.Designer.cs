namespace InventoryMgmt.Forms
{
    partial class AddPartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rbtnInhouse = new System.Windows.Forms.RadioButton();
            this.rbtnOutsourced = new System.Windows.Forms.RadioButton();
            this.txtPartID = new System.Windows.Forms.TextBox();
            this.txtPartName = new System.Windows.Forms.TextBox();
            this.txtInStock = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.txtMachineID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMachineCompany = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbtnInhouse
            // 
            this.rbtnInhouse.AutoSize = true;
            this.rbtnInhouse.Location = new System.Drawing.Point(254, 12);
            this.rbtnInhouse.Name = "rbtnInhouse";
            this.rbtnInhouse.Size = new System.Drawing.Size(68, 17);
            this.rbtnInhouse.TabIndex = 0;
            this.rbtnInhouse.Text = "In-House";
            this.rbtnInhouse.UseVisualStyleBackColor = true;
            this.rbtnInhouse.CheckedChanged += new System.EventHandler(this.rbtnInhouse_CheckedChanged);
            // 
            // rbtnOutsourced
            // 
            this.rbtnOutsourced.AutoSize = true;
            this.rbtnOutsourced.Location = new System.Drawing.Point(456, 12);
            this.rbtnOutsourced.Name = "rbtnOutsourced";
            this.rbtnOutsourced.Size = new System.Drawing.Size(80, 17);
            this.rbtnOutsourced.TabIndex = 1;
            this.rbtnOutsourced.Text = "Outsourced";
            this.rbtnOutsourced.UseVisualStyleBackColor = true;
            this.rbtnOutsourced.CheckedChanged += new System.EventHandler(this.rbtnOutsourced_CheckedChanged);
            // 
            // txtPartID
            // 
            this.txtPartID.Location = new System.Drawing.Point(254, 54);
            this.txtPartID.Name = "txtPartID";
            this.txtPartID.Size = new System.Drawing.Size(282, 20);
            this.txtPartID.TabIndex = 2;
            this.txtPartID.TextChanged += new System.EventHandler(this.txtPartID_TextChanged);
            // 
            // txtPartName
            // 
            this.txtPartName.Location = new System.Drawing.Point(254, 99);
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.Size = new System.Drawing.Size(282, 20);
            this.txtPartName.TabIndex = 3;
            // 
            // txtInStock
            // 
            this.txtInStock.Location = new System.Drawing.Point(254, 153);
            this.txtInStock.Name = "txtInStock";
            this.txtInStock.Size = new System.Drawing.Size(282, 20);
            this.txtInStock.TabIndex = 4;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(254, 199);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(282, 20);
            this.txtPrice.TabIndex = 5;
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(456, 265);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(131, 20);
            this.txtMax.TabIndex = 6;
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(254, 265);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(115, 20);
            this.txtMin.TabIndex = 7;
            // 
            // txtMachineID
            // 
            this.txtMachineID.Location = new System.Drawing.Point(254, 312);
            this.txtMachineID.Name = "txtMachineID";
            this.txtMachineID.Size = new System.Drawing.Size(282, 20);
            this.txtMachineID.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Add Part";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "ID";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Name";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Inventory";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(170, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Price / Cost";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(403, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Max";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(215, 268);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Min";
            // 
            // lblMachineCompany
            // 
            this.lblMachineCompany.AutoSize = true;
            this.lblMachineCompany.Location = new System.Drawing.Point(171, 319);
            this.lblMachineCompany.Name = "lblMachineCompany";
            this.lblMachineCompany.Size = new System.Drawing.Size(62, 13);
            this.lblMachineCompany.TabIndex = 16;
            this.lblMachineCompany.Text = "Machine ID";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(456, 390);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(567, 389);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddPartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblMachineCompany);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMachineID);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtInStock);
            this.Controls.Add(this.txtPartName);
            this.Controls.Add(this.txtPartID);
            this.Controls.Add(this.rbtnOutsourced);
            this.Controls.Add(this.rbtnInhouse);
            this.Name = "AddPartForm";
            this.Text = "AddPartForm";
            this.Load += new System.EventHandler(this.AddPartForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnInhouse;
        private System.Windows.Forms.RadioButton rbtnOutsourced;
        private System.Windows.Forms.TextBox txtPartID;
        private System.Windows.Forms.TextBox txtPartName;
        private System.Windows.Forms.TextBox txtInStock;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.TextBox txtMachineID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblMachineCompany;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}