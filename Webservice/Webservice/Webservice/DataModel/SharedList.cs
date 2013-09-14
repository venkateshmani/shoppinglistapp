using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Webservice.DataModel
{
    [DataContract]
    public class SharedList
    {
        [DataMember]
        public string SharedListID { get; set; }

        [DataMember]
        public string ShoppingListID { get; set; }

        [DataMember]
        public string ToPhoneNumber { get; set; }
    }
}