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
    public partial class AddProductForm : Form
    {
        public int currPart { get; private set; }

        public AddProductForm()
        {
            InitializeComponent();

            Product newProd = new Product();
            Inventory.CurrentProduct = newProd;

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
            Mainscreen o = new Mainscreen();
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
            AProdDGVAssocParts.DataSource = Inventory.CurrentProduct.AssociatedParts;
            AProdDGVParts.DataSource = Inventory.AllParts;


            //this.Hide();
            //AddProductForm o = new AddProductForm();
            //o.Show();
        }

        private void AProdDeleteButton_Click(object sender, EventArgs e)
        {
            Inventory.CurrentProduct.RemoveAssociatedPart(Inventory.CurrAssocIndex);

            AProdDGVAssocParts.DataSource = Inventory.CurrentProduct.AssociatedParts;
            
            //AProdDGVParts.DataSource = Inventory.AllParts;
            //this.Hide();
            //AddProductForm o = new AddProductForm();
            //o.Show();
        }

        private void AProdSaveButton_Click(object sender, EventArgs e)
        {
            //Product newProd = new Product();
            Inventory.CurrentProduct.ProductID = Int32.Parse(AProdIDTextBox.Text);//update to currentproduct
            Inventory.CurrentProduct.Name = AProdNameTextBox.Text;
            Inventory.CurrentProduct.InStock = Int32.Parse(AProdInventoryTextBox.Text);
            Inventory.CurrentProduct.Price = Decimal.Parse(AProdPriceTextBox.Text);
            Inventory.CurrentProduct.Max = Int32.Parse(AProdMaxTextBox.Text);
            Inventory.CurrentProduct.Min = Int32.Parse(AProdMinTextBox.Text);
            
            Inventory.AddProduct(Inventory.CurrentProduct);
                 
            Close();
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
            Inventory.CurrAssocIndex = e.RowIndex;
            Inventory.CurrentAssocPart = Inventory.CurrentProduct.AssociatedParts[Inventory.CurrAssocIndex];
                
                //Inventory.AllParts[Inventory.CurrPartIndex];
                
                //CurrentProduct.AssociatedParts[Product.CurrAssocIndex];
        }
    }
}
