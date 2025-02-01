using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Members.DataAccess;

namespace Members.Business
{
    public class User : Employee
    {
        int userId;
        string password;

        public int UserId { get => userId; set => userId = value; }
        public string Password { get => password; set => password = value; }

        public void EmployeeUpdate(User emp)
        {
            EmployeeDA.UpdateEmployee(emp);
        }

        public int IndexCBIdentify(int eId)
        {
            return UserDA.IndexComboboxIdentify(eId);
        }

        public string IdentifierCombobox(int eId)
        {
            return IdentifierCombobox(eId);
        }

        public string IdentifyComboBox(object selectedItem)
        {
            return EmployeeDA.ComboIdentify(selectedItem);
        }

        public List<User> FindEmployeeUser(int employeeid)
        {
            return UserDA.FindEmployeeById(employeeid);
        }

        public List<User> FindEmployeeName(string fname)
        {
            return UserDA.SearchEmployeeNameUser(fname);
        }

        public List<User> FindEmployeeLastName(string lname)
        {
            return UserDA.SearchEmployeeLastNameUser(lname);
        }

        public User FindEmployeeToUpdate(int emp)
        {
            return UserDA.FindEmployeeToUpdate(emp);
        }

        public List<User> GetListUser()
        {
            return UserDA.GetAllEmployees();
        }

        public void ListAll(ListView listViewU, List<User> listU)
        {
            listViewU.Items.Clear();
            foreach (User uItem in listU)
            {
                ListViewItem item = new ListViewItem(uItem.Employeeid.ToString());
                item.SubItems.Add(uItem.Identifier);
                item.SubItems.Add(uItem.Password);
                listViewU.Items.Add(item);

            }

        }

        public void UpdateUser(User u)
        {
            UserDA.UpdateUser(u);
        }
    }
}
