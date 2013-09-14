using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Webservice.DataModel
{
    [DataContract]
    public class Country
    {
        [DataMember]
        public short CountryCode { get; set; }

        [DataMember]
        public short CountryName { get; set; }
    }
}