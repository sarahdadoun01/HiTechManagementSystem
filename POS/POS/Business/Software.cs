using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.DataAccess;
using POS.Validation;

namespace POS.Business
{
    [Serializable]
    public class Software : Product
    {
        private string version;
        private string status;
        private string os;
        private string price;
        // licence key for orders

        public string Status { get => status; set => status = value; }
        public string Os { get => os; set => os = value; }
        public string Version { get => version; set => version = value; }
        public string Price { get => price; set => price = value; }

        public List<Software> ListSoftwares { get; set; }

        public void SaveSoftware(Software software)
        {
            SoftwareDA.Save(software);
        }

        public List<Software> ListAllSoftwares()
        {
            return SoftwareDA.GetListSoftwares();
        }

        public void UpdateSoftware(int pId, Software aSoftware)
        {
            SoftwareDA.UpdateSoftware(pId, aSoftware);
        }

        public void DeleteSoftware(int pId)
        {
            SoftwareDA.DeleteSoftware(pId);
        }

        public Software SearchSoftId(int prodId)
        {
            return SoftwareDA.SearchByProductId(prodId);
        }

        // to search a type list by title
        public List<Software> SearchSoftByTitle(string title)
        {
            return SoftwareDA.GetListByTitle(title);
        }

        public List<Software> SearchSoftByOs(string os)
        {
            return SoftwareDA.GetListByOS(os);
        }

        public List<Software> SearchByStatus(string status)
        {
            return SoftwareDA.GetListByStatus(status);
        }

    }
}
