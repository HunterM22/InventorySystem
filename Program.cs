using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //// Populate the parts and product lists
            //Inventory.AddProduct(new Product(0, "Red Bicycle", 15, 11.44M, 1, 25));
            //Inventory.AddProduct(new Product(1, "Yellow Bicycle", 19, 9.66M, 1, 20));
            //Inventory.AddProduct(new Product(2, "Blue Bicycle", 5, 12.77M, 1, 25));

            //Inventory.AddPart(new InHousePart(0, "Wheel", 15, 12.11M, 5, 25, 4571)); //machine id
            //Inventory.AddPart(new OutsourcedPart(1, "Pedal", 11, 8.22M, 5, 25, "Pedal Company")); //company name
            //Inventory.AddPart(new InHousePart(2, "Chain", 12, 8.33M, 5, 25, 8647)); //machine id
            //Inventory.AddPart(new OutsourcedPart(3, "Seat", 8, 4.55M, 2, 15, "Bikes For All, Inc.")); //company name
            //                                                                                          //end populate list


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Mainscreen());
        }
    }
}
