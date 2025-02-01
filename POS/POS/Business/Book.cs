using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.DataAccess;
using POS.Validation;

namespace POS.Business
{
    [Serializable]
    public class Book : Author
    {
        private string isbn;
        private decimal unitPrice;
        private string category; // databases, math, object oriented, network, etc....
        private int quantity;
        private string supplier;
        private int publishedYear;

        public string Isbn { get => isbn; set => isbn = value; }
        public decimal UnitPrice { get => unitPrice; set => unitPrice = value; }
        public string Category { get => category; set => category = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int PublishedYear { get => publishedYear; set => publishedYear = value; }

        public List<Book> ListBooks { get; set; }
        public string Supplier { get => supplier; set => supplier = value; }

        public void SaveBook(Book book)
        {
            BookDA.Save(book);
        }

        public List<Book> ListAllBooks()
        {
            return BookDA.GetListBooks();
        }

        public List<Book> SearchByTitle(string title)
        {
            return BookDA.GetListByTitle(title);

        }

        public Book SearchById(int pId)
        {
            return BookDA.GetListById(pId);
        }

        public List<Book> SearchByYear(int yearP)
        {
            return BookDA.GetListByYear(yearP);
        }

        public List<Book> SearchByAuthorId(int aId)
        {
            return BookDA.GetListByAuthorId(aId);
        }

        public void DeleteBook(int pId)
        {
            BookDA.DeleteBook(pId);
        }

        public void UpdateBook(int pId, Book aBook)
        {
            BookDA.UpdateBook(pId, aBook);
        }

    }
}
