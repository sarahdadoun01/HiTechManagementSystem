using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.DataAccess;

namespace POS
{
    [Serializable]
    public class Product
    {
        private int productNumber;
        private string productName;
        private string productType; // software/book 

        public int ProductNumber { get => productNumber; set => productNumber = value; }
        public string ProductName { get => productName; set => productName = value; }
        public string ProductType { get => productType; set => productType = value; }
    }
}
