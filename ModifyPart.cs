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
    public partial class ModifyPartForm : Form
    {
        public ModifyPartForm()
        {
            InitializeComponent();
            //Get current part from Mainscreen selected index
            Inventory.CurrentPart = Inventory.AllParts[Inventory.CurrPartIndex];
            //Populate fields for selected part into the Modify form
            MPIDTextBox.Text = Inventory.CurrentPart.PartID.ToString();
            MPNameTextBox.Text = Inventory.CurrentPart.Name;
            MPPriceTextBox.Text = Inventory.CurrentPart.Price.ToString();
            MPInventoryTextBox.Text = Inventory.CurrentPart.InStock.ToString();
            MPMinTextBox.Text = Inventory.CurrentPart.Min.ToString();
            MPMaxTextBox.Text = Inventory.CurrentPart.Max.ToString();

            if (Inventory.CurrentPart is InhousePart)
            {
                MPMachineIDLabel.Text = "Machine ID";
                MPInhouseRadio.Checked = true;
                MPMachineIDTextBox.Text = Inventory.CurrentPart.MachineID.ToString();
            }
            else if (Inventory.CurrentPart is OutsourcedPart)
            {
                MPMachineIDLabel.Text = "Company Name";
                MPOutsourcedRadio.Checked = true;
                MPMachineIDTextBox.Text = Inventory.CurrentPart.CompanyName.ToString();
                /////////System.NullReferenceException: 'Object reference not set to an instance of an object.'////////////
            }

        }

        private void MPCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Mainscreen o = new Mainscreen();
            o.Show();
        }

        private void MPInhouseRadio_CheckedChanged(object sender, EventArgs e)
        {
            MPMachineIDLabel.Text = "Machine ID";
            MPMachineIDTextBox.Text = "";
        }

        private void MPOutsourcedRadio_CheckedChanged(object sender, EventArgs e)
        {
            MPMachineIDLabel.Text = "Company Name";
            MPMachineIDTextBox.Text = "";
        }

        private void MPSaveButton_Click(object sender, EventArgs e)
        {
            Inventory.UpdatePart(Convert.ToInt32(Inventory.CurrProductIndex), Inventory.CurrentPart);
            this.Hide();
            Mainscreen p = new Mainscreen();
            p.Show();
         
        }
    }
}

