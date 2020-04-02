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
    public partial class Mainscreen : Form
    {
        public int currPart { get; set; }
        public int currProd { get; set; }



        public Mainscreen()
        {
            InitializeComponent();
            MSDGVParts.DataSource = Inventory.AllParts;
            MSDGVProducts.DataSource = Inventory.Products;
        }

        private void MSAddPartButton_Click(object sender, EventArgs e)
        {
            
            AddPartForm AddAPart = new AddPartForm();
            AddAPart.ShowDialog();
        }

        public void Mainscreen_Load(object sender, EventArgs e)
        {
            MSDGVParts.AutoGenerateColumns = true;
            MSDGVProducts.AutoGenerateColumns = true;

            MSDGVParts.DataSource = Inventory.AllParts;
            MSDGVProducts.DataSource = Inventory.Products;

            dgvFormatter(MSDGVParts);
            dgvFormatter(MSDGVProducts);
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

        private void DGVCellClick(object sender, DataGridViewCellEventArgs e)
        {//MSPartsDGV
            Inventory.CurrPartIndex = e.RowIndex;
        }

        private void MSExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MSModifyPartButton_Click(object sender, EventArgs e)
        {/////
            if (Inventory.CurrPartIndex >= 0)
            {
                this.Hide();
                ModifyPartForm modpart = new ModifyPartForm();
                modpart.ShowDialog();
            }
            else
            {
                MessageBox.Show("There are no parts to modify.", "Error");
            }

        }

        private void MSDeletePartButton_Click(object sender, EventArgs e)
        {
            if (Inventory.CurrPartIndex >= 0)
            {
                //good
                Inventory.DeletePart(Inventory.CurrentPart);
            }
            else
            {
                MessageBox.Show("There is nothing to delete.", "Delete Error");
            }
            
            //if (MSDGVParts.RowCount > 0)
            //{
            //    DialogResult result = MessageBox.Show("Are you sure you want to delete this part?", "Delete Part", MessageBoxButtons.YesNo);
            //    if (result == DialogResult.Yes)
            //    {
            //        int row = MSDGVParts.CurrentCell.RowIndex;
            //        MSDGVParts.Rows.RemoveAt(row);
            //        Inventory.DeletePart(Inventory.LookupPart(currPart));
            //    }
            //    return;

            //}
            //else
            //{
            //    MessageBox.Show("There is nothing to delete.", "Delete Error");
            //}
        }

        private void MSAddProductButton_Click(object sender, EventArgs e)
        {
            
            AddProductForm AddAProd = new AddProductForm();

            AddAProd.ShowDialog();
        }

        private void MSModifyProductButton_Click(object sender, EventArgs e)
        {
            if (Inventory.CurrProductIndex >= 0)
            {
                this.Hide();
                ModifyProductForm modprod = new ModifyProductForm();
                modprod.ShowDialog();
            }
            else
            {
                MessageBox.Show("There are no products to modify.", "Error");
            }
        }

        private void MSDeleteProductButton_Click(object sender, EventArgs e)
        {
            if (Inventory.CurrProductIndex >= 0)
            {
                //good
                Inventory.RemoveProduct(Inventory.CurrProductIndex);
            }
            else
            {
                MessageBox.Show("There is nothing to delete.", "Delete Error");
            }

        }

        private void MSSearchPartsButton_Click(object sender, EventArgs e)
        {
            string searchValue = MSPartsSearchBox.Text;
            foreach (DataGridViewRow row in MSDGVParts.Rows)
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

        private void MSPartsSearchBox_TextChanged(object sender, EventArgs e)
        {
            //do not use
        }

        private void MSProductSearchButton_Click(object sender, EventArgs e)
        {
            string searchValue = MSProductSearchBox.Text;
            foreach (DataGridViewRow row in MSDGVProducts.Rows)
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

        private void MSProductSearchBox_TextChanged(object sender, EventArgs e)
        {
            //do not use
        }

        private void DGVProd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Inventory.CurrProductIndex = e.RowIndex;
            
            //int row = MSDGVProducts.CurrentCell.RowIndex;
            //currProd = Convert.ToInt32(MSDGVProducts.Rows[row].Cells[0].Value.ToString());
        }

        private void MSDGVParts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //do not use
        }
    }
}
