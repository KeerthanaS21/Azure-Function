using System;
using System.Collections.Generic;

namespace Azure_Function.Model
{
    public partial class Book
    {
        public Book()
        {
            Payments = new HashSet<Payment>();
        }

        public int BookId { get; set; }
        public byte[] Logo { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string AuthorName { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Content { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual DigitalBooksUser AuthorNameNavigation { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
