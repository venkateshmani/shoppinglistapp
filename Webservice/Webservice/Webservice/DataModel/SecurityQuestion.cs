using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Webservice.DataModel
{
    [DataContract]
    public class SecurityQuestion
    {
        [DataMember]
        public short SecurityQuestionID { get; set; }

        [DataMember]
        public string Question { get; set; }
    }
}