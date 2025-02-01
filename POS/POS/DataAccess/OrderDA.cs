using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using POS.Business;
using System.IO;
using System.Windows.Forms;

namespace POS.DataAccess
{
    class OrderDA
    {
        // File Path Clients
        static string filePathClients = Application.StartupPath + @"\Client.dat";
        static string filePathClientsTemp = Application.StartupPath + @"\ClientTemp.dat";

        // File Path Product : Software
        static string dir = @"";
        static string filePathSoftware = dir + "Software.bin";

        // File Path Product : Book
        static string filePathBook = dir + "Book.bin";

        // File Path Orders
        static string filePathOrders = Application.StartupPath + @"\Orders.dat";
        static string filePathOrdersTemp = Application.StartupPath + @"\OrdersTemp.dat";

        
        public static Client TransferClient(string postalC, string name)
        {
            Client aClient = new Client();

            bool found = false;

            if (File.Exists(filePathClients))
            {
                using (StreamReader sr = new StreamReader(filePathClients))
                {
                    string line = sr.ReadLine();
                    while (line != null && !found)
                    {
                        string[] fields = line.Split(',');
                        if (fields[4].ToUpper() == postalC.ToUpper()) // if postal code & name is equal to inputs
                        {
                            if (fields[1].ToUpper() == name.ToUpper())
                            {
                                found = true;
                                aClient.PostalCode = fields[4];
                                aClient.Name = fields[2];
                                aClient.PhoneNumber = fields[5];
                                aClient.FaxNumber = fields[6];
                            }
                            
                        }
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }
                

            }

            return aClient;
        }

        // Transfers software info not provided by the form into anOrder and sends back to SaveOrderSoftwaree
        public static Order SaveToAnOrderSoftware(Order anOrder)
        {
            Client aClient = TransferClient(anOrder.PostalCode, anOrder.Name);
            Software aSoftware = SoftwareDA.SearchByProductId(anOrder.ProductNumber);

            anOrder.PhoneNumber = aClient.PhoneNumber;
            anOrder.FaxNumber = aClient.FaxNumber;
            anOrder.ProductName = aSoftware.ProductName;
            anOrder.ProductType = aSoftware.ProductType;
            anOrder.Price = Convert.ToDecimal(aSoftware.Price);

            return anOrder;
        }

        // Get other information from Client (with postal code and name) like Phone number, Fax
        //                        and Book   (with product id) like Product Name, type and Price to be able to list it in the ListView
        public static Order SaveToAnOrderBook(Order anOrder)
        {
            Client aClient = TransferClient(anOrder.PostalCode, anOrder.Name);
            Book aBook = BookDA.GetListById(anOrder.ProductNumber);

            anOrder.PhoneNumber = aClient.PhoneNumber;
            anOrder.FaxNumber = aClient.FaxNumber;
            anOrder.ProductName = aBook.ProductName;
            anOrder.ProductType = aBook.ProductType;
            anOrder.Price = Convert.ToDecimal(aBook.UnitPrice);

            return anOrder;
        }

        // Save Order - Software
        public static void SaveOrderSoftware(Order anOrder)
        {
            anOrder = SaveToAnOrderSoftware(anOrder);

            using (StreamWriter sw = new StreamWriter(filePathOrders, true))
            {
                sw.WriteLine();
                sw.Write(anOrder.ProductType + "," + anOrder.OrderId + "," + anOrder.Price + "," + anOrder.Status + "," + anOrder.OrderDate + "," + anOrder.ProductNumber + "," + anOrder.ProductName + "," + anOrder.Name + "," + anOrder.PhoneNumber + "," + anOrder.FaxNumber + "," + anOrder.PostalCode.ToUpper());
            }
            MessageBox.Show("Order has been made successfully. Order is now processing.", "Success!", MessageBoxButtons.OK);

            // deduct credit limit 
            DeductCreditLimit(anOrder.PostalCode, anOrder.Name, anOrder.Price);
        
        }

        // Save Order - Book - I made separate method for book and software in case changes need to be made.
        public static void SaveOrderBook(Order anOrder)
        {
            anOrder = SaveToAnOrderBook(anOrder);

            using (StreamWriter sw = new StreamWriter(filePathOrders, append: true))
            {
                sw.WriteLine();
                sw.Write(anOrder.ProductType + "," + anOrder.OrderId + "," + anOrder.Price + "," + anOrder.Status + "," + anOrder.OrderDate + "," + anOrder.ProductNumber + "," + anOrder.ProductName + "," + anOrder.Name + "," + anOrder.PhoneNumber + "," + anOrder.FaxNumber + "," + anOrder.PostalCode.ToUpper());
            }
            MessageBox.Show("Order has been made successfully. Order is now processing.", "Success!", MessageBoxButtons.OK);

            // deduct credit limit 
            DeductCreditLimit(anOrder.PostalCode, anOrder.Name, anOrder.Price);
        }

        // finds the client information to 'update' the Credit Limit. Sends it to method DeductCreditLimit()
        public static Client SendClientToDecuct(string postalC, string name)
        {
            Client aClient = new Client();

            bool found = false;

            if (File.Exists(filePathClients))
            {
                using (StreamReader sr = new StreamReader(filePathClients))
                {
                    string line = sr.ReadLine();
                    while (line != null && !found)
                    {
                        string[] fields = line.Split(',');
                        if (fields[4].ToUpper() == postalC.ToUpper()) // if postal code & name is equal to inputs
                        {
                            if (fields[1].ToUpper() == name.ToUpper())
                            {
                                aClient.Type = fields[0];
                                aClient.Name = fields[1];
                                aClient.Street = fields[2];
                                aClient.City = fields[3];
                                aClient.PostalCode = fields[4];
                                aClient.PhoneNumber = fields[5];
                                aClient.FaxNumber = fields[6];
                                aClient.CreditLimit = Convert.ToDecimal(fields[7]);
                                found = true;
                                return aClient;
                            }

                        }
                        line = sr.ReadLine();
                    }
                }

            }

            return aClient;
        }

        // recieves postalc, name and price to 'update' the Credit limit of this client.
        public static void DeductCreditLimit(string postalC, string name, decimal price)
        {
            if (File.Exists(filePathClients))
            {
                StreamReader sr = new StreamReader(filePathClients);
                StreamWriter sw = new StreamWriter(filePathClientsTemp, true);
                Client client = SendClientToDecuct(postalC, name);

                //MessageBox.Show(" " + client.CreditLimit);
                client.CreditLimit = client.CreditLimit - price;
                MessageBox.Show("New Credit Limit as of now for " + name + ": " + client.CreditLimit);

                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (fields[4].Trim().ToUpper() != postalC.Trim().ToUpper())
                    {
                        if (fields[1].ToLower() != name.ToLower())
                        {
                            sw.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3] + "," + fields[4] + "," + fields[5] + "," + fields[6] + "," + fields[7]);
                        }
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

        // List all Orders Software
        public static List<Order> ListAllOrders()
        {
            List<Order> listAllOrders = new List<Order>();
            if (File.Exists(filePathOrders))
            {
                using (StreamReader sr = new StreamReader(filePathOrders))
                {
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        string[] fields = line.Split(',');
                        Order o = new Order();

                        o.Type =     fields[0];
                        o.OrderId =         Convert.ToInt32(fields[1]);
                        o.Price =           Convert.ToDecimal(fields[2]);
                        o.Status =          fields[3];
                        o.OrderDate =       fields[4];
                        o.ProductNumber =   Convert.ToInt32(fields[5]);
                        o.ProductName =     fields[6];
                        o.Name =            fields[7];
                        o.PhoneNumber =     fields[8];
                        o.FaxNumber =       fields[9];
                        o.PostalCode =      fields[10];

                        listAllOrders.Add(o);
                        line = sr.ReadLine();
                    }
                }
            }
            else
            {
                listAllOrders = null;
                MessageBox.Show("File was not found.", "Sorry!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return listAllOrders;
        }

        // return price to textboxprice on form
        public static string SearchByProductPrice(int prodId)
        {
            bool found = true;
            if (File.Exists(filePathSoftware))
            {
                FileStream fs = new FileStream(filePathSoftware, FileMode.OpenOrCreate, FileAccess.Read);
                BinaryFormatter binF = new BinaryFormatter();
                while (fs.Position < fs.Length)
                {
                    Software aSoft = new Software();
                    aSoft = (Software)binF.Deserialize(fs);
                    if (aSoft.ProductNumber == prodId)
                    {
                        found = true;
                        fs.Close();
                        return aSoft.Price;
                    }
                }
                fs.Close();

            }
            else
            {
                MessageBox.Show("An error Accured (file not found)", "Missing File");

            }

            if (!found)
            {
                MessageBox.Show("We couldn't find any softwares with the ID " + prodId + ".");
            }

            return null;
        }

        // For Verify button
        public static bool SearchByProductId(int prodId)
        {
            bool found = false;
            if (File.Exists(filePathSoftware))
            {
                FileStream fs = new FileStream(filePathSoftware, FileMode.OpenOrCreate, FileAccess.Read);
                BinaryFormatter binF = new BinaryFormatter();
                while (fs.Position < fs.Length)
                {
                    Software aSoft = new Software();
                    aSoft = (Software)binF.Deserialize(fs);
                    if (aSoft.ProductNumber == prodId)
                    {
                        if (aSoft.ProductType.ToLower() == "software")
                        {
                            found = true;
                            fs.Close();
                            return found;
                        }
                    }
                }
                fs.Close();

            }
            else
            {
                MessageBox.Show("An error Accured (file not found)", "Missing File");

            }

            if (!found)
            {
                MessageBox.Show("We couldn't find any softwares with the ID " + prodId + ".");
            }

            return found;
        }

        // For Verify button
        public static bool SearchByBookId(int prodId)
        {
            bool found = false;
            if (File.Exists(filePathBook))
            {
                FileStream fs = new FileStream(filePathBook, FileMode.OpenOrCreate, FileAccess.Read);
                BinaryFormatter binF = new BinaryFormatter();
                while (fs.Position < fs.Length)
                {
                    Book aBook = new Book();
                    aBook = (Book)binF.Deserialize(fs);
                    if (aBook.ProductNumber == prodId)
                    {
                        if (aBook.ProductType.ToLower() == "book".ToLower())
                        {
                            found = true;
                            return found;
                        }
                        
                    }
                }
                fs.Close();

            }
            else
            {
                MessageBox.Show("An error Accured (file not found)", "Missing File");

            }

            if (!found)
            {
                MessageBox.Show("We couldn't find any books with the ID " + prodId + ".");
            }

            return found;
        }

        // Verify Client
        public static bool VerifyClient(string postalC, string name)
        {
            Client aClient = new Client();
            bool found = false;

            //MessageBox.Show("PC received: " + postalC + "Name received: " + name);
            if (File.Exists(filePathClients))
            {
                using (StreamReader sr = new StreamReader(filePathClients))
                {
                    string line = sr.ReadLine();
                    while (line != null && !found)
                    {
                        string[] fields = line.Split(',');
                        if (fields[4].Trim().ToUpper() == postalC.Trim().ToUpper()) // if postal code & name is equal to inputs
                        {
                            //MessageBox.Show("Found postal");
                            if (fields[1].ToUpper() == name.ToUpper())
                            {
                                //MessageBox.Show("Found name");
                                found = true;
                            }
                        }
                        line = sr.ReadLine();
                    }
                }

            }
            return found;
        }

        // search button
        public static List<Order> SearchOrderId(string oId)
        {
            List<Order> listO = new List<Order>();
            StreamReader sr = new StreamReader(filePathOrders, true);
            bool found = false;

            if (File.Exists(filePathOrders))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (fields[1].ToUpper() == oId)
                    {
                        found = true;
                        //MessageBox.Show("Found " + name);
                        Order o = new Order();
                        o.ProductType =        fields[0]; // combobox
                        o.OrderId =     Convert.ToInt32(fields[1]);
                        o.Price =       Convert.ToDecimal(fields[2]);
                        o.Status =      fields[3];
                        o.OrderDate =   fields[4];
                        o.ProductNumber = Convert.ToInt32(fields[5]);
                        o.ProductName = fields[6];
                        o.Name =        fields[7];
                        o.PhoneNumber = fields[8];
                        o.FaxNumber =   fields[9];
                        o.PostalCode =  fields[10];

                        listO.Add(o);
                    }
                    else
                    {
                    }
                    line = sr.ReadLine();
                }

                if (!found)
                {
                    MessageBox.Show("'" + oId + "'" + " does not exist.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sr.Close();
            }
            else
            {
                MessageBox.Show("We were not able to find this file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listO;

        }

        public static List<Order> SearchProductId(string pId)
        {
            List<Order> listO = new List<Order>();
            StreamReader sr = new StreamReader(filePathOrders, true);
            bool found = false;

            if (File.Exists(filePathOrders))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (fields[5].ToUpper() == pId)
                    {
                        found = true;
                        //MessageBox.Show("Found " + name);

                        Order o = new Order();
                        o.ProductType =            fields[0]; // combobox
                        o.OrderId =         Convert.ToInt32(fields[1]);
                        o.Price =           Convert.ToDecimal(fields[2]);
                        o.Status =          fields[3];
                        o.OrderDate =       fields[4];
                        o.ProductNumber =   Convert.ToInt32(fields[5]);
                        o.ProductName =     fields[6];
                        o.Name =            fields[7];
                        o.PhoneNumber =     fields[8];
                        o.FaxNumber =       fields[9];
                        o.PostalCode =      fields[10];

                        listO.Add(o);
                    }
                    else
                    {
                    }
                    line = sr.ReadLine();
                }

                if (!found)
                {
                    MessageBox.Show("'" + pId + "'" + " does not exist.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sr.Close();
            }
            else
            {
                MessageBox.Show("We were not able to find this file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listO;

        }

        public static List<Order> SearchStatus(string status)
        {
            List<Order> listO = new List<Order>();
            StreamReader sr = new StreamReader(filePathOrders, true);
            bool found = false;

            if (File.Exists(filePathOrders))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (fields[3].ToLower() == status.ToLower())
                    {
                        found = true;
                        //MessageBox.Show("Found " + name);

                        Order o = new Order();
                        o.ProductType = fields[0]; // combobox
                        o.OrderId = Convert.ToInt32(fields[1]);
                        o.Price = Convert.ToDecimal(fields[2]);
                        o.Status = fields[3];
                        o.OrderDate = fields[4];
                        o.ProductNumber = Convert.ToInt32(fields[5]);
                        o.ProductName = fields[6];
                        o.Name = fields[7];
                        o.PhoneNumber = fields[8];
                        o.FaxNumber = fields[9];
                        o.PostalCode = fields[10];

                        listO.Add(o);
                    }
                    else
                    {
                    }
                    line = sr.ReadLine();
                }

                if (!found)
                {
                    MessageBox.Show("'" + status + "'" + " does not exist.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sr.Close();
            }
            else
            {
                MessageBox.Show("We were not able to find this file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listO;

        }

        public static List<Order> SearchProductType(string pType)
        {
            List<Order> listO = new List<Order>();
            StreamReader sr = new StreamReader(filePathOrders, true);
            bool found = false;

            if (File.Exists(filePathOrders))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (fields[0].ToLower() == pType.ToLower())
                    {
                        found = true;
                        //MessageBox.Show("Found " + name);

                        Order o = new Order();
                        o.ProductType = fields[0]; // combobox
                        o.OrderId = Convert.ToInt32(fields[1]);
                        o.Price = Convert.ToDecimal(fields[2]);
                        o.Status = fields[3];
                        o.OrderDate = fields[4];
                        o.ProductNumber = Convert.ToInt32(fields[5]);
                        o.ProductName = fields[6];
                        o.Name = fields[7];
                        o.PhoneNumber = fields[8];
                        o.FaxNumber = fields[9];
                        o.PostalCode = fields[10];

                        listO.Add(o);
                    }
                    else
                    {
                    }
                    line = sr.ReadLine();
                }

                if (!found)
                {
                    MessageBox.Show("'" + pType + "'" + " does not exist.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sr.Close();
            }
            else
            {
                MessageBox.Show("We were not able to find this file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listO;

        }


        public static List<Order> SearchPostalC(string postalC)
        {
            List<Order> listO = new List<Order>();
            StreamReader sr = new StreamReader(filePathOrders, true);
            bool found = false;

            if (File.Exists(filePathOrders))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (fields[10].ToLower() == postalC.ToLower())
                    {
                        found = true;
                        //MessageBox.Show("Found " + name);

                        Order o = new Order();
                        o.ProductType = fields[0]; // combobox
                        o.OrderId = Convert.ToInt32(fields[1]);
                        o.Price = Convert.ToDecimal(fields[2]);
                        o.Status = fields[3];
                        o.OrderDate = fields[4];
                        o.ProductNumber = Convert.ToInt32(fields[5]);
                        o.ProductName = fields[6];
                        o.Name = fields[7];
                        o.PhoneNumber = fields[8];
                        o.FaxNumber = fields[9];
                        o.PostalCode = fields[10];

                        listO.Add(o);
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

            return listO;

        }

        public static List<Order> SearchClientName(string cName)
        {
            List<Order> listO = new List<Order>();
            StreamReader sr = new StreamReader(filePathOrders, true);
            bool found = false;

            if (File.Exists(filePathOrders))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (fields[7].ToLower() == cName.ToLower())
                    {
                        found = true;
                        //MessageBox.Show("Found " + name);

                        Order o = new Order();
                        o.ProductType = fields[0]; // combobox
                        o.OrderId = Convert.ToInt32(fields[1]);
                        o.Price = Convert.ToDecimal(fields[2]);
                        o.Status = fields[3];
                        o.OrderDate = fields[4];
                        o.ProductNumber = Convert.ToInt32(fields[5]);
                        o.ProductName = fields[6];
                        o.Name = fields[7];
                        o.PhoneNumber = fields[8];
                        o.FaxNumber = fields[9];
                        o.PostalCode = fields[10];

                        listO.Add(o);
                    }
                    else
                    {
                    }
                    line = sr.ReadLine();
                }

                if (!found)
                {
                    MessageBox.Show("'" + cName + "'" + " does not exist.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sr.Close();
            }
            else
            {
                MessageBox.Show("We were not able to find this file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listO;

        }

        // Update Order SOFTWARE
        public static void UpdateOrderSoftware(Order anOrder)
        {
            anOrder = SaveToAnOrderSoftware(anOrder);

            if (File.Exists(filePathOrders))
            {
                StreamReader sr = new StreamReader(filePathOrders);
                StreamWriter sw = new StreamWriter(filePathOrdersTemp, true);

                //read the first line
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (fields[1] != anOrder.OrderId.ToString())
                    {
                        sw.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3] + "," + fields[4] + "," + fields[5] + "," + fields[6] + "," + fields[7] + "," + fields[8] + "," + fields[9] + "," + fields[10]);
                    }
                    line = sr.ReadLine();
                }
                sw.WriteLine(anOrder.ProductType + "," + anOrder.OrderId + "," + anOrder.Price + "," + anOrder.Status + "," + anOrder.OrderDate + "," + anOrder.ProductNumber + "," + anOrder.ProductName + "," + anOrder.Name + "," + anOrder.PhoneNumber + "," + anOrder.FaxNumber + "," + anOrder.PostalCode);
                sr.Close();
                sw.Close();
            }

            File.Delete(filePathOrders);
            File.Move(filePathOrdersTemp, filePathOrders);

        }

        // Update Order SOFTWARE
        public static void UpdateOrderBook(Order anOrder)
        {
            anOrder = SaveToAnOrderBook(anOrder);

            if (File.Exists(filePathOrders))
            {
                StreamReader sr = new StreamReader(filePathOrders);
                StreamWriter sw = new StreamWriter(filePathOrdersTemp, true);

                //read the first line
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (fields[1] != anOrder.OrderId.ToString())
                    {
                        sw.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3] + "," + fields[4] + "," + fields[5] + "," + fields[6] + "," + fields[7] + "," + fields[8] + "," + fields[9] + "," + fields[10]);
                    }
                    line = sr.ReadLine();
                }
                sw.WriteLine(anOrder.ProductType + "," + anOrder.OrderId + "," + anOrder.Price + "," + anOrder.Status + "," + anOrder.OrderDate + "," + anOrder.ProductNumber + "," + anOrder.ProductName + "," + anOrder.Name + "," + anOrder.PhoneNumber + "," + anOrder.FaxNumber + "," + anOrder.PostalCode);
                sr.Close();
                sw.Close();
            }

            File.Delete(filePathOrders);
            File.Move(filePathOrdersTemp, filePathOrders);

        }

        public static void CancelOrderBook(Order anOrder)
        {
            anOrder = SaveToAnOrderBook(anOrder);

            if (File.Exists(filePathOrders))
            {
                anOrder.Status = "Cancelled";

                StreamReader sr = new StreamReader(filePathOrders);
                StreamWriter sw = new StreamWriter(filePathOrdersTemp, true);

                //read the first line
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (fields[0] != anOrder.OrderId.ToString())
                    {
                        sw.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3] + "," + fields[4] + "," + fields[5] + "," + fields[6] + "," + fields[7] + "," + fields[8] + "," + fields[9] + "," + fields[10]);
                    }
                    line = sr.ReadLine();
                }
                sw.WriteLine(anOrder.ProductType + "," + anOrder.OrderId + "," + anOrder.Price + "," + anOrder.Status + "," + anOrder.OrderDate + "," + anOrder.ProductNumber + "," + anOrder.ProductName + "," + anOrder.Name + "," + anOrder.PhoneNumber + "," + anOrder.FaxNumber + "," + anOrder.PostalCode);
                sr.Close();
                sw.Close();
            }

            File.Delete(filePathOrders);
            File.Move(filePathOrdersTemp, filePathOrders);
        }

        public static void CancelOrderSoftware(Order anOrder)
        {
            anOrder = SaveToAnOrderSoftware(anOrder);

            if (File.Exists(filePathOrders))
            {
                anOrder.Status = "Cancelled";

                StreamReader sr = new StreamReader(filePathOrders);
                StreamWriter sw = new StreamWriter(filePathOrdersTemp, true);

                //read the first line
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (fields[0] != anOrder.OrderId.ToString())
                    {
                        sw.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3] + "," + fields[4] + "," + fields[5] + "," + fields[6] + "," + fields[7] + "," + fields[8] + "," + fields[9] + "," + fields[10]);
                    }
                    line = sr.ReadLine();
                }
                sw.WriteLine(anOrder.ProductType + "," + anOrder.OrderId + "," + anOrder.Price + "," + anOrder.Status + "," + anOrder.OrderDate + "," + anOrder.ProductNumber + "," + anOrder.ProductName + "," + anOrder.Name + "," + anOrder.PhoneNumber + "," + anOrder.FaxNumber + "," + anOrder.PostalCode);
                sr.Close();
                sw.Close();
            }

            File.Delete(filePathOrders);
            File.Move(filePathOrdersTemp, filePathOrders);
        }

        public static void DeleteOrder(string oId)
        {
            if (File.Exists(filePathOrders))
            {
                StreamReader sr = new StreamReader(filePathOrders);
                StreamWriter sw = new StreamWriter(filePathOrdersTemp, true);

                //read the first line
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (fields[2] != oId)
                    {
                        sw.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3] + "," + fields[4] + "," + fields[5] + "," + fields[6] + "," + fields[7] + "," + fields[8] + "," + fields[9] + "," + fields[10]);
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
                sw.Close();
            }

            File.Delete(filePathOrders);
            File.Move(filePathOrdersTemp, filePathOrders);
        }


    }
}
