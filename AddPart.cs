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
    public partial class AddPartForm : Form
    {
        public AddPartForm()
        {
            InitializeComponent();
        }

        private void APCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void APInhouseRadio_CheckedChanged(object sender, EventArgs e)
        {
            APMachineIDLabel.Text = "Machine ID";
            APMachineIDTextBox.Text = "";
        }

        private void APOutsourcedRadio_CheckedChanged(object sender, EventArgs e)
        {
            APMachineIDLabel.Text = "Company Name";
            APMachineIDTextBox.Text = "";
        }

        private void APMachineIDLabel_Click(object sender, EventArgs e)
        {
            APMachineIDLabel.TextAlign = ContentAlignment.TopRight;
        }

        private void APSaveButton_Click(object sender, EventArgs e)
        {
            Inventory.UpdatePart(Convert.ToInt32(Inventory.CurrProductIndex), Inventory.CurrentPart);
            this.Hide();
            Mainscreen p = new Mainscreen();
            p.Show();

        }

        private void APIDTextBox_TextChanged(object sender, EventArgs e)
        {
            //xx
        }
    }
}
