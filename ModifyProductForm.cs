using System;
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
    public partial class ModifyProductForm : Form
    {
        public ModifyProductForm()
        {
            InitializeComponent();
            //Get current prod from Mainscreen selected index
            Inventory.CurrentProduct = Inventory.Products[Inventory.CurrProductIndex];
            //Populate fields for selected prod into the Modify form
            MProdIDTextBox.Text = Inventory.CurrentProduct.ProductID.ToString();
            MProdNameTextBox.Text = Inventory.CurrentProduct.Name;
            MProdPriceTextBox.Text = Inventory.CurrentProduct.Price.ToString();
            MProdInventoryTextBox.Text = Inventory.CurrentProduct.InStock.ToString();
            MProdMinTextBox.Text = Inventory.CurrentProduct.Min.ToString();
            MProdMaxTextBox.Text = Inventory.CurrentProduct.Max.ToString();

            MProdDGVParts.AutoGenerateColumns = true;
            MProdDGVAssocParts.AutoGenerateColumns = true;

            MProdDGVParts.DataSource = Inventory.AllParts;
           // MProdDGVAssocParts.DataSource = Product.AssociatedParts;

            dgvFormatter(MProdDGVParts);
            dgvFormatter(MProdDGVAssocParts);
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

        private void MProdCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MProdDGVParts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MProdDGVAssocParts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MProdSearchButton_Click(object sender, EventArgs e)
        {
            string searchValue = MProdSearchTextBox.Text;
            foreach (DataGridViewRow row in MProdDGVParts.Rows)
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

        private void MProdAddButton_Click(object sender, EventArgs e)
        {
            Inventory.CurrentPart = Inventory.AllParts[Inventory.CurrPartIndex];
            //How to invoke Product.addAssociatedPart---------------------------------//
        }

        private void MProdDeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void MProdSaveButton_Click(object sender, EventArgs e)
        {

        }
    }
}
