using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.DataAccess;
using System.Windows.Forms;

namespace POS.Business
{
    public class Client
    {
        private string type;
        private string name;
        private string street;
        private string city;
        private string postalCode;
        private string phoneNumber;
        private string faxNumber;
        private decimal creditLimit;

        public string Name { get => name; set => name = value; }
        public string Street { get => street; set => street = value; }
        public string City { get => city; set => city = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string FaxNumber { get => faxNumber; set => faxNumber = value; }
        public decimal CreditLimit { get => creditLimit; set => creditLimit = value; }
        public string Type { get => type; set => type = value; }

        public void SaveClient(Client aClient)
        {
            ClientDA.SaveClient(aClient);
        }

        public List<Client> SearchClientName(string name)
        {
            return ClientDA.SearchClientName(name);

        } // search by name

        public List<Client> SearchClientStreet(string street)
        {
            return ClientDA.SearchClientStreet(street);
        } // search by street

        public List<Client> SearchClientCity(string city) // search by city
        {
            return ClientDA.SearchClientCity(city);
        }

        public List<Client> SearchClientPostalCode(string postalC) // search by city
        {
            return ClientDA.SearchClientPostalCode(postalC);
        }

        public List<Client> SearchClientType(string type) // search by city
        {
            return ClientDA.SearchClientType(type);
        }

        public int IdentifyType(string name)
        {
            return ClientDA.IdentifyType(name);
        }

        public void UpdateClient(Client client)
        {
            ClientDA.UpdateClient(client);
        }

        public void DeleteClient(string pc)
        {
            ClientDA.DeleteClient(pc);
        }

        public List<Client> ListAllClients()
        {
            return ClientDA.GetAllClient();
        }

        public void ListAll(ListView listViewC, List<Client> listC)
        {
            listViewC.Items.Clear();
            foreach (Client cItem in listC)
            {
                ListViewItem item = new ListViewItem(cItem.Type);
                item.SubItems.Add(cItem.Name);
                item.SubItems.Add(cItem.Street);
                item.SubItems.Add(cItem.City);
                item.SubItems.Add(cItem.PostalCode);
                item.SubItems.Add(cItem.PhoneNumber);
                item.SubItems.Add(cItem.FaxNumber);
                item.SubItems.Add(Convert.ToString(cItem.CreditLimit));
                listViewC.Items.Add(item);

            }

        }

    }
}
