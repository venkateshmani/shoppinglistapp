using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Webservice.DataModel
{
    [DataContract]
    public class ShoppingList
    {
        [DataMember]
        public string ShoppingListID { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string ListName { get; set; }

        [DataMember]
        public DateTime CreatedDateTime { get; set; }

        [DataMember]
        public bool IsCompleted { get; set; }

        [DataMember]
        public bool IsShared { get; set; }

        [DataMember]
        public short SymbolID { get; set; }
    }
}