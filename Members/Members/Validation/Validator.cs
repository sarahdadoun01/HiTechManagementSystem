using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Members.Validation
{
    public class Validator
    {
        static string filePathEmployee = Application.StartupPath + @"\Employee.dat";
        static string filePathClients = Application.StartupPath + @"\Client.dat";

        //ID
        public static bool IsValidId(string input, int size)
        {

            if (Regex.IsMatch(input, @"^\d{" + size + "}$")) // size is 4
            //                     ^ = beginning
            //                     $ = end of ling of string
            //                     \d = matches a digit

            {
                return true;
            }

            return false;
        }

        // Password
        public static bool IsValidPassword(string input, int size)
        {

            if (Regex.IsMatch(input, @"^[a-zA-Z0-9]{" + size + "}$")) // size is 6
            //                     ^ = beginning
            //                     $ = end of ling of string
            //                     \d = matches a digit

            {
                return true;
            }

            return false;
        }

        //If ID Already Exists or Not
        public static bool AlreadyExists(string input)
        {

            bool found = false;

            if (File.Exists(filePathEmployee))
            {
                using (StreamReader sr = new StreamReader(filePathEmployee))
                {
                    string line = sr.ReadLine();
                    while (line != null && !found)
                    {
                        string[] fields = line.Split(',');
                        if (input == fields[0])
                        {
                            found = true;
                        }
                        else
                        {

                        }
                        line = sr.ReadLine();
                    }
                }
            }

            return found;
        }

        // Email
        public static bool IsValidEmail(string email)
        {

            if (Regex.IsMatch(email, @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                                    + @"([-a-z-0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\..)*)(?<!\.)"
                                    + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$"))
            {
                return true;
            }

            return false;
        }

        //Phone Number
        public static bool IsValidNumber(string number, int size)
        {

            if (Regex.IsMatch(number, @"^\d{" + size + "}$"))
            {
                return true;
            }

            return false;

        }

        // Name Validation
        public static bool IsValidName(string words)
        {
            if (Regex.IsMatch(words, @"^[A-Za-z\s]|[A-Za-z\s][ -][A-Za-z\s]*$"))
            {
                return true;
            }
            return false;
        }

        

        
    }
}
