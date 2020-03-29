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
        public Mainscreen()
        {
            InitializeComponent();
        }

        private void MSAddPartButton_Click(object sender, EventArgs e)
        {

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
    }
}
