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

            AProdDGVParts.AutoGenerateColumns = true;
            AProdDGVAssocParts.AutoGenerateColumns = true;

            AProdDGVParts.DataSource = Inventory.AllParts;
            // MProdDGVAssocParts.DataSource = Product.AssociatedParts;

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
            this.Close();
        }

        private void AProdDGVParts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = AProdDGVParts.CurrentCell.RowIndex;
            currPart = Convert.ToInt32(AProdDGVParts.Rows[row].Cells[0].Value.ToString());
        }

        private void AProdDGVAssocParts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        }

        private void AProdDeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void AProdSaveButton_Click(object sender, EventArgs e)
        {

        }
    }
}
