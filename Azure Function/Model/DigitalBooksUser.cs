using System;
using System.Collections.Generic;

namespace Azure_Function.Model
{
    public partial class DigitalBooksUser
    {
        public DigitalBooksUser()
        {
            Books = new HashSet<Book>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserPass { get; set; }
        public string UserRole { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
