using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.DataAccess;
using System.Windows.Forms;
using POS.Validation;

namespace POS.Business
{
    [Serializable]
    public class Order : Client
    {
        private int orderId;
        private string orderDate;
        private string status; // Processing / Cancelled
        private int productNumber;
        private string productName;
        private string productType;
        private decimal price;

        public int OrderId { get => orderId; set => orderId = value; }
        public string OrderDate { get => orderDate; set => orderDate = value; }
        public string Status { get => status; set => status = value; }
        public int ProductNumber { get => productNumber; set => productNumber = value; }
        public string ProductName { get => productName; set => productName = value; }
        public string ProductType { get => productType; set => productType = value; }
        public decimal Price { get => price; set => price = value; }

        public bool VerifySoftware(int prodId)
        {
            return OrderDA.SearchByProductId(prodId);
        }

        public bool VerifyBook(int prodId)
        {
            return OrderDA.SearchByBookId(prodId);
        }

        public bool VerifyClient(string postalC, string name)
        {
            return OrderDA.VerifyClient(postalC, name);
        }


        public string SearchPrice(int pId)
        {
            return OrderDA.SearchByProductPrice(pId);
        }

        public void SaveOrderSoftware(Order order)
        {
            OrderDA.SaveOrderSoftware(order);
        }

        public void SaveOrderBook(Order order)
        {
            OrderDA.SaveOrderBook(order);
        }

        public List<Order> ListAllOrders()
        {
            return OrderDA.ListAllOrders();
        }

        public void ListViewAllOrder(ListView listViewC, List<Order> listC)
        {
            listViewC.Items.Clear();
            foreach (Order oItem in listC)
            {
                ListViewItem item = new ListViewItem(oItem.Type);
                item.SubItems.Add(oItem.orderId.ToString());
                item.SubItems.Add(oItem.Price.ToString());
                item.SubItems.Add(oItem.Status);
                item.SubItems.Add(oItem.OrderDate);
                item.SubItems.Add(oItem.productNumber.ToString());
                item.SubItems.Add(oItem.ProductName);
                item.SubItems.Add(oItem.Name);
                item.SubItems.Add(oItem.PhoneNumber);
                item.SubItems.Add(oItem.FaxNumber);
                item.SubItems.Add(oItem.PostalCode);
                item.SubItems.Add(Convert.ToString(oItem.CreditLimit));
                listViewC.Items.Add(item);

            }

        }

        public List<Order> ListByOrderId(string oId)
        {
            return OrderDA.SearchOrderId(oId);
        }

        public List<Order> ListByProductId(string pId)
        {
            return OrderDA.SearchProductId(pId);
        }
        public List<Order> ListByStatus(string status)
        {
            return OrderDA.SearchStatus(status);
        }
        public List<Order> ListByProductType(string pType)
        {
            return OrderDA.SearchProductType(pType);
        }
        public List<Order> ListByPostalC(string postalC)
        {
            return OrderDA.SearchPostalC(postalC);
        }
        public List<Order> ListByName(string cName)
        {
            return OrderDA.SearchClientName(cName);
        }

        public void UpdateOrderSoftware(Order anOrder)
        {
            OrderDA.UpdateOrderSoftware(anOrder);
        }

        public void UpdateOrderBook(Order anOrder)
        {
            OrderDA.UpdateOrderBook(anOrder);
        }

        public void CancelOrderBook(Order anOrder)
        {
            OrderDA.CancelOrderBook(anOrder);
        }

        public void CancelOrderSoftware(Order anOrder)
        {
            OrderDA.CancelOrderSoftware(anOrder);
        }

        public bool OrderExists(string oId)
        {
            return ValidatorPOS.OrderAlreadyExists(oId);
        }

        public void DeleteOrder(string oId)
        {
            OrderDA.DeleteOrder(oId);
        }

    }
}
