using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using POS.Business;
using System.Windows.Forms;

namespace POS.DataAccess
{
    class SoftwareDA
    {
        static string dir = @"";
        static string filePathSoftware = dir + "Software.bin";
        static string filePathSoftwareTemp = dir + "SoftwareTemp.bin";

        /// <summary>
        /// </summary>
        /// <param name="software"></param>

        public static void Save(Software software)
        {
            FileStream fs = new FileStream(filePathSoftware, FileMode.Append, FileAccess.Write);
            //using (fs)
            //{
            //    BinaryFormatter binF = new BinaryFormatter();
            //    binF.Serialize(fs, software);
            //}
            BinaryFormatter binF = new BinaryFormatter();
            binF.Serialize(fs, software);
            fs.Close();

            MessageBox.Show("Product has been successfully saved.", "Success!");

        }

        public static List<Software> GetListSoftwares()
        {
            List<Software> listS = new List<Software>();

            FileStream fs = new FileStream(filePathSoftware, FileMode.Open, FileAccess.Read);
            BinaryFormatter binF = new BinaryFormatter();

            if (File.Exists(filePathSoftware))
            {
                while (fs.Position < fs.Length)
                {
                    Software aSoftw = new Software();
                    aSoftw = (Software)binF.Deserialize(fs);

                    listS.Add(aSoftw);

                }

            }
            fs.Close();
            return listS;
        }

        public static List<Software> GetListByTitle(string title)
        {
            List<Software> listS = new List<Software>();
            bool found = false;
            FileStream fs = new FileStream(filePathSoftware, FileMode.Open, FileAccess.Read);
            BinaryFormatter binF = new BinaryFormatter();

            if (File.Exists(filePathSoftware))
            {
                while (fs.Position < fs.Length)
                {
                    Software aSoftw = new Software();
                    aSoftw = (Software)binF.Deserialize(fs);
                    if (aSoftw.ProductName.ToLower() == title.ToLower())
                    {
                        found = true;
                        listS.Add(aSoftw);
                    }

                }

            }
            if (!found)
            {
                MessageBox.Show("We couldn't find {0}.", title);
            }
            fs.Close();
            return listS;
        }

        public static List<Software> GetListByStatus(string status)
        {
            List<Software> listS = new List<Software>();
            bool found = false;
            FileStream fs = new FileStream(filePathSoftware, FileMode.Open, FileAccess.Read);
            BinaryFormatter binF = new BinaryFormatter();

            if (File.Exists(filePathSoftware))
            {
                while (fs.Position < fs.Length)
                {
                    Software aSoftw = new Software();
                    aSoftw = (Software)binF.Deserialize(fs);
                    if (aSoftw.Status.ToLower() == status.ToLower())
                    {
                        found = true;
                        listS.Add(aSoftw);
                    }

                }

            }
            if (!found)
            {
                MessageBox.Show("We couldn't find {0}.", status);
            }
            fs.Close();
            return listS;
        }

        public static List<Software> GetListByOS(string os)
        {
            List<Software> listS = new List<Software>();
            bool found = false;

            MessageBox.Show("" + os);

            FileStream fs = new FileStream(filePathSoftware, FileMode.Open, FileAccess.Read);
            BinaryFormatter binF = new BinaryFormatter();

            if (File.Exists(filePathSoftware))
            {
                while (fs.Position < fs.Length)
                {
                    Software aSoftw = new Software();
                    aSoftw = (Software)binF.Deserialize(fs);
                    MessageBox.Show("" + aSoftw.Os);
                    if (aSoftw.Os.Trim().ToLower() == os.Trim().ToLower())
                    {
                        found = true;
                        listS.Add(aSoftw);
                    }

                }

            }
            if (!found)
            {
                MessageBox.Show("We couldn't find " + os);
            }
            fs.Close();
            return listS;
        }

        public static void UpdateSoftware(int pId, Software aSoftware)
        {
            FileStream fs = new FileStream(filePathSoftware, FileMode.Open, FileAccess.Read);
            FileStream fw = new FileStream(filePathSoftwareTemp, FileMode.Append, FileAccess.Write);

            BinaryFormatter binF = new BinaryFormatter();
            bool found = false;
            //MessageBox.Show("Prod number passed to method: " + aSoftware.ProductNumber);

            if (File.Exists(filePathSoftware))
            {
                Software aSoftw = new Software();
                while (fs.Position < fs.Length)
                {
                    aSoftw = (Software)binF.Deserialize(fs);
                    if (aSoftw.ProductNumber != pId)
                    {
                        found = true;
                        binF.Serialize(fw, aSoftw);
                    }

                }
                binF.Serialize(fw, aSoftware);
                fs.Close();
                fw.Close();

            }

            File.Delete(filePathSoftware);
            File.Move(filePathSoftwareTemp, filePathSoftware);

            if (found)
            {
                MessageBox.Show("Software has been successfully updated.", "Updated", MessageBoxButtons.OK);
            }
        }

        public static void DeleteSoftware(int pId)
        {
            FileStream fs = new FileStream(filePathSoftware, FileMode.Open, FileAccess.Read);
            FileStream fw = new FileStream(filePathSoftwareTemp, FileMode.Append, FileAccess.Write);

            BinaryFormatter binF = new BinaryFormatter();
            bool found = false;

            if (File.Exists(filePathSoftware))
            {
                Software aSoftw = new Software();
                while (fs.Position < fs.Length)
                {
                    aSoftw = (Software)binF.Deserialize(fs);
                    if (aSoftw.ProductNumber != pId)
                    {
                        found = true;
                        binF.Serialize(fw, aSoftw);
                    }

                }
                fs.Close();
                fw.Close();
            }

            File.Delete(filePathSoftware);
            File.Move(filePathSoftwareTemp, filePathSoftware);

            if (found)
            {
                MessageBox.Show("Software has been successfully deleted.", "Updated", MessageBoxButtons.OK);
            }
        }

        public static Software SearchByProductId(int prodId)
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
                        return aSoft;
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





    }
}
