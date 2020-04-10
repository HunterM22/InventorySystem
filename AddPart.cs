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
           
            OutsourcedPart newOPart = new OutsourcedPart();
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
            if (Convert.ToInt32(APMaxTextBox.Text) > Convert.ToInt32(APMinTextBox.Text))
            {
                if (APInhouseRadio.Checked)
                {

                    InhousePart newIPart = new InhousePart();
                    newIPart.PartID = Inventory.createPartID();
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
                    newOPart.PartID = Inventory.createPartID();
                    newOPart.Name = APNameTextBox.Text;
                    newOPart.InStock = Int32.Parse(APInventoryTextBox.Text);
                    newOPart.Price = Decimal.Parse(APPriceTextBox.Text);
                    newOPart.Max = Int32.Parse(APMaxTextBox.Text);
                    newOPart.Min = Int32.Parse(APMinTextBox.Text);
                    newOPart.CompanyName = (APMachineIDTextBox.Text);
                    Inventory.AddPart(newOPart);
                }

                Close();
                Mainscreen p = new Mainscreen();
                p.Show();
            }
            else
            {
                MessageBox.Show("Your min value is greater than the max value.", "Error");
            }


        }

        private void APIDTextBox_TextChanged(object sender, EventArgs e)
        {
            //xx
        }
    }
}
