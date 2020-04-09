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
            MProdDGVAssocParts.DataSource = Inventory.CurrentProduct.AssociatedParts;

            //Product.CurrAssocIndex = -1;
            //Inventory.CurrPartIndex = -1;

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
            this.Hide();
            Mainscreen q = new Mainscreen();
            q.Show();
        }

        private void MProdDGVParts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //xx
        }

        private void MProdDGVAssocParts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //xx
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
            Inventory.CurrentProduct.AddAssociatedPart(Inventory.CurrentPart);
            MProdDGVAssocParts.DataSource = Inventory.CurrentProduct.AssociatedParts;
            MProdDGVParts.DataSource = Inventory.AllParts;

            //this.Hide();
            //ModifyProductForm o = new ModifyProductForm();
            //o.Show();

        }

        private void MProdDeleteButton_Click(object sender, EventArgs e)
        {
            Inventory.CurrentProduct.RemoveAssociatedPart(Inventory.CurrPartIndex);
            MProdDGVAssocParts.DataSource = Inventory.CurrentProduct.AssociatedParts;
            MProdDGVParts.DataSource = Inventory.AllParts;
        }

        private void MProdSaveButton_Click(object sender, EventArgs e)
        {
            
            Inventory.CurrentProduct.ProductID = Int32.Parse(MProdIDTextBox.Text);//update to currentproduct
            Inventory.CurrentProduct.Name = MProdNameTextBox.Text;
            Inventory.CurrentProduct.InStock = Int32.Parse(MProdInventoryTextBox.Text);
            Inventory.CurrentProduct.Price = Decimal.Parse(MProdPriceTextBox.Text);
            Inventory.CurrentProduct.Max = Int32.Parse(MProdMaxTextBox.Text);
            Inventory.CurrentProduct.Min = Int32.Parse(MProdMinTextBox.Text);

            Inventory.UpdateProduct(Convert.ToInt32(Inventory.CurrProductIndex), Inventory.CurrentProduct);
            this.Hide();
            Mainscreen p = new Mainscreen();
            p.Show();
        }

        private void MProdDGVParts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Inventory.CurrPartIndex = e.RowIndex;
            Inventory.CurrentPart = Inventory.AllParts[Inventory.CurrPartIndex];
        }

        private void MProdDGVAssocParts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Product.CurrAssocIndex = e.RowIndex;
            Product.CurrentAssocPart = Inventory.CurrentProduct.AssociatedParts[Product.CurrAssocIndex];
        }
    }
}
