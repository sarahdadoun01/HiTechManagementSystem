using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.DataAccess;

namespace POS.Business
{
    [Serializable]
    public class Author : Product
    {
        private int authorId;
        private string firstName;
        private string lastName;

        public int AuthorId { get => authorId; set => authorId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
    }
}
