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
            InhousePart newIPart = new InhousePart();                    
            //Inventory.CurrentPart = newIPart;

            OutsourcedPart newOPart = new OutsourcedPart();
            //Inventory.CurrentPart = newOPart;
        }

        private void APCancelButton_Click(object sender, EventArgs e)
        {
            Close();
            Mainscreen p = new Mainscreen();
            p.Show();
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
            if (APInhouseRadio.Checked)
            {

                InhousePart newIPart = new InhousePart();
                newIPart.PartID = Int32.Parse(APIDTextBox.Text);
                newIPart.Name = APNameTextBox.Text;
                newIPart.InStock = Int32.Parse(APInventoryTextBox.Text);
                newIPart.Price = Decimal.Parse(APPriceTextBox.Text);
                newIPart.Max = Int32.Parse(APMaxTextBox.Text);
                newIPart.Min = Int32.Parse(APMinTextBox.Text);
                newIPart.MachineID = Int32.Parse(APMachineIDTextBox.Text);
                Inventory.AddPart(newIPart);

            }
            else
            {
                OutsourcedPart newOPart = new OutsourcedPart();
                newOPart.PartID = Int32.Parse(APIDTextBox.Text);
                newOPart.Name = APNameTextBox.Text;
                newOPart.InStock = Int32.Parse(APInventoryTextBox.Text);
                newOPart.Price = Decimal.Parse(APPriceTextBox.Text);
                newOPart.Max = Int32.Parse(APMaxTextBox.Text);
                newOPart.Min = Int32.Parse(APMinTextBox.Text);
                newOPart.CompanyName = (APMachineIDTextBox.Text);
                Inventory.AddPart(newOPart);
            }


                //Inventory.UpdatePart(Convert.ToInt32(Inventory.CurrProductIndex), Inventory.CurrentPart);
                Close();
                Mainscreen p = new Mainscreen();
                p.Show();

        }

        private void APIDTextBox_TextChanged(object sender, EventArgs e)
        {
            //xx
        }
    }
}
