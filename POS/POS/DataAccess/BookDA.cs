using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using POS.Business;
using System.Windows.Forms;

namespace POS.DataAccess
{
    class BookDA
    {
        static string dir = @"";
        static string filePathBook = dir + "Book.bin";
        static string filePathBookTemp = dir + "BookTemp.bin";

        /// <summary>
        /// This methods save a course assignment to the file CourseAssignments.bin
        /// </summary>
        /// <param name="software"></param>

        public static void Save(Book book)
        {
            FileStream fs = new FileStream(filePathBook, FileMode.Append, FileAccess.Write);
            using (fs)
            {
                BinaryFormatter binF = new BinaryFormatter();
                binF.Serialize(fs, book);
            }
            //BinaryFormatter binF = new BinaryFormatter();
            //binF.Serialize(fs, book);
            //fs.Close();
            MessageBox.Show("Product has been successfully saved.", "Success!");
        }

        public static List<Book> GetListBooks()
        {
            List<Book> listB = new List<Book>();

            FileStream fs = new FileStream(filePathBook, FileMode.Open, FileAccess.Read);
            BinaryFormatter binF = new BinaryFormatter();

            if (File.Exists(filePathBook))
            {
                while (fs.Position < fs.Length)
                {
                    Book aBook = new Book();
                    aBook = (Book)binF.Deserialize(fs);

                    listB.Add(aBook);

                }

            }
            fs.Close();
            return listB;
        }

        public static List<Book> GetListByTitle(string title)
        {
            List<Book> listB = new List<Book>();
            bool found = false;
            FileStream fs = new FileStream(filePathBook, FileMode.Open, FileAccess.Read);
            BinaryFormatter binF = new BinaryFormatter();

            if (File.Exists(filePathBook))
            {
                while (fs.Position < fs.Length)
                {
                    Book b = new Book();
                    b = (Book)binF.Deserialize(fs);
                    if (b.ProductName.ToLower() == title.ToLower())
                    {
                        found = true;
                        listB.Add(b);
                    }

                }

            }
            if (!found)
            {
                MessageBox.Show("We couldn't find {0}.", title);
            }
            fs.Close();
            return listB;
        }

        public static Book GetListById(int pId)
        {
            Book listB = new Book();
            bool found = true;
            if (File.Exists(filePathBook))
            {
                FileStream fs = new FileStream(filePathBook, FileMode.OpenOrCreate, FileAccess.Read);
                BinaryFormatter binF = new BinaryFormatter();
                while (fs.Position < fs.Length)
                {
                    Book aBook = new Book();
                    aBook = (Book)binF.Deserialize(fs);
                    if (aBook.ProductNumber == pId)
                    {
                        found = true;
                        return aBook;
                    }
                }
                fs.Close();

            }
            if (!found)
            {
                MessageBox.Show("We couldn't find any books with the ID " + pId + ".");
            }
            return listB;
        }

        public static List<Book> GetListByAuthorId(int aId)
        {
            List<Book> listB = new List<Book>();
            bool found = false;
            FileStream fs = new FileStream(filePathBook, FileMode.Open, FileAccess.Read);
            BinaryFormatter binF = new BinaryFormatter();

            if (File.Exists(filePathBook))
            {
                while (fs.Position < fs.Length)
                {
                    Book b = new Book();
                    b = (Book)binF.Deserialize(fs);
                    if (b.ProductNumber == aId)
                    {
                        found = true;
                        listB.Add(b);
                        return listB;
                    }

                }

            }
            if (!found)
            {
                MessageBox.Show("We couldn't find any books with the author ID " + aId + ".");
            }
            fs.Close();
            return listB;
        }

        public static List<Book> GetListByYear(int yearP)
        {
            List<Book> listB = new List<Book>();
            bool found = false;
            FileStream fs = new FileStream(filePathBook, FileMode.Open, FileAccess.Read);
            BinaryFormatter binF = new BinaryFormatter();

            if (File.Exists(filePathBook))
            {
                while (fs.Position < fs.Length)
                {
                    Book b = new Book();
                    b = (Book)binF.Deserialize(fs);
                    if (b.PublishedYear == yearP)
                    {
                        found = true;
                        listB.Add(b);
                    }

                }

            }
            if (!found)
            {
                MessageBox.Show("We couldn't find the year" + yearP + ".");
            }
            fs.Close();
            return listB;
        }

        public static void UpdateBook(int pId, Book book)
        {
            FileStream fs = new FileStream(filePathBook, FileMode.Open, FileAccess.Read);
            FileStream fw = new FileStream(filePathBookTemp, FileMode.Append, FileAccess.Write);

            BinaryFormatter binF = new BinaryFormatter();
            bool found = false;
            //MessageBox.Show("Prod number passed to method: " + aSoftware.ProductNumber);

            if (File.Exists(filePathBook))
            {
                Book aBook = new Book();
                while (fs.Position < fs.Length)
                {
                    aBook = (Book)binF.Deserialize(fs);
                    if (aBook.ProductNumber != pId)
                    {
                        found = true;
                        binF.Serialize(fw, aBook);
                    }
                }
                binF.Serialize(fw, book);
                fs.Close();
                fw.Close();

            }

            File.Delete(filePathBook);
            File.Move(filePathBookTemp, filePathBook);

            if (found)
            {
                MessageBox.Show("Book has been successfully updated.", "Updated", MessageBoxButtons.OK);
            }
            if (!found)
            {
                MessageBox.Show("Book has NOT been successfully updated.", "Updated", MessageBoxButtons.OK);
            }
        }

        public static void DeleteBook(int pId)
        {
            FileStream fs = new FileStream(filePathBook, FileMode.Open, FileAccess.Read);
            FileStream fw = new FileStream(filePathBookTemp, FileMode.Append, FileAccess.Write);

            BinaryFormatter binF = new BinaryFormatter();
            bool found = false;

            if (File.Exists(filePathBook))
            {
                Book aBook = new Book();
                while (fs.Position < fs.Length)
                {
                    aBook = (Book)binF.Deserialize(fs);
                    if (aBook.ProductNumber != pId)
                    {
                        found = true;
                        binF.Serialize(fw, aBook);
                    }
                }
                fs.Close();
                fw.Close();
            }

            File.Delete(filePathBook);
            File.Move(filePathBookTemp, filePathBook);

            if (found)
            {
                MessageBox.Show("Book has been successfully deleted.", "Updated", MessageBoxButtons.OK);
            }
        }

    }
}
