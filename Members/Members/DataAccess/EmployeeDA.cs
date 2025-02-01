using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Members.Business;

namespace Members.DataAccess
{
    class EmployeeDA
    {
        static string filePathEmployee = Application.StartupPath + @"\Employee.dat";
        static string filePathEmployeeTemp = Application.StartupPath + @"\EmployeeTemp.dat";

        //public static string Identifier(int employeeID) // Identify the Employee type (manager,sales,orders,inventory)
        //{
        //    bool found = false;
        //    string identifier = "";

        //    if (File.Exists(filePathEmployee))
        //    {
        //        using (StreamReader sr = new StreamReader(filePathEmployee))
        //        {
        //            string line = sr.ReadLine();
        //            string[] fields = line.Split(',');
        //            while (line != null && !found)
        //            {
        //                if (Convert.ToInt32(fields[0]) == employeeID)
        //                {
        //                    identifier = fields[2];
        //                    found = true;
        //                }
        //                else
        //                {
        //                    break;
        //                }
        //                line = sr.ReadLine();
        //            }
        //        }
        //    }

        //    return identifier;
        //}

        public static string IdentifierCombobox(int employeeID) // Identify the Employee type combobox(manager,sales,orders,inventory)
        {
            bool found = false;
            string comboboxTextIdentifier = "";

            if (File.Exists(filePathEmployee))
            {
                using (StreamReader sr = new StreamReader(filePathEmployee))
                {
                    string line = sr.ReadLine();

                    while (line != null && !found)
                    {
                        string[] fields = line.Split(',');
                        if (Convert.ToInt32(fields[0]) == employeeID)
                        {
                            if (fields[2] == "Manager")
                            {
                                comboboxTextIdentifier = "MIS Manager";
                            }
                            if (fields[2] == "Sales")
                            {
                                comboboxTextIdentifier = "Sales Manager";
                            }
                            if (fields[2] == "Inventory")
                            {
                                comboboxTextIdentifier = "Inventory Controller";
                            }
                            if (fields[2] == "Orders")
                            {
                                comboboxTextIdentifier = "Order Clerk";
                            }

                        }
                        else
                        {
                            break;
                        }
                        line = sr.ReadLine();
                    }
                }
            }



            return comboboxTextIdentifier;
        }

        public static int IndexComboboxIdentify(int employeeID) // Return index to print it(manager,sales,orders,inventory)
        {
            int comboboxIndex = 22;

            if (File.Exists(filePathEmployee))
            {
                using (StreamReader sr = new StreamReader(filePathEmployee))
                {
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        string[] fields = line.Split(',');
                        if (fields[0] == Convert.ToString(employeeID))
                        {
                            switch (fields[2])
                            {
                                case ("Manager"):
                                    comboboxIndex = 0;
                                    break;
                                case ("Sales"):
                                    comboboxIndex = 1;
                                    break;
                                case ("Inventory"):
                                    comboboxIndex = 2;
                                    break;
                                case ("Orders"):
                                    comboboxIndex = 3;
                                    break;
                                default:
                                    MessageBox.Show(Convert.ToString(comboboxIndex));
                                    break;
                            }

                        }

                        line = sr.ReadLine();
                    }
                }
            }

            return comboboxIndex;
        }

        public static void Save(User emp)
        {
            using (StreamWriter sw = new StreamWriter(filePathEmployee, append: true))
            {
                sw.WriteLine();
                sw.Write(emp.Employeeid + "," + emp.Password + "," + emp.Identifier + "," + emp.FirstName + "," + emp.LastName + "," + emp.PhoneNumber + "," + emp.Email);
            }
            MessageBox.Show("Employee information has been saved successfully.", "Success!", MessageBoxButtons.OK);


        }

        public static List<Employee> SearchEmployeeName(string input) // Search by first name
        {

            List<Employee> listE = new List<Employee>();
            StreamReader sr = new StreamReader(filePathEmployee, true);
            bool found = false;

            if (File.Exists(filePathEmployee))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (fields[3].ToUpper() == input.ToUpper())
                    {
                        found = true;
                        Employee emp = new Employee();
                        emp.Employeeid = Convert.ToInt32(fields[0]);
                        emp.Identifier = fields[2];
                        emp.FirstName = fields[3];
                        emp.LastName = fields[4];
                        emp.PhoneNumber = fields[5];
                        emp.Email = fields[6];

                        //add the Employee object to the list
                        listE.Add(emp);
                    }
                    line = sr.ReadLine();
                }

                sr.Close();
                if (!found)
                {
                    MessageBox.Show("'" + input + "'" + " does not exist.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("We were not able to find this file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listE;

        }

        public static List<Employee> SearchEmployeeLastName(string input) // Search by last name
        {

            List<Employee> listE = new List<Employee>();
            StreamReader sr = new StreamReader(filePathEmployee, true);
            bool found = false;

            if (File.Exists(filePathEmployee))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (fields[4].ToUpper() == input.ToUpper())
                    {
                        found = true;
                        Employee emp = new Employee();
                        emp.Employeeid = Convert.ToInt32(fields[0]);
                        emp.Identifier = fields[2];
                        emp.FirstName = fields[3];
                        emp.LastName = fields[4];
                        emp.PhoneNumber = fields[5];
                        emp.Email = fields[6];

                        //add the Emplotee object to the list
                        listE.Add(emp);
                    }
                    else
                    {
                    }
                    line = sr.ReadLine();
                }

                sr.Close();
                if (!found)
                {
                    MessageBox.Show("'" + input + "'" + " does not exist.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("We were not able to find this file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listE;

        }

        public static List<User> SearchEmployeeId(int employeeId) // Search by employee id
        {
            List<User> listE = new List<User>();
            StreamReader sr = new StreamReader(filePathEmployee);
            string employeeIdString = Convert.ToString(employeeId);
            bool found = false;

            if (File.Exists(filePathEmployee))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (fields[0] == employeeIdString)
                    {
                        found = true;
                        User emp = new User();
                        emp.Employeeid = Convert.ToInt32(fields[0]);
                        emp.Password = fields[1];
                        emp.Identifier = fields[2];
                        emp.FirstName = fields[3];
                        emp.LastName = fields[4];
                        emp.PhoneNumber = fields[5];
                        emp.Email = fields[6];

                        listE.Add(emp);
                    }
                    else
                    {

                    }
                    line = sr.ReadLine();
                }
                sr.Close();

                if (!found)
                {
                    MessageBox.Show("'" + employeeIdString + "'" + " does not exist.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("We were not able to find this file.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listE;
        }

        public static void DeleteEmployeeById(int id)
        {
            if (File.Exists(filePathEmployee))
            {
                StreamReader sr = new StreamReader(filePathEmployee);
                StreamWriter sw = new StreamWriter(filePathEmployeeTemp, true);


                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(','); // dont forget to put the comma
                    if (Convert.ToInt32(fields[0]) != id) // if its not = to the id asked to delete then...
                    {
                        sw.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3] + "," + fields[4] + "," + fields[5] + "," + fields[6]);
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
                sw.Close();

            }
            File.Delete(filePathEmployee);
            File.Move(filePathEmployeeTemp, filePathEmployee);

        }

        public static List<Employee> GetAllEmployees()
        {
            List<Employee> listAllEmployees = new List<Employee>();
            if (File.Exists(filePathEmployee))
            {
                using (StreamReader sr = new StreamReader(filePathEmployee))
                {
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        string[] fields = line.Split(',');
                        Employee emp = new Employee();

                        emp.Employeeid = Convert.ToInt32(fields[0]);
                        emp.Identifier = fields[2];
                        emp.FirstName = fields[3];
                        emp.LastName = fields[4];
                        emp.PhoneNumber = fields[5];
                        emp.Email = fields[6];

                        listAllEmployees.Add(emp);
                        line = sr.ReadLine();

                    }
                }
            }
            else
            {
                listAllEmployees = null;
                MessageBox.Show("File was not found.", "Sorry!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return listAllEmployees;
        }

        public static void UpdateEmployee(User emp) // If mistake was made, update to fix
        {
            if (File.Exists(filePathEmployee))
            {
                StreamReader sr = new StreamReader(filePathEmployee);
                StreamWriter sw = new StreamWriter(filePathEmployeeTemp, true);

                //read the first line
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (Convert.ToInt32(fields[0]) != emp.Employeeid)
                    {
                        sw.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3] + "," + fields[4] + "," + fields[5] + "," + fields[6]);
                    }
                    line = sr.ReadLine();
                }
                sw.WriteLine(emp.Employeeid + "," + emp.Password + "," + emp.Identifier + "," + emp.FirstName + "," + emp.LastName + "," + emp.PhoneNumber);
                sr.Close();
                sw.Close();
            }

            File.Delete(filePathEmployee);
            File.Move(filePathEmployeeTemp, filePathEmployee);

        }

        public static string ComboIdentify(object selectedItem)
        {
            string comboItem = "";

            object myObject = selectedItem;
            string myObjectString = myObject.ToString();

            //MessageBox.Show(myObjectString);

            switch (myObjectString)
            {
                case ("MIS Manager"):
                    comboItem = "Manager";
                    break;
                case ("Sales Manager"):
                    comboItem = "Sales";
                    break;
                case ("Inventory Controller"):
                    comboItem = "Inventory";
                    break;
                case ("Order Clerk"):
                    comboItem = "Orders";
                    break;
                default:
                    break;
            }

            return comboItem;
        }
    }
}
