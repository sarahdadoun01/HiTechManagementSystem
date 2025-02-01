using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Business;
using System.Windows.Forms;
using System.IO;

namespace POS.DataAccess
{
    class ClientDA
    {
        static string filePathClients = Application.StartupPath + @"\Client.dat";
        static string filePathClientsTemp = Application.StartupPath + @"\ClientTemp.dat";

        public static void SaveClient(Client c)
        {
            using (StreamWriter sw = new StreamWriter(filePathClients, append: true))
            {
                sw.WriteLine();
                sw.Write(c.Type + "," + c.Name + "," + c.Street + "," + c.City + "," + c.PostalCode + "," + c.PhoneNumber + "," + c.FaxNumber + "," + c.CreditLimit);
            }
            MessageBox.Show("Client information has been saved successfully.", "Success!", MessageBoxButtons.OK);
        }

        public static List<Client> SearchClientName(string name)
        {
            List<Client> listC = new List<Client>();
            StreamReader sr = new StreamReader(filePathClients, true);
            bool found = false;

            if (File.Exists(filePathClients))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (fields[1].ToUpper() == name.ToUpper())
                    {
                        found = true;
                        //MessageBox.Show("Found " + name);
                        Client c = new Client();
                        c.Type = fields[0]; // combobox
                        c.Name = fields[1];
                        c.Street = fields[2];
                        c.City = fields[3];
                        c.PostalCode = fields[4];
                        c.PhoneNumber = fields[5];
                        c.FaxNumber = fields[6];
                        c.CreditLimit = Convert.ToDecimal(fields[7]);

                        //add the Emplotee object to the list
                        listC.Add(c);
                    }
                    else
                    {
                    }
                    line = sr.ReadLine();
                }

                if (!found)
                {
                    MessageBox.Show("'" + name + "'" + " does not exist.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sr.Close();
            }
            else
            {
                MessageBox.Show("We were not able to find this file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listC;

        }

        public static List<Client> SearchClientStreet(string street)
        {
            List<Client> listC = new List<Client>();
            StreamReader sr = new StreamReader(filePathClients, true);
            bool found = false;

            if (File.Exists(filePathClients))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (fields[2].ToUpper() == street.ToUpper())
                    {
                        found = true;
                        //MessageBox.Show("Found " + name);
                        Client c = new Client();
                        c.Type = fields[0]; // combobox
                        c.Name = fields[1];
                        c.Street = fields[2];
                        c.City = fields[3];
                        c.PostalCode = fields[4];
                        c.PhoneNumber = fields[5];
                        c.FaxNumber = fields[6];
                        c.CreditLimit = Convert.ToDecimal(fields[7]);

                        //add the Emplotee object to the list
                        listC.Add(c);
                    }
                    else
                    {
                    }
                    line = sr.ReadLine();
                }

                if (!found)
                {
                    MessageBox.Show("'" + street + "'" + " does not exist.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sr.Close();
            }
            else
            {
                MessageBox.Show("We were not able to find this file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listC;

        }

        public static List<Client> SearchClientCity(string city)
        {
            List<Client> listC = new List<Client>();
            StreamReader sr = new StreamReader(filePathClients, true);
            bool found = false;

            if (File.Exists(filePathClients))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (fields[3].ToUpper() == city.ToUpper())
                    {
                        found = true;
                        //MessageBox.Show("Found " + name);
                        Client c = new Client();
                        c.Type = fields[0]; // combobox
                        c.Name = fields[1];
                        c.Street = fields[2];
                        c.City = fields[3];
                        c.PostalCode = fields[4];
                        c.PhoneNumber = fields[5];
                        c.FaxNumber = fields[6];
                        c.CreditLimit = Convert.ToDecimal(fields[7]);

                        //add the Emplotee object to the list
                        listC.Add(c);
                    }
                    else
                    {
                    }
                    line = sr.ReadLine();
                }

                if (!found)
                {
                    MessageBox.Show("'" + city + "'" + " does not exist.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sr.Close();
            }
            else
            {
                MessageBox.Show("We were not able to find this file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listC;

        }

        public static List<Client> SearchClientPostalCode(string postalC)
        {
            List<Client> listC = new List<Client>();
            StreamReader sr = new StreamReader(filePathClients, true);
            bool found = false;

            if (File.Exists(filePathClients))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (fields[4].ToUpper() == postalC.ToUpper())
                    {
                        found = true;
                        //MessageBox.Show("Found " + name);
                        Client c = new Client();
                        c.Type = fields[0]; // combobox
                        c.Name = fields[1];
                        c.Street = fields[2];
                        c.City = fields[3];
                        c.PostalCode = fields[4];
                        c.PhoneNumber = fields[5];
                        c.FaxNumber = fields[6];
                        c.CreditLimit = Convert.ToDecimal(fields[7]);

                        //add the Emplotee object to the list
                        listC.Add(c);
                    }
                    else
                    {
                    }
                    line = sr.ReadLine();
                }

                if (!found)
                {
                    MessageBox.Show("'" + postalC + "'" + " does not exist.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sr.Close();
            }
            else
            {
                MessageBox.Show("We were not able to find this file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listC;

        }

        public static List<Client> SearchClientType(string type)
        {
            List<Client> listC = new List<Client>();
            StreamReader sr = new StreamReader(filePathClients, true);
            bool found = false;

            if (File.Exists(filePathClients))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (fields[0].ToUpper() == type.ToUpper())
                    {
                        found = true;
                        //MessageBox.Show("Found " + name);
                        Client c = new Client();
                        c.Type = fields[0]; // combobox
                        c.Name = fields[1];
                        c.Street = fields[2];
                        c.City = fields[3];
                        c.PostalCode = fields[4];
                        c.PhoneNumber = fields[5];
                        c.FaxNumber = fields[6];
                        c.CreditLimit = Convert.ToDecimal(fields[7]);

                        //add the Emplotee object to the list
                        listC.Add(c);
                    }
                    else
                    {
                    }
                    line = sr.ReadLine();
                }

                if (!found)
                {
                    MessageBox.Show("'" + type + "'" + " does not exist.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sr.Close();
            }
            else
            {
                MessageBox.Show("We were not able to find this file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listC;

        }

        // If University / College
        public static int IdentifyType(string name)
        {
            bool found = false;
            int index = -1;

            if (File.Exists(filePathClients))
            {
                using (StreamReader sr = new StreamReader(filePathClients))
                {
                    string line = sr.ReadLine();
                    while (line != null && !found)
                    {
                        string[] fields = line.Split(',');
                        if (fields[0].ToUpper() == name.ToUpper())
                        {
                            if (fields[0].ToUpper() == "University".ToUpper())
                            {
                                //MessageBox.Show("University");
                                index = 0;
                            }
                            if (fields[0].ToUpper() == "College".ToUpper())
                            {
                                //MessageBox.Show("College");
                                index = 1;
                            }
                        }
                        else
                        {
                        }
                        line = sr.ReadLine();
                    }
                }
            }

            //MessageBox.Show("index = " + index);
            return index;
        }

        public static void UpdateClient(Client client)
        {
            if (File.Exists(filePathClients))
            {
                StreamReader sr = new StreamReader(filePathClients);
                StreamWriter sw = new StreamWriter(filePathClientsTemp, true);

                //read the first line
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (fields[1].ToUpper() != client.Name.ToUpper())
                    {
                        sw.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3] + "," + fields[4] + "," + fields[5] + "," + fields[6] + "," + fields[7]);
                    }
                    line = sr.ReadLine();
                }
                sw.WriteLine(client.Type + "," + client.Name + "," + client.Street + "," + client.City + "," + client.PostalCode + "," + client.PhoneNumber + "," + client.FaxNumber + "," + client.CreditLimit);
                sr.Close();
                sw.Close();
            }

            File.Delete(filePathClients);
            File.Move(filePathClientsTemp, filePathClients);

        }

        public static void DeleteClient(string postalCode)
        {
            if (File.Exists(filePathClients))
            {
                StreamReader sr = new StreamReader(filePathClients);
                StreamWriter sw = new StreamWriter(filePathClientsTemp, true);


                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (fields[4].ToUpper() != postalCode.ToUpper())
                    {
                        sw.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3] + "," + fields[4] + "," + fields[5] + "," + fields[6] + "," + fields[7]);
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
                sw.Close();

            }
            File.Delete(filePathClients);
            File.Move(filePathClientsTemp, filePathClients);
        }

        public static List<Client> GetAllClient()
        {
            List<Client> listAllClients = new List<Client>();
            if (File.Exists(filePathClients))
            {
                using (StreamReader sr = new StreamReader(filePathClients))
                {
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        string[] fields = line.Split(',');
                        Client c = new Client();

                        c.Type = fields[0];
                        c.Name = fields[1];
                        c.Street = fields[2];
                        c.City = fields[3];
                        c.PostalCode = fields[4];
                        c.PhoneNumber = fields[5];
                        c.FaxNumber = fields[6];
                        c.CreditLimit = Convert.ToDecimal(fields[7]);
                        listAllClients.Add(c);
                        line = sr.ReadLine();
                    }
                }
            }
            else
            {
                listAllClients = null;
                MessageBox.Show("File was not found.", "Sorry!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return listAllClients;
        }
    }
}
