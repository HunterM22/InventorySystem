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
                MPMachineIDTextBox.Text = Inventory.CurrentPart.CompanyName;
                /////////System.NullReferenceException: 'Object reference not set to an instance of an object.'////////////
            }

        }

        private void MPCancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mainscreen o = new Mainscreen();
            o.Show();
        }

        private void MPInhouseRadio_CheckedChanged(object sender, EventArgs e)
        {
            MPMachineIDLabel.Text = "Machine ID";
            MPMachineIDTextBox.Text = Inventory.CurrentPart.MachineID.ToString();
        }

        private void MPOutsourcedRadio_CheckedChanged(object sender, EventArgs e)
        {
            MPMachineIDLabel.Text = "Company Name";
            MPMachineIDTextBox.Text = Inventory.CurrentPart.CompanyName;
        }

        private void MPSaveButton_Click(object sender, EventArgs e)
        {
            if (MPInhouseRadio.Checked)
            {

                //InhousePart newIPart = new InhousePart();
                Inventory.CurrentPart.PartID = Int32.Parse(MPIDTextBox.Text);
                Inventory.CurrentPart.Name = MPNameTextBox.Text;
                Inventory.CurrentPart.InStock = Int32.Parse(MPInventoryTextBox.Text);
                Inventory.CurrentPart.Price = Decimal.Parse(MPPriceTextBox.Text);
                Inventory.CurrentPart.Max = Int32.Parse(MPMaxTextBox.Text);
                Inventory.CurrentPart.Min = Int32.Parse(MPMinTextBox.Text);
                Inventory.CurrentPart.MachineID = Int32.Parse(MPMachineIDTextBox.Text);
                //Inventory.AddPart(newIPart);

            }
            else
            {
               // OutsourcedPart newOPart = new OutsourcedPart();
                Inventory.CurrentPart.PartID = Int32.Parse(MPIDTextBox.Text);
                Inventory.CurrentPart.Name = MPNameTextBox.Text;
                Inventory.CurrentPart.InStock = Int32.Parse(MPInventoryTextBox.Text);
                Inventory.CurrentPart.Price = Decimal.Parse(MPPriceTextBox.Text);
                Inventory.CurrentPart.Max = Int32.Parse(MPMaxTextBox.Text);
                Inventory.CurrentPart.Min = Int32.Parse(MPMinTextBox.Text);
                Inventory.CurrentPart.CompanyName = (MPMachineIDTextBox.Text);
                //Inventory.AddPart(newOPart);
            }


            Inventory.UpdatePart(Convert.ToInt32(Inventory.CurrProductIndex), Inventory.CurrentPart);
            this.Hide();
            Mainscreen o = new Mainscreen();
            o.Show();
         
        }
    }
}

