using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Members.DataAccess;

namespace Members.Business
{
    public class Employee
    {
        int employeeid;
        string phoneNumber;
        string firstName;
        string lastName;
        string email;
        string identifier; // sales/manager/inventory/orders

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public int Employeeid { get => employeeid; set => employeeid = value; }
        public string Identifier { get => identifier; set => identifier = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

        public void Save(User emp)
        {
            EmployeeDA.Save(emp);
        }
        public string SearchEmployeeL(int employeeID, string password) // Searches for Log In 
        {
            return LogInDA.SearchEmployeeLogin(employeeID, password);
        }

        public List<Employee> SearchEmployeeByName(string input) // Searches by Name
        {
            return EmployeeDA.SearchEmployeeName(input);
        }

        public List<Employee> SearchEmployeeByLast(string input) // Searches by Name
        {
            return EmployeeDA.SearchEmployeeLastName(input);
        }

        public List<User> SearchEmployeeById(int employeeId)
        {
            return EmployeeDA.SearchEmployeeId(employeeId);
        }

        public void EmployeeDelete(int id)
        {
            EmployeeDA.DeleteEmployeeById(id);
        }

        public List<Employee> GetListEmployee()
        {
            return EmployeeDA.GetAllEmployees();
        }

        public void ListAll(ListView listViewE, List<Employee> listE)
        {
            listViewE.Items.Clear();
            foreach (Employee empItem in listE)
            {
                ListViewItem item = new ListViewItem(empItem.Employeeid.ToString());
                item.SubItems.Add(empItem.Identifier);
                item.SubItems.Add(empItem.FirstName);
                item.SubItems.Add(empItem.LastName);
                item.SubItems.Add(empItem.PhoneNumber);
                item.SubItems.Add(empItem.Email);
                listViewE.Items.Add(item);

            }

        }


        public string ComboIdentifier(int employeeId)
        {
            return EmployeeDA.IdentifierCombobox(employeeId);
        }

        public int ComboIndentifierIndex(int employeeid)
        {
            return EmployeeDA.IndexComboboxIdentify(employeeid);
        }
    }
}
