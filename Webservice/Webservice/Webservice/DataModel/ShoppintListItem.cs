using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Webservice.DataModel
{
    [DataContract]
    public class ShoppintListItem
    {
        [DataMember]
        public string ItemID { get; set; }

        [DataMember]
        public string ShoppingListID { get; set; }

        [DataMember]
        public string ItemName { get; set; }

        [DataMember]
        public decimal Quantity { get; set; }

        [DataMember]
        public string Units { get; set; }

        [DataMember]
        public string Note { get; set; }

        [DataMember]
        public bool IsPurchased { get; set; }

        [DataMember]
        public DateTime CreateDateTime { get; set; }

        [DataMember]
        public DateTime UpdateDateTime { get; set; }
    }
}