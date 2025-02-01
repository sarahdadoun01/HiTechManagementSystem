using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;
using POS.Business;

namespace POS.Validation
{
    public class ValidatorPOS
    {
        // File Path Orders
        static string filePathOrders = Application.StartupPath + @"\Orders.dat";
        // File Path Clients
        static string filePathClients = Application.StartupPath + @"\Client.dat";
        // File Path Software
        static string dir = @"";
        static string filePathSoftware = dir + "Software.bin";
        // File Path Book
        static string filePathBook = dir + "Book.bin";

        // ID Validation
        public static bool IsValidId(string input, int size)
        {

            if (Regex.IsMatch(input, @"^\d{" + size + "}$"))
            {
                return true;
            }

            return false;
        }

        // Name Validation
        public static bool IsValidName(string name)
        {
            if (Regex.IsMatch(name, @"^[A-Za-z\s]|[A-Za-z\s][ -?][A-Za-z\s]*$"))
            {
                return true;
            }
            return false;
        }

        // Book title validation 
        public static bool IsValidTitle(string title)
        {
            if (Regex.IsMatch(title, @"^[A-Za-z0-9\w\S\s\v]*|[A-Za-z0-9\w\S\s\v]*[ -?][A-Za-z0-9\w\S\s\v]*$"))
            {
                return true;
            }
            return false;
        }

        // OS Validation
        public static bool IsValidOS(string os)
        {
            if (Regex.IsMatch(os, @"^[A-Za-z\s]|[A-Za-z\s0-9]*|[A-Za-z\s][ -][A-Za-z\s]|[A-Za-z\s0-9][ -][A-Za-z\s0-9]*$"))
            {
                return true;
            }
            return false;
        }

        // Version Validation
        public static bool IsValidVersion(string version)
        {
            if (Regex.IsMatch(version, @"^\$?((\d{1}|\d{2}|\d{3})*.(\d{1}|\d{2}|\d{3}))$"))
            {
                return true;
            }
            return false;
        }

        // Year Validation
        public static bool IsValidYear(string year)
        {
            if (Regex.IsMatch(year, @"^\d{4}$"))
            {
                return true;
            }
            return false;
        }

        // Date Validation
        public static bool IsValidDate(string date)
        {
            if (Regex.IsMatch(date, @"^((\d{2})[/](\d{2})[/](\d{4}))$"))
            {
                return true;
            }
            return false;
        }

        // Money Validation
        public static bool IsValidMoney(string money)
        {
            if (Regex.IsMatch(money, @"^\$?(\d{1,3},?(\d{3},?)*\d{3}(.\d{0,3})?|\d{1,3}(.\d{2})?)$"))
            {
                return true;
            }
            return false;
        }

        //Postal Code
        public static bool IsValidPostalCode(string postalC)
        {
            //if (Regex.IsMatch(postalC, @"^[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ]?[0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]$"))
            //{
            //    return true;
            //}
            if (Regex.IsMatch(postalC.ToUpper(), @"\A[ABCEGHJKLMNPRSTVXY]\d[A-Z] ?\d[A-Z]\d\z"))
            {
                return true;
            }

            return false;
        }

        // If Order Exists
        public static bool OrderAlreadyExists(string oId)
        {
            bool found = false;
            if (File.Exists(filePathOrders))
            {
                using (StreamReader sr = new StreamReader(filePathOrders))
                {
                    string line = sr.ReadLine();
                    while (line != null && !found)
                    {
                        string[] fields = line.Split(',');
                        if (oId == fields[0])
                        {
                            found = true;
                        }
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }
            }

            return found;
        }

        // If Product Exists
        public static bool SoftwareAlreadyExists(string pId)
        {
            bool found = false;
            FileStream fs = new FileStream(filePathSoftware, FileMode.Open, FileAccess.Read);
            BinaryFormatter binF = new BinaryFormatter();

            if (File.Exists(filePathSoftware))
            {
                while (fs.Position < fs.Length)
                {
                    Software aSoftw = new Software();
                    aSoftw = (Software)binF.Deserialize(fs);
                    MessageBox.Show("" + aSoftw.ProductNumber);
                    if (aSoftw.ProductNumber == Convert.ToInt32(pId))
                    {
                        found = true;
                    }

                }
                fs.Close();
            }

            return found;

        }

        // If Book Exists
        public static bool BookAlreadyExists(string pId)
        {
            bool found = false;
            FileStream fs = new FileStream(filePathBook, FileMode.Open, FileAccess.Read);
            BinaryFormatter binF = new BinaryFormatter();

            if (File.Exists(filePathBook))
            {
                while (fs.Position < fs.Length)
                {
                    Book aBook = new Book();
                    aBook = (Book)binF.Deserialize(fs);
                    if (aBook.ProductNumber == Convert.ToInt32(pId))
                    {
                        found = true;
                    }

                }
                fs.Close();
            }

            return found;

        }

        // Type (university/college)
        public static bool IsValidType(string type)
        {
            bool typeBool = false;
            if (type.ToUpper() == "University".ToUpper())
            {
                typeBool = true;
                return typeBool;
            }
            if (type.ToUpper() == "College".ToUpper())
            {
                typeBool = true;
                return typeBool;
            }
            else
            {
                return typeBool;
            }
        }

        // Name + Postal code already exists
        public static bool ClientAlreadyExists(string postalC, string name)
        {
            bool found = false;
            if (File.Exists(filePathClients))
            {
                using (StreamReader sr = new StreamReader(filePathClients))
                {
                    string line = sr.ReadLine();
                    while (line != null && !found)
                    {
                        string[] fields = line.Split(',');
                        if (name.ToUpper() == fields[1].ToUpper() && postalC.ToUpper() == fields[4].ToUpper())
                        {
                            found = true;
                        }
                        else
                        line = sr.ReadLine();
                    }
                }
            }

            return found;

        }

        


    }
}
