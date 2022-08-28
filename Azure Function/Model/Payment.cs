using System;
using System.Collections.Generic;

namespace Azure_Function.Model
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public string BuyerEmail { get; set; }
        public string BuyerName { get; set; }
        public int BookId { get; set; }
        public DateTime PaymentDate { get; set; }

        public virtual Book Book { get; set; }
    }
}
