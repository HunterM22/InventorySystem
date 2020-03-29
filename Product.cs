using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace InventorySystem
{
    public class Product
    {
        public BindingList<Part> AssociatedParts = new BindingList<Part>();

        //Property
        public Product(int productID, string name, int inStock, decimal price,
            int max, int min)
        {
            ProductID = productID;
            Name = name;
            InStock = inStock;
            Price = price;
            Max = max;
            Min = min;

        }

        public Product() { }

            public int ProductID { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int InStock { get; set; }
            public int Min { get; set; }
            public int Max { get; set; }


        //METHODS

        //Add Associated Part
        public void AddAssociatedPart(Part PartObject)
        {
            AssociatedParts.Add(PartObject);
        }

        //Remove Associated Part
        public bool RemoveAssociatedPart(int partID)
        {
            bool success = false;
            foreach (Part part in AssociatedParts)
            {
                if (part.PartID == partID)
                {
                    AssociatedParts.Remove(part);
                    return success = true;
                }
                else
                {
                    success = false;
                }
            }
            return success;

        }
        
        //Lookup Associated Part
        public Part LookupAssociatedPart(int PartID)
        {
            foreach (Part part in AssociatedParts)
            {
                if (part.PartID == PartID)
                {
                    return part;
                }
            }

            MessageBox.Show("No Part Found");
            return null;
        }
    }  
    
}

