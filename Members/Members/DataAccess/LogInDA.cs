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
    class LogInDA
    {
        static string filePathLogin = Application.StartupPath + @"\Employee.dat";

        // Log In Exisits/Does not exit.
        public static string SearchEmployeeLogin(int employeeID, string password)
        {
            Employee emp = new Employee();
            string identifier = "";
            bool found = false;

            string empIdString = Convert.ToString(employeeID);

            if (File.Exists(filePathLogin))
            {
                using (StreamReader sr = new StreamReader(filePathLogin))
                {
                    string line = sr.ReadLine();

                    while (line != null && !found)
                    {
                        string[] fields = line.Split(',');
                        if (Convert.ToInt32(fields[0]) == employeeID)
                        {
                            if (fields[1] == password)
                            {
                                //MessageBox.Show("Found");
                                identifier = fields[2];
                                found = true;
                            }
                        }
                        else
                        {

                        }
                        line = sr.ReadLine();
                    }
                }
            }

            return identifier;
        }
    }
}
