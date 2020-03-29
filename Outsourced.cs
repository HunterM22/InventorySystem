using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem
{
    public class OutsourcedPart : PartObject

    {
        //Property
        private string companyName;

        public new string CompanyName { get; set; }

        //Constructor 
        public OutsourcedPart(int partID, string name, int inStock, decimal price,
            int max, int min, string companyName)
        {
            PartID = partID;
            Name = name;
            InStock = inStock;
            Price = price;
            Max = max;
            Min = min;
            CompanyName = companyName;
        }
    }
}
