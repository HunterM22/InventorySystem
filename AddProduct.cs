﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem
{
    public partial class AddProductForm : Form
    {
        public int currPart { get; private set; }

        public AddProductForm()
        {
            InitializeComponent();

            AProdDGVParts.AutoGenerateColumns = true;
            AProdDGVAssocParts.AutoGenerateColumns = true;

            AProdDGVParts.DataSource = Inventory.AllParts;
            AProdDGVAssocParts.DataSource = Inventory.CurrentProduct.AssociatedParts;

            dgvFormatter(AProdDGVParts);
            dgvFormatter(AProdDGVAssocParts);
        }

        public static void dgvFormatter(DataGridView dgvStyle)
        {
            dgvStyle.RowHeadersVisible = false;
            dgvStyle.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Yellow;
            dgvStyle.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            dgvStyle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStyle.AllowUserToAddRows = false;
            dgvStyle.ReadOnly = true;
        }

        private void AProdCancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ModifyProductForm o = new ModifyProductForm();
            o.Show();

        }

        private void AProdDGVParts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           //xx
        }

        private void AProdDGVAssocParts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //xx
        }

        private void AProdSearchButton_Click(object sender, EventArgs e)
        {
            string searchValue = AProdSearchTextBox.Text;
            foreach (DataGridViewRow row in AProdDGVParts.Rows)
            {
                if ((string)row.Cells[1].Value == searchValue)
                {
                    row.Selected = true;
                }
                else
                {
                    row.Selected = false;
                }
            }
        }

        private void AProdAddButton_Click(object sender, EventArgs e)
        {
            Inventory.CurrentProduct.AddAssociatedPart(Inventory.CurrentPart);
            this.Hide();
            ModifyProductForm o = new ModifyProductForm();
            o.Show();
        }

        private void AProdDeleteButton_Click(object sender, EventArgs e)
        {
            Inventory.CurrentProduct.RemoveAssociatedPart(Inventory.CurrPartIndex);
            this.Hide();
            ModifyProductForm o = new ModifyProductForm();
            o.Show();
        }

        private void AProdSaveButton_Click(object sender, EventArgs e)
        {
            Inventory.AddProduct(Inventory.CurrentProduct);
            this.Hide();
            Mainscreen p = new Mainscreen();
            p.Show();
        }

        private void AProdDGVParts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Inventory.CurrPartIndex = e.RowIndex;
            Inventory.CurrentPart = Inventory.AllParts[Inventory.CurrPartIndex];
        }

        private void AProdDGVAssocParts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Product.CurrAssocIndex = e.RowIndex;
            Product.CurrentAssocPart = Inventory.CurrentProduct.AssociatedParts[Product.CurrAssocIndex];
        }
    }
}
