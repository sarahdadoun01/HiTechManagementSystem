using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Members.Business;
using System.IO;
using System.Windows.Forms;

namespace Members.DataAccess
{
    public class UserDA
    {
        static string filePathEmployee = Application.StartupPath + @"\Employee.dat";
        static string filePathEmployeeTemp = Application.StartupPath + @"\EmployeeTemp.dat";

        public static List<User> FindEmployeeById(int employeeid) // Search All Employee Information by ID
        {

            List<User> listE = new List<User>();
            StreamReader sr = new StreamReader(filePathEmployee, true);
            string employeeidString = Convert.ToString(employeeid);

            if (File.Exists(filePathEmployee))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (fields[0] == employeeidString)
                    {
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
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            else
            {
                MessageBox.Show("We were not able to find this file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listE;

        }

        public static User FindEmployeeToUpdate(int employeeid) // Search All Employee Information by ID
        {

            User user = new User();
            StreamReader sr = new StreamReader(filePathEmployee, true);
            string employeeidString = Convert.ToString(employeeid);

            if (File.Exists(filePathEmployee))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (fields[0] == employeeidString)
                    {
                        User emp = new User();
                        user.Employeeid = Convert.ToInt32(fields[0]);
                        user.Password = fields[1];
                        user.Identifier = fields[2];
                        user.FirstName = fields[3];
                        user.LastName = fields[4];
                        user.PhoneNumber = fields[5];
                        user.Email = fields[6];
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            else
            {
                MessageBox.Show("We were not able to find this file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return user;

        }

        public static int IndexComboboxIdentify(int employeeID) // Return index to print it(manager,sales,orders,inventory)
        {
            User emp = new User();
            bool found = false;
            int comboboxIndex = 0;

            string empIdString = Convert.ToString(employeeID);

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
                                comboboxIndex = 0;
                            }
                            if (fields[2] == "Sales")
                            {
                                comboboxIndex = 1;
                            }
                            if (fields[2] == "Inventory")
                            {
                                comboboxIndex = 2;
                            }
                            if (fields[2] == "Orders")
                            {
                                comboboxIndex = 3;
                            }

                        }
                        line = sr.ReadLine();
                    }
                }
            }

            return comboboxIndex;
        }

        public static List<User> SearchEmployeeNameUser(string input) // Search by first name
        {

            List<User> listE = new List<User>();
            StreamReader sr = new StreamReader(filePathEmployee, true);

            if (File.Exists(filePathEmployee))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (fields[3].ToUpper() == input.ToUpper())
                    {
                        User emp = new User();
                        emp.Employeeid = Convert.ToInt32(fields[0]);
                        emp.Identifier = fields[2];
                        emp.Password = fields[1];

                        //add the Emplotee object to the list
                        listE.Add(emp);
                    }
                    else
                    {
                        sr.Close();
                        MessageBox.Show("'" + input + "'" + " does not exist.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    line = sr.ReadLine();
                }

                sr.Close();

            }
            else
            {
                MessageBox.Show("We were not able to find this file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listE;

        }

        public static List<User> SearchEmployeeLastNameUser(string input) // Search by last name
        {

            List<User> listU = new List<User>();
            StreamReader sr = new StreamReader(filePathEmployee, true);

            if (File.Exists(filePathEmployee))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (fields[4].ToUpper() == input.ToUpper())
                    {
                        User emp = new User();
                        emp.Employeeid = Convert.ToInt32(fields[0]);
                        emp.Password = fields[1];
                        emp.Identifier = fields[2];
                        listU.Add(emp);
                    }
                    else
                    {
                        sr.Close();
                        MessageBox.Show("'" + input + "'" + " does not exist.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    line = sr.ReadLine();
                }

                sr.Close();

            }
            else
            {
                MessageBox.Show("We were not able to find this file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listU;

        }

        public static List<User> GetAllEmployees()
        {
            List<User> listAllUsers = new List<User>();
            if (File.Exists(filePathEmployee))
            {
                using (StreamReader sr = new StreamReader(filePathEmployee))
                {
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        string[] fields = line.Split(',');
                        User user = new User();

                        user.Employeeid = Convert.ToInt32(fields[0]);
                        user.Identifier = fields[2];
                        user.Password = fields[1];

                        listAllUsers.Add(user);
                        line = sr.ReadLine();

                    }
                }
            }
            else
            {
                listAllUsers = null;
                MessageBox.Show("File was not found.", "Sorry!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return listAllUsers;
        }

        public static string IdentifierCombobox(int employeeID) // Identify the Employee type combobox(manager,sales,orders,inventory)
        {
            User emp = new User();
            bool found = false;
            string comboboxTextIdentifier = "";

            string empIdString = Convert.ToString(employeeID);

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

        public static void UpdateUser(User u) // update user to change password/userid/identifier
        {
            if (File.Exists(filePathEmployee))
            {
                StreamReader sr = new StreamReader(filePathEmployee);
                StreamWriter sw = new StreamWriter(filePathEmployeeTemp, true);

                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (Convert.ToInt32(fields[0]) != u.Employeeid)
                    {
                        sw.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3] + "," + fields[4] + "," + fields[5] + "," + fields[6] + "," + fields[7]);
                    }
                    line = sr.ReadLine();
                }
                sw.WriteLine(u.Employeeid + "," + u.Password + "," + u.Identifier + "," + u.FirstName + "," + u.LastName + "," + u.PhoneNumber);
                sr.Close();
                sw.Close();
            }

            File.Delete(filePathEmployee);
            File.Move(filePathEmployeeTemp, filePathEmployee);

        }
    }
}
