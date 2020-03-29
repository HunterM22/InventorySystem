using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace InventorySystem
{
    public class Inventory
    {
        //Properties
        public static BindingList<Product> Products = new BindingList<Product>();
        public static BindingList<PartObject> AllParts = new BindingList<PartObject>();

        //PRODUCT METHODS

        //Add Product
        public static void AddProduct(Product product)
        {
            Products.Add(product);
        }

        //Remove Product
        public static bool RemoveProduct(int ProductID)
        {

        }
        //Lookup Product
        public static Product LookupProduct(int productID)
        {

        }

        //Update Product
        public static void UpdateProduct(int productID, Product updatedProduct)
        {

        }

        //PARTS METHODS-----------------

        //Add Part
        public static void AddPart(PartObject part)
        {
            AllParts.Add(part);
        }

        //Remove Part
        public static bool DeletePart(PartObject part)
        {

        }

        //Lookup Part
        public static PartObject LookupPart(int partID)
        {

        }

        //Update Part Outsourced
        public static void UpdatePart(int PartObject)
        {

        }

    }

}
