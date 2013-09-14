using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Webservice.DataModel
{
    [DataContract]
    public class PendingNotification
    {
        [DataMember]
        public string NotifyID { get; set; }

        [DataMember]
        public string FromPhoneNumber { get; set; }

        [DataMember]
        public string ToPhoneNumber { get; set; }

        [DataMember]
        public string ShoppingListID { get; set; }

        [DataMember]
        public bool IsShared { get; set; }

        [DataMember]
        public bool IsNotified { get; set; }
    }
}